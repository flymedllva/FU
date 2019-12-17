import sys
import os
import signal
import subprocess
import json
import hashlib
import threading

from socket import socket, SO_REUSEADDR, SOL_SOCKET
from server.models import User, Message
from server.utils.logger import Logger
from time import time, sleep


class SecondInstanceBan(type):
    _instances = dict()

    def __call__(cls, *args, **kwargs):
        if cls not in cls._instances:
            cls._instances[cls] = super(SecondInstanceBan, cls).__call__(*args, **kwargs)
        signal.signal(signal.SIGTERM, cls._instances[cls].exit)
        signal.signal(signal.SIGINT, cls._instances[cls].exit)
        return cls._instances[cls]


class ServerData(object):

    def __init__(self, data: dict, type: str = "message", notice: str = None):
        """
        Конструктор данных

        :param data:
        :param type:
        :param notice:
        """

        self.notice = notice
        self.data = data
        self.type = type

    def to_json(self):
        """
        Возвращает данные в виде JSON

        :return:
        """

        return json.dumps(dict(type=self.type, data=self.data, notice=self.notice)).encode("utf-8")


class MessageHandler(object):

    def __init__(self, data: dict, salt: str = None):
        """
        Конструтор обработчика сообщений

        :param data:
        """

        self.data = data
        self.__salt = "salt" if salt is None else salt

    def response(self) -> bytes or tuple:
        """
        Генерирует ответ для сервера

        :return:
        """

        if self.data and isinstance(self.data, dict) and "type" in self.data and "data" in self.data:
            data = self.data
            if data["type"] == "message":
                user_data = self.__chat(data["data"])
                if user_data.notice == "OK":
                    messages = data["data"]["message"]
                    data = list()
                    for message in [messages[x:x + 256] for x in range(0, len(messages), 256)]:
                        data.append(ServerData(type="broadcast_message",
                                               data=dict(login=user_data.data["login"],
                                                         message=message),
                                               notice="OK").to_json())
                    return "broadcast", user_data.to_json(), data
            elif data["type"] == "get_messages":
                if "token" in data["data"]:
                    user = User.search_user(token=data["data"]["token"])
                    if user is not None:
                        data = list()
                        for i in Message.today_messages():
                            data.append(ServerData(type="get_messages",
                                                   data=dict(message=i.message,
                                                             date=i.date.strftime("%H:%M:%S"),
                                                             login=User.search_user(id=i.user_id).login),
                                                   notice="OK").to_json())
                        return "get_messages", data
            elif data["type"] == "authorization":
                return self.__authorization(data["data"]).to_json()
            elif data["type"] == "registration":
                return self.__registration(data["data"]).to_json()
        return None

    def __chat(self, data) -> ServerData or None:
        """
        Чат

        :param data:
        :return:
        """

        if self.data and "message" in data and "token" in data and "login" in data:
            user = User.search_user(token=data["token"], login=data["login"])
            if user is not None:
                message = data["message"]
                if message is not None and message != "":
                    for message in [message[x:x + 256] for x in range(0, len(message), 256)]:
                        user = user.add_new_message(message)
                return ServerData(type="message", data=dict(login=user.login, token=user.token), notice="OK")
        return ServerData(type="authorization", data=dict(token=None), notice="Wrong login or password")

    def __registration(self, data) -> ServerData:
        """
        Регистрация нового пользователя

        :param data:
        :return:
        """

        if "login" in data and "password" in data:
            user = User.search_user(login=data["login"])
            if user:
                return ServerData(type="authorization", data=dict(token=None), notice="User already exists")
            password = hashlib.md5((data["password"] + self.__salt).encode()).hexdigest()
            token = self.create_token(password)
            user = User.create_user(login=data["login"], password=password, token=token)
            return ServerData(type="authorization", data=dict(token=user.token), notice="The user is created")
        return ServerData(type="authorization", data=dict(token=None), notice="Invalid request")

    def __authorization(self, data) -> ServerData:
        """
        Проверяет авторизация пользователя

        :param data:
        :return:
        """

        if "token" in data:
            user = User.search_user(token=data["token"])
            if user is not None:
                if user.token == data["token"]:
                    return ServerData(type="authorization", data=dict(token=user.token, login=user.login), notice="OK")
            return ServerData(type="authorization", data=dict(token=None), notice="Invalid token")
        if "login" in data and "password" in data:
            user = User.search_user(login=data["login"])
            if user:
                if user.login == data["login"] and \
                        user.password == hashlib.md5((data["password"] + self.__salt).encode()).hexdigest():
                    user = user.update_user(data=dict(token=self.create_token(user.password)))
                    # self.entered = True
                    return ServerData(type="authorization", data=dict(token=user.token, login=user.login), notice="OK")
                else:
                    return ServerData(type="authorization", data=dict(token=None), notice="Wrong login or password")
            else:
                return ServerData(type="authorization", data=dict(token=None), notice="The user is not found")
        return ServerData(type="authorization", data=dict(token=None), notice="Invalid request")

    @classmethod
    def create_token(cls, data) -> str:
        """
        Создает токен

        :param data:
        :return:
        """

        return hashlib.md5((data + str(time())).encode()).hexdigest()


