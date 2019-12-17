import os
import json
import time

from socket import socket
from threading import Thread
from getpass import getpass
from time import gmtime, strftime
from config import basedir


class Data(object):

    def __init__(self, data: dict, type: str = "message"):
        """
        Конструктор данных

        :param data:
        :param type:
        """

        self.data = data
        self.type = type

    def to_json(self):
        """
        Возвращает данные в виде JSON

        :return:
        """

        return json.dumps(dict(type=self.type, data=self.data)).encode("utf-8")


class Client(socket):

    def __init__(self,
                 host: str = "localhost", port: int = 9090,
                 login: str = None, password: str = None, token: str = None):
        """
        Конструктор клиента

        :param host:
        :param port:
        """

        super(Client, self).__init__()
        self.host = host
        self.port = port
        self.login = login
        self.password = password
        self.token = token
        self.location = "menu_login"
        self.request_status = None
        self.wait_messages = False
        self.connect((self.host, self.port))
        self.open_file()
        try:
            self.listener_thread = Thread(target=self.listener)
            self.listener_thread.start()
            self.main_loop()
        except KeyboardInterrupt:
            self.exit()

    def open_file(self, file_name: str = "user_data.json"):
        """
        Открывает файл
        :param file_name:
        :return:
        """

        try:
            open(basedir + "/" + file_name, 'r')
        except (FileNotFoundError, IOError):
            self.close_file(dict(login=None, token=None))
        with open(basedir + "/" + file_name, 'r', encoding='utf-8') as file_one:
            data = json.load(file_one)
            self.login = data["login"]
            self.token = data["token"]

    def close_file(self, data: dict = None, file_name: str = "user_data.json"):
        """
        Закрывает файл
        :param data:
        :param file_name:
        :return:
        """

        with open(basedir + "/" + file_name, 'w', encoding='utf-8') as file_one:
            json.dump(dict(login=self.login, token=self.token) if data is None else data, file_one, ensure_ascii=False,
                      sort_keys=False, indent=4)

    def menu_chat(self):
        """
        Меню чата

        :return:
        """

        self.console_clear()
        self.wait_messages = True
        self.send(Data(type="get_messages", data={"token": self.token}).to_json())
        time.sleep(0.5)

        print(f"\nВы вошли в чат\nДля выхода напишите exit/q/выход\n")

        data = None
        while data not in ("exit", "q", "выход"):
            if data is not None and data != "":
                self.send(
                    Data(type="message", data={"message": data, "token": self.token, "login": self.login}).to_json())
            data = input("")

        self.location = "menu_main"
        self.wait_messages = False
        getattr(self, self.location)()

    def menu_main(self):
        """
        Главное меню

        :return:
        """

        print(f"{self.login} вам доступны следующие пункты меню:\n 1. Подключиться к серверу\n 2. Выбрать другого "
              f"пользователя\n")

        data = None
        while data is None or data not in ("1", "2"):
            data = input("Выберите пункт меню: ")

        if data == "1":
            self.location = "menu_chat"
            getattr(self, self.location)()
        elif data == "2":
            self.login = None
            self.password = None
            self.token = None
            self.location = "menu_login"
            getattr(self, self.location)()

    def menu_login(self):
        """
        Меню выбора авторизации

        :return:
        """

        self.console_clear()

        if self.token is not None:

            self.send(Data(type="authorization", data={"token": self.token}).to_json())

            while self.request_status is None:
                time.sleep(0.05)
            if self.request_status == "OK":
                self.location = "menu_main"
                self.request_status = None
                getattr(self, self.location)()
            else:
                self.request_status = None
                self.token = None

        print(f"Выбранный сервер для подключения: {self.host}:{self.port}\n1. Авторизация (y)\n2. Регистрация (n)\n")

        choice = input("Выберите пункт меню: ")

        if choice.lower() in (" ", "", "1", "1. авторизация", "авторизация", "y", "(y)"):
            action_type = "authorization"
        else:
            action_type = "registration"

        if self.login is None:
            self.login = input("\nВведите ваш логин: ")
        if self.password is None:
            self.password = getpass("Введите ваш пароль: ")

        self.send(Data(type=action_type, data={"login": self.login, "password": self.password}).to_json())

        while self.request_status is None:
            time.sleep(0.05)

        if not self.request_status == "OK":
            self.location = "menu_login"
        self.request_status = None
        getattr(self, self.location)()

    def main_loop(self):
        """
        Главный цикл

        :return:
        """

        try:
            getattr(self, self.location)()
        except EOFError:
            pass
        finally:
            self.close()

    def listener(self):
        """
        Принимает сообщения сервера

        :return:
        """

        try:
            while True:
                data = self.recv(4096).decode("utf-8")
                self._message_handler(data)
        except (ConnectionAbortedError, OSError):
            pass

    def _message_handler(self, data):
        """
        Обрабатывает сообщения полученные с сервера

        :return:
        """

        try:
            data = json.loads(data)
        except json.decoder.JSONDecodeError:
            data = None

        if data and "type" in data and "data" in data:
            if "notice" in data:
                notice = data["notice"]
            else:
                notice = None
            if data["type"] == "broadcast_message" and self.wait_messages:
                data = data["data"]
                if "login" in data and "message" in data:
                    print(f"{strftime('%H:%M:%S', gmtime())} {data['login']}: {data['message']}")
            elif data["type"] == "get_messages":
                data = data["data"]
                if "login" in data and "message" in data and "date" in data:
                    print(f"{data['date']} {data['login']}: {data['message']}")
            elif data["type"] == "authorization":
                data = data["data"]
                if "token" in data:
                    self.console_clear()
                    if data["token"] is None:
                        print("Авторизация прошла неудачно, попробуйте заново\n")
                        self.login = None
                        self.password = None
                        self.token = None
                        self.location = "menu_login"
                        self.request_status = "ERROR"
                    else:
                        if "login" in data:
                            self.login = data["login"]
                        if "token" in data:
                            self.token = data["token"]
                        if notice == "The user is created":
                            print(f"Вы успешно зарегистрировали пользователя {self.login} и вошли под ним\n")
                        else:
                            print(f"Вы успешно вошли под пользователем {self.login}\n")
                        self.location = "menu_main"
                        self.request_status = "OK"

    def exit(self):
        """
        Выходит из клиента

        :return:
        """

        print("\n\nВаши данные сохранены\nДо свидания!")
        self.close_file()

    @staticmethod
    def console_clear():
        """
        Очищает консоль

        :return:
        """

        os.system('cls' if os.name == 'nt' else 'clear')


if __name__ == '__main__':

    # Если клиенту указать токен/логин and пароль он попробует авторизоваться
    # client = Client(port=9090, token="ef253e56ba9d5030d129d9342840926f")

    client = Client(port=9090)
