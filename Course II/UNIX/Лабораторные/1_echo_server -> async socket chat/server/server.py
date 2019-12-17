import json
import hashlib

from socket import socket, SO_REUSEADDR, SOL_SOCKET
from asyncio import Task, get_event_loop
from server.utils.loger import Loger
from server.models import User, Message
from time import time


class SecondInstanceBan(type):
    """
    Разрешает создавать только 1 экзепляр класса
    """

    _instances = dict()

    def __call__(cls, *args, **kwargs):
        if cls not in cls._instances:
            cls._instances[cls] = super(SecondInstanceBan, cls).__call__(*args, **kwargs)
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


class Peer(object):

    def __init__(self, sock_server: 'Server', sock: socket, address: tuple):
        """
        Конструктор сокета

        :param sock_server:
        :param sock:
        :param address:
        """

        self.loop = sock_server.loop
        self.address = address
        self._sock = sock
        self._server = sock_server
        self.entered = False
        Task(self._peer_handler())

    async def send(self, data: bytes):
        """
        Отправляет данные текущему сокету

        :param data:
        :return:
        """

        await self.loop.sock_sendall(self._sock, data)

    async def _peer_handler(self):
        """
        Получает новые данные для сокета экземпляра текущего класса

        :return:
        """

        try:
            await self._peer_loop()
        except IOError:
            pass
        finally:
            self._server.peer_remove(self)

    async def _peer_loop(self):
        """
        Получает сообщение пользователя

        :return:
        """

        data = list()
        while True:
            recv_data = await self.loop.sock_recv(self._sock, 1024)
            if recv_data == b"":
                break
            data.append(recv_data.decode("utf-8"))
            try:
                recv_data = "".join(data)
                await self._message_handler(json.loads(recv_data))
                self._server.loger.obtain_data(self.address, recv_data)
                data = list()
            except json.decoder.JSONDecodeError:
                continue

    async def _message_handler(self, data):
        """
        Обрабатывает полученные сообщения

        :param data:
        :return:
        """

        if data and "type" in data and "data" in data:
            if data["type"] == "message":
                user_data = self.chat(data["data"])
                await self.send(user_data.to_json())
                if user_data.notice == "OK":
                    messages = data["data"]["message"]
                    for message in [messages[x:x + 256] for x in range(0, len(messages), 256)]:
                        data = ServerData(type="broadcast_message",
                                          data=dict(login=user_data.data["login"],
                                                    message=message),
                                          notice="OK").to_json()
                        await self._server.broadcast(self, data)
            elif data["type"] == "get_messages":
                if "token" in data["data"]:
                    user = User.search_user(token=data["data"]["token"])
                    if user is not None:
                        for i in Message.today_messages():
                            data = ServerData(type="get_messages",
                                              data=dict(message=i.message,
                                                        date=i.date.strftime("%H:%M:%S"),
                                                        login=User.search_user(id=i.user_id).login),
                                              notice="OK").to_json()
                            await self.send(data)
            elif data["type"] == "authorization":
                data = self.authorization(data["data"]).to_json()
                await self.send(data)
            elif data["type"] == "registration":
                data = self.registration(data["data"]).to_json()
                await self.send(data)

    def chat(self, data) -> ServerData or None:
        """
        Чат

        :param data:
        :return:
        """

        if "message" in data and "token" in data and "login" in data:
            user = User.search_user(token=data["token"], login=data["login"])
            if user is not None:
                self.entered = True
                message = data["message"]
                if message is not None and message != "":
                    for message in [message[x:x + 256] for x in range(0, len(message), 256)]:
                        user = user.add_new_message(message)
                return ServerData(type="message", data=dict(login=user.login, token=user.token), notice="OK")
        return ServerData(type="authorization", data=dict(token=None), notice="Wrong login or password")

    def registration(self, data) -> ServerData:
        """
        Регистрация нового пользователя

        :param data:
        :return:
        """

        if "login" in data and "password" in data:
            user = User.search_user(login=data["login"])
            if user:
                return ServerData(type="authorization", data=dict(token=None), notice="User already exists")
            password = hashlib.md5(data["password"].encode()).hexdigest()
            token = self.create_token(password)
            user = User.create_user(login=data["login"], password=password, token=token)
            self.entered = True
            return ServerData(type="authorization", data=dict(token=user.token), notice="The user is created")
        return ServerData(type="authorization", data=dict(token=None), notice="Invalid request")

    def authorization(self, data) -> ServerData:
        """
        Проверяет авторизация пользователя

        :param data:
        :return:
        """

        if "token" in data:
            user = User.search_user(token=data["token"])
            if user is not None:
                if user.token == data["token"]:
                    self.entered = True
                    return ServerData(type="authorization", data=dict(token=user.token, login=user.login), notice="OK")
            return ServerData(type="authorization", data=dict(token=None), notice="Invalid token")
        if "login" in data and "password" in data:
            user = User.search_user(login=data["login"])
            if user:
                if user.login == data["login"] and \
                        user.password == hashlib.md5(data["password"].encode()).hexdigest():
                    user = user.update_user(data=dict(token=self.create_token(user.password)))
                    self.entered = True
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


