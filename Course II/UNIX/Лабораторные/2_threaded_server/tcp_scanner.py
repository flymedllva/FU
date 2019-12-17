import os
import subprocess
import socket
import time

from threading import Thread
from multiprocessing.dummy import Pool as ThreadPool


class ProgressBar:

    def __init__(self, steps: int = 10, bar_length: int = 40):
        """
        Конструктор Progress Bar

        :param steps: кол-во шагов
        :param bar_length: длина в консоле
        """

        self.steps = steps
        self.bar_length = bar_length
        self.prefix = ""
        self.suffix_text = ""
        self.progress_char = "█"
        self.fill_char = "░"
        self.__timer = None
        self.__completed = False
        self.__animation = self.spinning()

    def calculate(self, current_value: int):
        """
        Пересчитывает progress bar

        :param current_value: значение прогрес бара
        :return:
        """

        if self.__timer is None:
            self.__timer = time.time()

        one_percent = current_value / float(self.steps)

        progress = f"{self.progress_char * int(one_percent * self.bar_length):{self.fill_char}{'<'}{self.bar_length}}"

        percent = f"{100 * one_percent:.1f}"

        progress_bar = f"{self.prefix}: {current_value}/{self.steps} " \
                       f"{next(self.__animation)} |{progress}| {percent}% {self.suffix_text}"

        print(progress_bar, end='\r')

        if current_value >= self.steps:
            self.complete()
            return

    def complete(self):
        """
        Выполняется в случае, когда ProgressBar достих 100%

        :return:
        """

        if not self.__completed:
            print()
            print(f"Завершено за {time.time() - self.__timer:.2f} секунду")
            self.__timer = None
            self.__completed = True

    @staticmethod
    def spinning():
        """
        Анимация

        :return:
        """

        while True:
            yield "/"
            yield "-"
            yield "\\"
            yield "|"