class Peer(threading.Thread):

    def __init__(self, sock_server: 'Server', sock: socket, address: tuple):
        """
        Конструктор сокета

        :param sock_server:
        :param sock:
        :param address:
        """

        super(Peer, self).__init__()
        self.daemon = True
        self._server = sock_server
        self._sock = sock
        self._address = address
        self._listen = True

        self._server.logger.new_connection(self._address)

    def run(self) -> None:
        """
        Запускается при старте потока

        :return:
        """

        data = list()
        while True:
            recv_data = self._sock.recv(1024)
            if recv_data == b"":
                break
            data.append(recv_data.decode("utf-8"))
            try:
                recv_data = "".join(data)
                self._server.logger.obtain_data(self._address, recv_data)
                data = MessageHandler(json.loads(recv_data)).response()
                if isinstance(data, tuple):
                    if data[0] == "get_messages":
                        for item in data[1]:
                            self.send(item)
                    elif data[0] == "broadcast":
                        self.send(data[1])
                        for item in data[2]:
                            self._server.broadcast(self, item)
                elif isinstance(data, bytes):
                    self.send(data)
                data = list()
            except json.decoder.JSONDecodeError:
                continue

        self._server.logger.connection_closed(self._address)
        self.close()

    def send(self, data: bytes) -> None:
        """
        Отправляет данные текущему сокету

        :param data:
        :return:
        """

        self._sock.sendall(data + b"\0")
        self._server.logger.send_data(self._address, data)

    def close(self) -> None:
        """
        Закрывает текущее соединение

        :return:
        """

        self._sock.close()
        self._server.peer_remove(self)


class Server(threading.Thread, metaclass=SecondInstanceBan):

    def __init__(self, host: str = "localhost", port: int = 9090, listen: int = 1000):
        """
        Конструктор сервера

        :param host:
        :param port:
        :param listen:
        """

        super(Server, self).__init__()
        self.logger = Logger(host, port)
        self._host = host
        self._port = port
        self._interactive = False
        self._listen = False
        self._show_logs = False
        self._server = socket()
        self._server.setsockopt(SOL_SOCKET, SO_REUSEADDR, 1)
        self._server.bind((host, port))
        self._server.listen(listen)
        self._peers = list()
        self.logger.server_is_running()

    @property
    def interactive(self):
        """
        Создает property interactive

        :return:
        """

        return self._interactive

    @interactive.getter
    def interactive(self):
        """
        Получает значение interactive

        :return:
        """

        return self._interactive

    @interactive.setter
    def interactive(self, value):
        """
        Устанавливает значение interactive

        :param value: True or False
        :return:
        """

        if value is True or value is False:
            self._interactive = value

    def run(self) -> None:
        """
        Срабатывает в момент запуска потока

        :return:
        """

        if self.interactive is True:
            while True or self._listen is True:
                print(f"\nВыберите пункт из меню\n1 - {'Отключить' if self._listen else 'Включить'} "
                      f"прослушивание порта\n2 – "
                      f"{'Не показывать' if self.logger.write_to_console is True else 'Начать показывать'}"
                      f" логи в консоле\n3 - Очистить логи в файле\n4 - Очистить базу\n0 - Выключить сервер")
                answer = input("\nВведите команду: ")
                if answer == "1":
                    if self._listen is True:
                        self._listen = False
                        self.logger.stop_listening_port(self._port)
                    else:
                        self._listen = True
                        self.__start_loop()
                elif answer == "2":
                    if self.logger.write_to_console is False:
                        self.logger.write_to_console = True
                    else:
                        self.logger.write_to_console = False
                elif answer == "3":
                    answer = input("Вы уверены, что хотите очистить логи?\n(y/n) ")
                    if answer.lower() == "y":
                        self.logger.clear_logs()
                        print("Логи успешно очищены")
                elif answer == "4":
                    answer = input("Вы уверены, что хотите очистить базу данных?\n(y/n) ")
                    if answer.lower() == "y":
                        Message.clear_table()
                        User.clear_table()
                elif answer == "0":
                    self.__close()
                else:
                    print("\nНет такой команды. Попробуйте еще раз\n")
                sleep(1)
        else:
            self._listen = True
            self._show_logs = True
            self.__start_loop()

    def exit(self, signum, frame):
        """
        Насильно отключает сервер

        :param signum:
        :param frame:
        :return:
        """

        self.__close(False)
        subprocess.check_output(f"kill -9 {os.getpid()};", shell=True).decode()

    def start_interactive(self) -> None:
        """
        Запускает интерактивный режим

        :return:
        """

        self._interactive = True
        self.start()

    def broadcast(self, client, data) -> None:
        """
        Отправляет сообщения пользователям

        :param client:
        :param data:
        :return:
        """

        for user in self._peers:
            if user is not client:
                user.send(data)

    def peer_remove(self, peer: Peer) -> None:
        """
        Удаляет прослушиваемый сокет из сервера

        :param peer:
        :return:
        """

        self._peers.remove(peer)

    def __start_loop(self) -> None:
        """
        Запускает цикл принимающий новые соединения

        :return:
        """

        server_thread = threading.Thread(target=self.__loop)
        server_thread.setName(f"Server {self._host}:{self._port} loop thread")
        server_thread.start()

    def __loop(self) -> None:
        """
        Цикл принимающий новые соединения

        :return:
        """

        self.logger.start_listening_port(self._port)
        while self._listen is True:
            try:
                user_sock, client = self._server.accept()
            except ConnectionAbortedError:
                break
            peer = Peer(sock_server=self, sock=user_sock, address=client)
            peer.start()
            self._peers.append(peer)
        self.logger.server_is_stopped()

    def __close(self, sys_exit: bool = True) -> None:
        """
        Закрывает все соединения, в том числе и серверверое

        :return:
        """

        for item in self._peers:
            item.close()
        self._server.close()
        if sys_exit is True:
            sys.exit()