class Server(metaclass=SecondInstanceBan):

    def __init__(self, host: str = "localhost", port: int = 9090, listen: int = 1000):
        """
        Конструктор сервера

        :param host:
        :param port:
        :param listen:
        """

        self.loop = get_event_loop()
        self.loger = Loger(host, port)
        self._server_sock = socket()
        self._server_sock.setblocking(False)
        self._server_sock.setsockopt(SOL_SOCKET, SO_REUSEADDR, 1)
        self._server_sock.bind((host, port))
        self._server_sock.listen(listen)
        self._users = list()
        Task(self._server())
        self.loger.server_is_running()
        try:
            self.loop.run_forever()
        except KeyboardInterrupt:
            self.loger.server_is_stopped()

    def peer_remove(self, peer: Peer):
        """
        Удаляет прослушиваемый сокет из сервера

        :param peer:
        :return:
        """

        self._users.remove(peer)
        self.loger.connection_closed(peer.address)

    async def broadcast(self, client, data):
        """
        Отправляет сообщения пользователям

        :param client:
        :param data:
        :return:
        """

        for user in self._users:
            if user is not client and user.entered is True:
                await user.send(data)

    async def _server(self):
        """
        Принимает новые соединения с серверного сокета

        :return:
        """

        while True:
            user_sock, client = await self.loop.sock_accept(self._server_sock)
            user_sock.setblocking(False)
            user = Peer(self, user_sock, client)
            self._users.append(user)
            self.loger.new_connection(user.address)


class Ports(socket):

    def __init__(self, host: str = "localhost", min_port: int = 9090, max_port: int = 9100):
        """
        Конструктор проверки портов

        :param host:
        :param min_port:
        :param max_port:
        """
        super(Ports, self).__init__()
        self.host = host
        self.min_port = min_port
        self.max_port = max_port
        self.free_port = self.__free_port()

    def select_port(self):
        """
        Выбор свободного порта

        :return:
        """

        port = self.free_port
        if port is None:
            while True:
                port = input("Не нашли свободный порт в заданном диапазоне\nВведите порт, который требуется запустить "
                             "насильно: ")
                if port.isdigit():
                    port = int(port)
                    if 1 <= port <= 65535:
                        return port
        else:
            return port

    def __free_port(self):
        """
        Ищет свободный порт в заданном диапазоне

        :return:
        """

        for port in range(self.min_port, self.max_port):
            try:
                self.bind((self.host, port))
                self.close()
                return port
            except OSError:
                pass
        return None


if __name__ == '__main__':
    server = Server(port=9090)
    # server = Server(port=Ports().select_port())
