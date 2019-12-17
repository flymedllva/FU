from threading import Thread
from datetime import datetime


class Loger(Thread):
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
        self.file_name = file_name
        self.host = host
        self.port = port
        self.run()

    def write_to_file(self, data: str, file_name: str = None):
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

    def info_log(self, text: str):
        """
        Лог информации

        :param text:
        :return:
        """

        text = f"{self.today()} – INFO – {text}"
        print(self.write_to_file(text))

    def server_is_running(self):
        """
        Запуск сервера

        :return:
        """

        return self.info_log(f"Сервер {self.host}:{self.port} запущен")

    def server_is_stopped(self):
        """
        Остановка сервера

        :return:
        """

        return self.info_log("Сервер остановлен")

    def start_listening_port(self, port):
        """
        Начало прослушивания порта

        :param port:
        :return:
        """

        return self.info_log(f"Запущено пропуслушивание порта {port}")

    def new_connection(self, user: tuple):
        """
        Новое подключение

        :return:
        """

        return self.info_log(f"Пользователь {user[0]}:{user[1]} подключен")

    def connection_closed(self, user: tuple):
        """
        Закрытие соединения

        :return:
        """

        return self.info_log(f'Пользователь {user[0]}:{user[1]} отключился')

    def socket_closed_other_side(self, user):
        """
        Сокет был закрыт другой стороной

        :return:
        """

        return self.info_log(f"Пользователь {user[0]}:{user[1]} попросил попросил закрыть его сокет")

    def send_data(self, user: tuple, data: str):
        """
        Отправка данных сервером

        :param user:
        :param data:
        :return:
        """

        return self.info_log(f"Сервер отправил сообщение «{data}» пользователю {user[0]}:{user[1]}")

    def obtain_data(self, user: tuple, data: str):
        """
        Получение данных

        :param user:
        :param data:
        :return:
        """

        return self.info_log(f"Пользователь {user[0]}:{user[1]} прислал «{data}»")

    @staticmethod
    def today():
        """
        Возвращает текущий день

        :return:
        """

        return datetime.now().strftime("%Y-%m-%d %H:%M:%S")