class PortScanner(Thread):

    def __init__(self, start_port: int = 1, end_port: int = 65535, host: str = "localhost",
                 use_pool: bool = False, thread_posix_delay: float = 0.001, pool_len: int = 2):
        """
        Порт сканер
        """

        super(PortScanner, self).__init__()

        self.start_port = start_port
        self.end_port = end_port + 1
        self.count = self.__calculate_count()
        self.host = host
        self.progress = 0
        self.progress_bar = ProgressBar(self.count)
        self.progress_bar.prefix = "Cканирование портов"
        self.is_scan = dict()
        self.__completed = False
        self.__use_pool = use_pool
        self.__thread_posix_delay = thread_posix_delay
        self.__pool_len = pool_len

    def start_interactive(self) -> None:
        """
        Запускает сервер в интерактивном режиме

        :return:
        """

        print(f"Текущий промежуток сканирования портов: {self.start_port}-{self.end_port}\n"
              f"Изменить его?\n1 - Да\n2 - Нет")
        answer = input("Выбор (1/2): ")
        if answer == "1":
            while True:
                try:
                    answer = int(input("Введите номер порта, с которого начинать сканировать: "))
                    if answer > 65535 or answer < 1:
                        raise ValueError
                    self.start_port = answer
                    break
                except ValueError:
                    print("Неправильное значение, попробуйте еще раз")
            while True:
                try:
                    answer = int(input(f"Введите номер порта, до которого нужно сканировать "
                                       f"(больше начального {self.start_port}): "))
                    if answer > 65535 or answer <= self.start_port:
                        raise ValueError
                    self.end_port = answer + 1
                    break
                except ValueError:
                    print("Неправильное значение, попробуйте еще раз\n")
        print(f"Промежуток сканирования портов изменен на {self.start_port}-{self.end_port}")
        self.count = self.__calculate_count()
        prefix = self.progress_bar.prefix
        self.progress_bar = ProgressBar(self.count)
        self.progress_bar.prefix = prefix

        print("\n\nВыберите способ запуска сервера\n1 - Максимальное количество потоков"
              "\n2 - Ограничить создание потоков с помощью Pool из Multiprocessing")
        answer = input("Выбор (1 - Да, 2 - Нет): ")

        if answer == "1":
            self.__use_pool = False
            if os.name != "posix":
                self.__thread_posix_delay = 0
            elif os.name == "posix":
                answer = input("\n\nИспользовать задержку при создании потоков?\nОтвет (1 - Да, 2 - Нет): ")
                if answer == "1":
                    print("\n\nВведите задержку между созданиями потоков\nНапример: '0.1'\n"
                          f"Текущая: '{self.__thread_posix_delay}'")
                    answer = float(input("Выбор: "))
                    if isinstance(answer, float):
                        self.__thread_posix_delay = answer
                else:
                    self.__thread_posix_delay = 0
            print(f"\n\nУстановлена задержка между созданиями потоков: {self.__thread_posix_delay}")
        else:
            self.__use_pool = True
            print(f"\n\nВведите размер Pool или 'CPU' для подстановки кол-во ядер процессора\n"
                  f"Текущий размер Pool: {self.__pool_len}\n(Запускает {self.__pool_len} "
                  f"потока и ждет их выполения до запуска следующих)\nСлишком большее значение приведет к ошибке\n"
                  f"Советую ставить по кол-ву ядер")
            try:
                answer = input("Выбор: ")
                self.__pool_len = int(answer)
            except ValueError:
                if answer.lower() == "cpu":
                    self.__pool_len = os.cpu_count()
            print(f"Установленный размер Pool: {self.__pool_len}")

        if os.name == "posix":
            try:
                u_limit = subprocess.check_output("ulimit -n 10000;ulimit -n;", shell=True).decode()
                print(f'Лимит файловых дескрипторов: {u_limit}')
            except Exception:
                pass

        while True:
            answer = input("Запустить? (1 или y): ")
            if answer == "1" or answer.lower() == "y":
                break

        os.system('cls' if os.name == 'nt' else 'clear')
        self.run()

    def run(self) -> None:
        """
        Срабатывает при запуске сканера

        :return:
        """

        self.is_scan = dict()

        progress_bar = Thread(target=self.__progress_bar)
        progress_bar.start()

        if self.__use_pool is True:
            pool = ThreadPool(self.__pool_len)
            pool.map(self.scanner, range(self.start_port, self.end_port))
            pool.close()
            pool.join()
        else:
            if os.name == "posix":
                for i in range(self.start_port, self.end_port):
                    time.sleep(self.__thread_posix_delay)
                    th = Thread(target=self.scanner, args=(i,))
                    th.start()
            else:
                threads = list()
                for i in range(self.start_port, self.end_port):
                    threads.append(Thread(target=self.scanner, args=(i,)))
                for i in threads:
                    i.start()
                for i in threads:
                    i.join()

    def __calculate_count(self) -> int:
        """
        Пересчитывает максимальное значение

        :return:
        """

        return self.end_port - self.start_port

    def __progress_bar(self):
        """
        Обновляет состояние progress_bar

        :return:
        """

        while self.progress < self.count:
            time.sleep(0.01)
            self.progress_bar.calculate(self.progress)

        for item in sorted(self.is_scan.items(), key=lambda x: x[0]):
            if item[1] is True:
                print(f"Порт {item[0]} открыт")

    def scanner(self, port: int):
        """
        Проверяет порт

        :param port:
        :return:
        """

        try:
            sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            if self.host == "localhost" or self.host == "127.0.0.1":
                sock.settimeout(0.1)
            else:
                sock.settimeout(1)
        except OSError:
            scanner = Thread(target=self.scanner, args=(port,))
            scanner.start()
            return
        try:
            sock.connect((self.host, port))
            self.is_scan[port] = True
        except OSError:
            self.is_scan[port] = False
        sock.close()
        self.progress += 1


if __name__ == '__main__':
    # Для запуска без интерактивности
    # port_scanner = PortScanner(start_port=9000, end_port=10000, use_pool=True)
    # port_scanner = PortScanner(start_port=5000, end_port=20000)
    # port_scanner = PortScanner(start_port=1, end_port=2000)
    # port_scanner.start()

    port_scanner = PortScanner()
    port_scanner.start_interactive()
