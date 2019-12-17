import hashlib
import shutil
import os

from server.utils.data import Data
from server.models import Model
from config import Config


class RequestHandler(object):

    def __init__(self, data: dict):
        """
        Конструтор обработчика запросов

        :param data:
        """

        self.__data = data

    def response(self) -> bytes or None:
        """
        Генерирует ответ для сервера

        :return:
        """

        if self.__data and isinstance(self.__data, dict) and all(item in self.__data for item in ("type", "data")):
            data = self.__data
            if data["type"] == "command":
                return self.__commands(data["data"]).to_json()
            elif data["type"] == "send":
                if "file" in data["data"]:
                    user = Model.search_user(login=data["data"]["login"], token=data["data"]["token"])
                    return Data(type="send", data=dict(command="send", answer=data["data"]["file"],
                                                       url=user.current_directory, storage=user.max_storage_size),
                                notice="OK").to_dict()
            elif data["type"] == "receive":
                if "file" in data["data"]:
                    user = Model.search_user(login=data["data"]["login"], token=data["data"]["token"])
                    return Data(type="receive", data=dict(command="receive", answer=data["data"]["file"],
                                                       url=user.current_directory, storage=user.max_storage_size),
                                notice="OK").to_dict()
            elif data["type"] == "authorization":
                return self.__authorization(data["data"]).to_json()
            elif data["type"] == "registration":
                return self.__registration(data["data"]).to_json()
        return None

    @classmethod
    def folder_size(cls, path: str, total: int = 0) -> int:
        """
        Вычисляет размер папки с учетом содержимого (рекурсивно)

        :param path:
        :param total:
        :return:
        """

        for entry in os.scandir(path):
            if entry.is_file():
                total += entry.stat().st_size
            elif entry.is_dir():
                total += cls.folder_size(entry.path)
        return total

    @staticmethod
    def __commands(data) -> Data:
        """
        Обработчик команд

        :param data:
        :return:
        """

        if all(item in data for item in ("token", "command", "login")):
            user = Model.search_user(login=data["login"], token=data["token"])
            if user:
                command = data["command"]
                if command == "ls":
                    try:
                        data = os.listdir(user.directory)
                    except FileNotFoundError:
                        return Data(type="command", data=dict(command="ls", answer=[]), notice="Not found")
                    return Data(type="command", data=dict(command="ls", answer=data), notice="OK")
                elif command == "cd":
                    if "name" in data:
                        default_directory = Config.FILES_DIR + user.custom_directory
                        if data["name"] == ".":
                            return Data(type="command", data=dict(command="cd", answer=data["name"]),
                                        notice="Current folder")
                        new_directory = user.directory + "/" + data["name"]
                        try:
                            os.chdir(new_directory)
                        except (FileNotFoundError, NotADirectoryError):
                            return Data(type="command", data=dict(command="cd", answer=data["name"]),
                                        notice="Not found")
                        new_directory = os.getcwd()
                        n_d = "/".join(new_directory.split("/")[len(default_directory.split("/")[:-1]):])
                        if new_directory.find(Config.FILES_DIR if user.role == "admin" else default_directory) == 0:
                            user.update_user(data=dict(current_directory="/" + n_d))
                            return Data(type="command", data=dict(command="cd", answer=n_d), notice="OK")
                        return Data(type="command", data=dict(command="cd", answer=data["name"]),
                                    notice="Not found")
                elif command == "mkdir":
                    if "dir_name" in data:
                        try:
                            os.makedirs(user.directory + "/" + data["dir_name"])
                        except FileExistsError:
                            return Data(type="command", data=dict(command="mkdir", answer="Папка уже существует"),
                                        notice="Error")
                        except OSError:
                            return Data(type="command",
                                        data=dict(command="mkdir", answer="Название файла слишком длинное"),
                                        notice="Error")
                        except Exception:
                            return Data(type="command", data=dict(command="mkdir", answer="Неизвестная ошибка"),
                                        notice="Error")
                        return Data(type="command", data=dict(command="mkdir", answer=data["dir_name"]), notice="OK")
                elif command == "rm":
                    if "name" in data:
                        directory = user.directory + "/" + data["name"]
                        if os.path.isfile(directory):
                            os.remove(directory)
                        elif os.path.isdir(directory):
                            if directory == Config.FILES_DIR + user.custom_directory + "/":
                                return Data(type="command", data=dict(command="cd", answer=data["name"]),
                                            notice="Home directory")
                            shutil.rmtree(directory, ignore_errors=True)
                        else:
                            return Data(type="command", data=dict(command="rm", answer=data["name"]),
                                        notice="Not found")
                        return Data(type="command", data=dict(command="rm", answer=data["name"]), notice="OK")
                elif command == "rename":
                    if all(item in data for item in ("name_new", "name")):
                        try:
                            os.rename(user.directory + "/" + data["name"], user.directory + "/" + data["name_new"])
                        except FileNotFoundError:
                            return Data(type="command", data=dict(command="rename", answer=data["name"]),
                                        notice="Not found")
                        return Data(type="command", data=dict(command="rename", answer=data["name_new"]), notice="OK")
            return Data(type="authorization", data=dict(token=None), notice="The user is not found")
        else:
            return Data(type="authorization", data=dict(token=None), notice="Invalid request")

    @staticmethod
    def __registration(data) -> Data:
        """
        Регистрация нового пользователя

        :param data:
        :return:
        """

        if "login" in data and "password" in data:
            user = Model.search_user(login=data["login"])
            if user:
                return Data(type="authorization", data=dict(token=None), notice="User already exists")
            user = Model.create_user(login=data["login"], password=data["password"])
            return Data(type="authorization", data=dict(token=user.token), notice="The user is created")
        return Data(type="authorization", data=dict(token=None), notice="Invalid request")

    @staticmethod
    def __authorization(data) -> Data:
        """
        Проверяет авторизация пользователя

        :param data:
        :return:
        """

        if "token" in data:
            user = Model.search_user(token=data["token"])
            if user is not None:
                if user.token == data["token"]:
                    return Data(type="authorization", data=dict(token=user.token, login=user.login), notice="OK")
            return Data(type="authorization", data=dict(token=None), notice="Invalid token")
        if "login" in data and "password" in data:
            user = Model.search_user(login=data["login"])
            if user:
                if user.login == data["login"] and \
                        user.password == hashlib.md5((data["password"] + Config.SERVER_SECRET).encode()).hexdigest():
                    user = user.update_user(data=dict(token=Model.create_token(user.password)))
                    return Data(type="authorization", data=dict(token=user.token, login=user.login), notice="OK")
                else:
                    return Data(type="authorization", data=dict(token=None), notice="Wrong login or password")
            else:
                return Data(type="authorization", data=dict(token=None), notice="The user is not found")
        return Data(type="authorization", data=dict(token=None), notice="Invalid request")
