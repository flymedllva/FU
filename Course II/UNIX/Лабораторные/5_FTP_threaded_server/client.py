import os
import json
import time

from socket import socket, timeout
from getpass import getpass
from config import Config


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
        try:
            self.connect((self.host, self.port))
        except ConnectionRefusedError:
            exit(print(f"Не удалось подключиться к серверу {self.host}:{self.port}\nВозможно он выключен"))
        self.__open_file()
        try:
            self.loop()
        except KeyboardInterrupt:
            self._exit()

    def loop(self) -> None:
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

    def change_menu(self, menu: str = "menu_main") -> None:
        """
        Изменяет меню пользователя

        :param menu:
        :return:
        """

        self.location = menu
        getattr(self, self.location)()

    def __open_file(self, file_name: str = "client_data.json")-> None:
        """
        Открывает файл с данными сессии
        В случае отсуствия создает его

        :param file_name:
        :return:
        """

        try:
            open(Config.BASE_DIR + "/" + file_name, 'r')
        except (FileNotFoundError, IOError):
            self.__close_file(dict(login=None, token=None))
        with open(Config.BASE_DIR + "/" + file_name, 'r', encoding='utf-8') as file_one:
            data = json.load(file_one)
            self.login = data["login"]
            self.token = data["token"]

    def __close_file(self, data: dict = None, file_name: str = "client_data.json") -> None:
        """
        Закрывает файл с данными сессии

        :param data:
        :param file_name:
        :return:
        """

        with open(Config.BASE_DIR + "/" + file_name, 'w', encoding='utf-8') as file_one:
            json.dump(dict(login=self.login, token=self.token) if data is None else data, file_one, ensure_ascii=False,
                      sort_keys=False, indent=4)

    def _ls(self) -> None:
        """
        ls - Запрос показывает файлы пользователя в текущей папке

        :return:
        """

        self.console_clear()
        self.__send_request(Data(type="command", data={"command": "ls",
                                                       "login": self.login,
                                                       "token": self.token}).to_json())
        self.change_menu()

    def _cd(self) -> None:
        """
        cd - Запрос перебрасывает переводит в другую папку

        :return:
        """

        self.console_clear()

        dir_name = input("Введите название папки, в которую требуется перейти ('..' назад): ")

        self.__send_request(Data(type="command", data={"command": "cd",
                                                       "name": dir_name,
                                                       "login": self.login,
                                                       "token": self.token}).to_json())
        self.change_menu()

    def _mkdir(self) -> None:
        """
        mkdir - Запрос создает папку

        :return:
        """

        self.console_clear()
        dir_name = input("Введите название папки, которую требуется создать: ")

        self.__send_request(Data(type="command", data={"command": "mkdir",
                                                       "dir_name": dir_name,
                                                       "login": self.login,
                                                       "token": self.token}).to_json())
        self.change_menu()

    def _rm(self) -> None:
        """
        rm - Запрос удаляет папку или файл

        :return:
        """

        self.console_clear()

        print("– Внимание! Удаление папки рекурсивное (удалятся подпапки и файлы) –\n")
        name = input("Введите название файла/папки который/которую нужно удалить: ")
        if name != "":
            self.__send_request(Data(type="command", data={"command": "rm",
                                                           "name": name,
                                                           "login": self.login,
                                                           "token": self.token}).to_json())
        else:
            print("Нельзя удалить пустую папку")
        self.change_menu()

    def _rename(self) -> None:
        """
        rename - Запрос переименовывает папку или файл

        :return:
        """

        self.console_clear()

        name = input("Введите название файла/папки который/которую нужно переименовать: ")
        name_new = input("Введите новое название: ")
        self.__send_request(Data(type="command", data={"command": "rename",
                                                       "name": name,
                                                       "name_new": name_new,
                                                       "login": self.login,
                                                       "token": self.token}).to_json())
        self.change_menu()

    def _send(self) -> None:
        """
        send - Запрос получающий или отправляющий файл

        :return:
        """

        self.console_clear()

        print("Выбери то, что ты хочешь сделать\n\n1. (s) Отправить файл на сервер\n2. (r) Получить файл с сервера")
        data = None
        while data is None or data not in ("s", "r", "1", "2"):
            data = input("\nВыберите пункт меню: ")
        if data == "1" or data == "s":
            name = input("Напишите название файла, который требуется отправить: ")
            try:
                with open(name, "rb") as f:
                    self.send(Data(type="send", data={"command": "send", "file": name,
                                                      "login": self.login, "token": self.token}).to_json())
                    self.sendall(f.read())
            except FileNotFoundError:
                print("Файл не найден")
            except BrokenPipeError:
                print("Ошибка соединения с сервером")
            except OSError:
                print("Произошла неизвестная ошибка")
            else:
                print("\nФайл отправлен ", end="")
                self.__listener()
        else:
            name = input("Напишите название файла, который требуется получить с сервера: ")
            with open(name, 'wb') as f:
                self.send(Data(type="receive", data={"command": "send", "file": name,
                                                     "login": self.login, "token": self.token}).to_json())
                self.settimeout(1.0)
                while True:
                    try:
                        data = self.recv(1024)
                        if data == b"":
                            break
                        f.write(data)
                    except timeout:
                        break
                self.settimeout(None)
        self.change_menu()

    def menu_main(self):
        """
        Главное меню

        :return:
        """

        print(f"{self.login} вам доступны следующие пункты меню:\n"
              f"1. {'(ls)':>8} Посмотреть содержимое текущей папки\n"
              f"2. {'(cd)':>8} Перейти к другой папке\n"
              f"3. {'(mkdir)':>8} Создать папку\n"
              f"4. {'(rm)':>8} Удалить папку или файл\n"
              f"5. {'(rename)':>8} Переименовать папку или файл\n"
              f"6. {'(send)':>8} Копирование файлов (с сервера/на сервер)\n"
              f"9. {'(logout)':>8} Выйти из аккаунта\n"
              f"0. {'(exit)':>8} Выход из программы"
              )

        data = None
        while data is None or data not in ("0", "exit", "1", "ls", "2", "cd", "3", "mkdir", "4", "rm", "5", "rename",
                                           "6", "send", "9", "logout"):
            data = input("\nВыберите пункт меню: ")

        if data == "1" or data == "ls":
            self.change_menu("_ls")
        elif data == "2" or data == "cd":
            self.change_menu("_cd")
        elif data == "3" or data == "mkdir":
            self.change_menu("_mkdir")
        elif data == "4" or data == "rm":
            self.change_menu("_rm")
        elif data == "5" or data == "rename":
            self.change_menu("_rename")
        elif data == "6" or data == "send":
            self.change_menu("_send")
        elif data == "9" or data == "logout":
            self.login = None
            self.password = None
            self.token = None
            self.change_menu("menu_login")
        elif data == "0" or data == "exit":
            raise KeyboardInterrupt

    def menu_login(self):
        """
        Меню выбора авторизации

        :return:
        """

        self.console_clear()

        if self.token is not None:

            self.__send_request(Data(type="authorization", data={"token": self.token}).to_json())

            while self.request_status is None:
                time.sleep(0.05)
            if self.request_status == "OK":
                self.change_menu()
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

        self.__send_request(Data(type=action_type, data={"login": self.login, "password": self.password}).to_json())
        while self.request_status is None:
            time.sleep(0.05)

        if not self.request_status == "OK":
            self.location = "menu_login"
        self.change_menu(self.location)

    def __send_request(self, data) -> None:
        """
        Отправляет данные серверу и принимает новые используя JSON декодер

        :param data:
        :return:
        """

        self.send(data)
        return self.__listener()

    def __listener(self) -> None:
        """
        Принимает сообщения сервера

        :return:
        """

        try:
            while True:
                data = list()
                while True:
                    recv_data = self.recv(16)
                    if recv_data == b"":
                        break
                    data.append(recv_data.decode("utf-8"))
                    try:
                        return self.__message_handler(json.loads("".join(data)))
                    except json.decoder.JSONDecodeError:
                        continue
        except (ConnectionAbortedError, OSError):
            print("Произошла ошибка")

    def __message_handler(self, data) -> None:
        """
        Обрабатывает сообщения полученные с сервера

        :return:
        """

        if data and "type" in data and "data" in data:
            if "notice" in data:
                notice = data["notice"]
            else:
                notice = None
            if data["type"] == "authorization":
                data = data["data"]
                if "token" in data:
                    self.console_clear()
                    if data["token"] is None or notice == "User already exists":
                        self.login = None
                        self.password = None
                        self.token = None
                        self.location = "menu_login"
                        self.request_status = "ERROR"
                        print("Авторизация прошла неудачно, попробуйте заново\n")
                    else:
                        if "login" in data:
                            self.login = data["login"]
                        if "token" in data:
                            self.token = data["token"]
                        if notice == "The user is created":
                            print(f'Вы успешно зарегистрировали пользователя "{self.login}" и вошли под ним\n')
                        else:
                            print(f'Вы успешно вошли под пользователем "{self.login}"\n')
                        self.location = "menu_main"
                        self.request_status = "OK"
            elif data["type"] == "command":
                data = data["data"]
                command = data["command"]
                print("")
                if command == "ls":
                    print("Файлы текущей директории: ")
                    [print(f"{i + 1} - {item}") for i, item in enumerate(sorted(data["answer"]))]
                elif command == "cd":
                    if "answer" in data and notice:
                        if notice == "OK" and data["answer"] == "":
                            print(f"Вы перешли к папке, содержащей пользовательские все папки")
                        if notice == "OK" and data["answer"] != "":
                            print(f"Вы перешли к папке '{data['answer']}'")
                        elif notice == "Current folder":
                            print("Вы остались в текущей папке")
                        elif notice == "Permission error":
                            print("Недостаточно прав")
                        elif notice == "Not found":
                            print("Папка не найдена")
                elif command == "mkdir":
                    if "answer" in data and notice:
                        if notice == "OK":
                            print(f"Папка {data['answer']} успешно создалась")
                        elif notice == "Error":
                            if data['answer'] == "Папка уже существует":
                                print("Такая папка уже существует")
                            else:
                                print(f"При создании папки возникла ошибка '{data['answer']}'")
                elif command == "rm":
                    if "answer" in data and notice:
                        if notice == "Home directory":
                            print("Нельзя удалить домашную папку")
                        elif notice == "OK":
                            print(f"{data['answer']} удален")
                        elif notice == "Not found":
                            print(f"Не удалось удалить, так как '{data['answer']}' не найден")
                elif command == "rename":
                    if "answer" in data and notice:
                        if notice == "OK":
                            print(f"Файл переименован в {data['answer']}")
                        elif notice == "Not found":
                            print(f"Не удалось удалить, так как '{data['answer']}' не найден")
                print("")
            elif data["type"] == "send":
                if notice == "Downloaded":
                    print("-> (OK) Успешно")
                elif notice == "No disk space":
                    print("-> (ERROR) Нет места на диске")
                else:
                    print("-> (ERROR) Произошла ошибка")
                print("")

    def _exit(self) -> None:
        """
        Выходит из клиента

        :return:
        """

        print("\nВаши данные сохранены\nДо свидания!")
        self.__close_file()

    @staticmethod
    def console_clear() -> None:
        """
        Очищает консоль

        :return:
        """

        os.system('cls' if os.name == 'nt' else 'clear')
        pass


if __name__ == '__main__':
    client = Client(port=9090)
