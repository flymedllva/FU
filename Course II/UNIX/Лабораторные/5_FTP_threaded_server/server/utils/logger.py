import os

from threading import Thread
from datetime import datetime
from config import Config


class Logger(Thread):
    """
    Логер в отдельном потоке
    """

    def __init__(self, host: str, port: int, file_name: str = "logs.log"):
        """
        Конструктор логера

        :param file_name:
        :param host:
        :param port:
        """

        Thread.__init__(self)
        self.write_to_console = True
        self.file_name = file_name
        self.host = host
        self.port = port
        self.start()

    @property
    def write_to_console(self):
        """
        Создает property interactive

        :return:
        """

        return self._write_to_console

    @write_to_console.getter
    def write_to_console(self):
        """
        Получает значение interactive

        :return:
        """

        return self._write_to_console

    @write_to_console.setter
    def write_to_console(self, value):
        """
        Устанавливает значение interactive

        :param value: True or False
        :return:
        """

        if value is True or value is False:
            self._write_to_console = value

    def clear_logs(self, file_name: str = None) -> None:
        """
        Очищает файл с логами

        :return:
        """

        if file_name is None:
            file_name = self.file_name

        with open(file_name, "w", encoding="utf-8") as file_one:
            print("", file=file_one)

    def write_to_file(self, data: str, file_name: str = None) -> str:
        """
        Пишет данные в файл

        :param data:
        :param file_name:
        :return:
        """

        if file_name is None:
            file_name = self.file_name

        with open(file_name, "a", encoding="utf-8") as file_one:
            print(data, file=file_one)

        return data

    def run(self):
        """
        Срабатывает автоматический при запуске логера

        :return:
        """

        return self.info_log("Логер запущен")

    def error_log(self, text: str) -> None:
        """
        Лог ошибок

        :param text:
        :return:
        """

        os.chdir(Config.BASE_DIR)

        text = f"{self.today()} – ERROR – {text}"

        data = self.write_to_file(text)
        if self._write_to_console is True:
            print(data)

    def info_log(self, text: str) -> None:
        """
        Лог информации

        :param text:
        :return:
        """

        os.chdir(Config.BASE_DIR)

        text = f"{self.today()} – INFO – {text}"

        data = self.write_to_file(text)
        if self._write_to_console is True:
            print(data)

    def error_json_serializable(self, error) -> None:
        """
        Ошибка серилизации JSON

        :return:
        """

        return self.error_log(f"Ошибка серилизации JSON: {error}")

    def server_is_running(self) -> None:
        """
        Запуск сервера

        :return:
        """

        return self.info_log(f"Сервер {self.host}:{self.port} запущен")

    def server_is_stopped(self) -> None:
        """
        Остановка сервера

        :return:
        """

        return self.info_log("Сервер остановлен")

    def get_file(self, get_file) -> None:
        """
        Получение файла сервером

        :param get_file:
        :return:
        """

        return self.info_log(f"Сервер получил файл {get_file}")

    def get_file_error(self, get_file) -> None:
        """
        Ошибка получение файла сервером

        :param get_file:
        :return:
        """

        return self.error_log(f"Сервер не смог получить файл {get_file}")

    def send_file(self, get_file) -> None:
        """
        Отправка файла сервером

        :param get_file:
        :return:
        """

        return self.info_log(f"Сервер отправил файл {get_file}")

    def send_file_error(self, get_file) -> None:
        """
        Ошибка отправки файла сервером

        :param get_file:
        :return:
        """

        return self.error_log(f"Сервер не смог отправить файл {get_file}")

    def start_listening_port(self, port) -> None:
        """
        Начало прослушивания порта

        :param port:
        :return:
        """

        return self.info_log(f"Запущено прослушивание порта {port}")

    def stop_listening_port(self, port) -> None:
        """
        Остановка прослушивания порта

        :param port:
        :return:
        """

        return self.info_log(f"Прослушивание порта {port} приостановлено")

    def new_connection(self, user: tuple) -> None:
        """
        Новое подключение

        :return:
        """

        return self.info_log(f"Пользователь {user[0]}:{user[1]} подключен")

    def connection_closed(self, user: tuple) -> None:
        """
        Закрытие соединения

        :return:
        """

        return self.info_log(f'Пользователь {user[0]}:{user[1]} отключился')

    def send_data(self, user: tuple, data: str or bytes) -> None:
        """
        Отправка данных сервером

        :param user:
        :param data:
        :return:
        """

        return self.info_log(f"Сервер отправил сообщение «{data}» пользователю {user[0]}:{user[1]}")

    def obtain_data(self, user: tuple, data: str) -> None:
        """
        Получение данных

        :param user:
        :param data:
        :return:
        """

        return self.info_log(f"Пользователь {user[0]}:{user[1]} прислал «{data}»")

    @staticmethod
    def today() -> datetime.today:
        """
        Возвращает текущий день

        :return:
        """

        return datetime.now().strftime("%Y-%m-%d %H:%M:%S")
