import subprocess
import signal
import json
import sys
import os

from socket import socket, SO_REUSEADDR, SOL_SOCKET, timeout
from server.utils.handlers import RequestHandler
from server.utils.logger import Logger
from server.utils.data import Data
from server.models import Model
from threading import Thread
from config import Config
from time import sleep


class SecondInstanceBan(type):
    _instances = dict()

    def __call__(cls, *args, **kwargs):
        if cls not in cls._instances:
            cls._instances[cls] = super(SecondInstanceBan, cls).__call__(*args, **kwargs)
        signal.signal(signal.SIGTERM, cls._instances[cls].exit)
        signal.signal(signal.SIGINT, cls._instances[cls].exit)
        return cls._instances[cls]


class Peer(Thread):

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
        Получает новые данные и отправляет их на обработку

        :return:
        """

        data = list()
        while True:
            self._sock.settimeout(None)
            try:
                recv_data = self._sock.recv(1024)
            except ConnectionResetError:
                break
            if recv_data == b"":
                break
            try:
                data.append(recv_data.decode("utf-8"))
            except UnicodeDecodeError as error:
                data = list()
                self._server.logger.error_json_serializable(error)
            try:
                recv_data = "".join(data)
                try:
                    data = RequestHandler(json.loads(recv_data)).response()
                    self._server.logger.obtain_data(self._address, recv_data)
                    if isinstance(data, bytes):
                        self.send(data)
                    elif isinstance(data, dict):
                        if data["type"] == "send" and data["data"]["answer"]:
                            url = Config.FILES_DIR + data["data"]["url"] + "/" + data["data"]["answer"]
                            with open(url, 'wb') as f:
                                self._sock.settimeout(1.0)
                                while True:
                                    try:
                                        send_data = self._sock.recv(1024)
                                        if send_data == b'':
                                            break
                                        f.write(send_data)
                                    except timeout:
                                        break
                            f_size = RequestHandler.folder_size("/".join(url.split("/")[:-1])) / 1e+6
                            if f_size > data["data"]["storage"]:
                                try:
                                    os.remove(url)
                                except (FileNotFoundError, OSError):
                                    pass
                                self.send(Data(type="send", data=dict(command="send"),
                                               notice="No disk space").to_json())
                                self._server.logger.get_file_error(data["data"]["answer"])
                            else:
                                self.send(Data(type="send", data=dict(command="send"),
                                               notice="Downloaded").to_json())
                                self._server.logger.get_file(data["data"]["answer"])
                        if data["type"] == "receive" and data["data"]["answer"]:
                            try:
                                with open(Config.FILES_DIR + data["data"]["url"] + "/" + data["data"]["answer"],
                                          'rb') as f:
                                    self._sock.sendall(f.read())
                                self._server.logger.send_file(["answer"])
                            except FileNotFoundError:
                                self._server.logger.error_log(f"Файл {data['data']['answer']} не найден")
                            except (OSError, timeout):
                                self._server.logger.send_file_error(["answer"])
                except TypeError as error:
                    self._server.logger.error_json_serializable(error)
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

        self._sock.sendall(data)
        self._server.logger.send_data(self._address, data)

    def close(self) -> None:
        """
        Закрывает текущее соединение

        :return:
        """

        self._sock.close()
        self._server.peer_remove(self)


class Server(Thread, metaclass=SecondInstanceBan):

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

            self._listen = True
            self.__start_loop()

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
                        Model.clear_table()
                elif answer == "0":
                    self.__close()
                else:
                    print("\nНет такой команды. Попробуйте еще раз\n")
                sleep(1)
        else:
            self._listen = True
            self._show_logs = True
            self.__start_loop()

    def exit(self):
        """
        Насильно отключает сервер

        :return:
        """

        self.__close(False)
        subprocess.check_output(f"kill -9 {os.getpid()};", shell=True)

    def start_interactive(self) -> None:
        """
        Запускает интерактивный режим

        :return:
        """

        self._interactive = True
        self.start()

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

        server_thread = Thread(target=self.__loop)
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
            sys.exit(0)
