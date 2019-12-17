import asyncio
import logging
import os

from datetime import datetime


class HTTPTemplate(object):

    @classmethod
    def identify_type(cls, path: str, supported_formats: tuple = None) -> dict or None:
        """
        Определяет тип файла и возвращает его темплейт или None

        :param path:
        :param supported_formats: для запрета всех форматов пустой словарь
        :return:
        """

        expansion = path.split(".")[-1].upper()

        if supported_formats is None:
            supported_formats = ("HTML", "JPG", "JPEG", "PNG", "ICO", "JSON", "SVG", "SVGZ", "WOFF", "WOFF2", "MP4",
                                 "MP3", "TTF", "JPG", "JPEG", "GIF", "PNG", "ICO", "SH", "AVI", "BIN", "CSS", "CSV",
                                 "EPUB" "ZIP", "RAR", "DOC", "XLS", "PPT", "MID", "MIDI", "WAV", "RTF", "ICS", "JS",
                                 "MPKG", "PDF", "TAR", "XML")

        if any(expansion == item for item in supported_formats):
            with open(path, "rb") as f:
                return HTTPTemplate.use_selected_type(f.read(), type=expansion)
        return None

    @staticmethod
    def use_selected_type(template: any, type: str = None) -> dict:
        """
        Создает темплейт из функции

        :param template:
        :param type: HTML
        :return:
        """

        return dict(site=template, type=type)


class HTTPHandler(asyncio.Protocol):

    __host = None
    __port = None
    __allowed_methods = ["GET"]
    __transport = None
    __method = None
    __url = None
    __type = None
    __code = None
    __headers = None
    __content = None
    __body = None

    def __init__(self, server: 'HTTPServer', loop: asyncio.get_event_loop):
        self.__server = server
        self.__loop = loop

    def connection_made(self, transport: asyncio.selector_events) -> None:
        """
        Обрабатывает подключение

        :param transport:
        :return:
        """

        self.__transport = transport
        self.__host = self.__transport.get_extra_info('peername')[0]
        self.__port = self.__transport.get_extra_info('peername')[1]
        logging.info(f"{self.__host}:{self.__port} - New connection")

    def eof_received(self) -> None:
        """
        Вызывается, когда клиент закрывает соединение

        :return:
        """

        self.__transport.close()
        logging.info(f"{self.__host}:{self.__port} - Сlient closed the connection to the server")

    def connection_lost(self, exc: any) -> None:
        """
        Вызывается, когда сервер закрывает соединение

        :return:
        """

        self.__transport.close()
        logging.info(f"{self.__host}:{self.__port} - Server closed connection peer socket")

    def data_received(self, data: bytes) -> None:
        """
        Принимает данные подключения

        :param data:
        :return:
        """

        data = data.decode()
        self.__loop.create_task(self._generate_and_send_page(data))

    async def _generate_and_send_page(self, data: str):
        """
        Генерирует страницу и отправляет ее клиенту

        :param data:
        :return:
        """

        data = await self.__generate_response(data)

        logging.info(f"{self.__host}:{self.__port} - Data received ({self.__method}: {self.__code}) {self.__url}")

        self.__transport.write(data)

        logging.info(f"{self.__host}:{self.__port} - Data is sent ({len(data)} bytes)")

    async def __generate_response(self, request: str) -> bytes:
        """
        Генерирует ответ

        :param request:
        :return:
        """

        self.__method, self.__url = request.split(" ")[:2]

        # Проверяет на запрос статического хранилища
        if self.__url.startswith(self.__server.static):
            if os.path.isfile(self.__server.path + self.__url):
                self.__content = HTTPTemplate.identify_type(self.__server.path + self.__url,
                                                            supported_formats=self.__server.static_supported_format)
                if self.__content is None:
                    self.__code = 403
            else:
                self.__code = 404
        # Если не смог найти, начинает искать в роутах
        else:
            try:
                # Получает функцию из route для текущей ссылки и получает разрешенные методы
                if server_response := self.__server.check_route(self.__url):
                    # Запускает функцию из route
                    self.__content = server_response["route"]()
                    # Разрешенные методы
                    if "methods" in server_response:
                        self.__allowed_methods = server_response["methods"]
            except Exception as e:
                logging.error(f"{self.__host}:{self.__port} - {e}")

        return await self.__generate_page()

    async def __generate_page(self) -> bytes:
        """
        Генерирует страницу и возращает ее

        :return:
        """

        await self.__generate_code()
        await self.__generate_body()
        await self.__generate_header()

        if isinstance(self.__body, bytes):
            return self.__headers.encode() + self.__body
        return (self.__headers + self.__body).encode()

    async def __generate_code(self) -> None:
        """
        Генерирует код ответа

        :return:
        """

        http_version = "HTTP/1.1"

        if self.__code:
            if self.__code == 403:
                self.__headers = f"{http_version} 403 Forbidden\n"
            elif self.__code == 404:
                self.__headers = f"{http_version} 404 Not found\n"
            elif self.__code == 405:
                self.__headers = f"{http_version} 405 Method not allowed\n"
            elif self.__code == 200:
                self.__headers = f"{http_version} 200 OK\n"
        else:
            if not self.__content:
                self.__headers = f"{http_version} 404 Not found\n"
                self.__code = 404
            elif self.__method not in self.__allowed_methods:
                self.__headers = f"{http_version} 405 Method not allowed\n"
                self.__code = 405
            else:
                self.__headers = f"{http_version} 200 OK\n"
                self.__code = 200

    async def __generate_body(self) -> None:
        """
        Генерирует тело ответа  и определяет тип возвращаемых данных

        :return:
        """

        if self.__code == 403:
            self.__body = "<div><h1>403</h1><p>Forbidden</p></div>"
            self.__type = "HTML"
        elif self.__code == 404 or not self.__content:
            self.__body = "<div><h1>404</h1><p>Not found</p></div>"
            self.__type = "HTML"
        elif self.__code == 405:
            self.__body = "<div><h1>405</h1><p>Method not allowed</p></div>"
            self.__type = "HTML"
            self.__headers += f"Allow: {', '.join(self.__allowed_methods)}\n"
        elif self.__code == 501:
            self.__body = "<div><h1>501</h1><p>Not Implemented</p></div>"
            self.__type = "HTML"
            self.__headers += f"Allow: {', '.join(self.__allowed_methods)}\n"
        else:
            self.__body = self.__content["site"]
            self.__type = self.__content["type"]

    async def __generate_header(self) -> None:
        """
        Генерирует заголовки ответа

        :return:
        """

        self.__headers += f"Server: {self.__server.name}\n"
        self.__headers += f"Date: {self.__server.http_date(datetime.now())}\n"
        self.__headers += "Accept-Charset: utf-8\n"
        self.__headers += f"Content-Length: {len(self.__body)}\n"
        self.__headers += f"Connection: {'keep-alive' if self.__server.keep_alive else 'close'}\n"

        if type := self.__server.check_support_type(self.__type):
            self.__headers += f"Content-Type: {type}"

        self.__headers += "\r\n\r\n"


class HTTPServer(object):

    def __init__(self, host: str = "localhost", port: int = 9000, static: str = "/static",
                 static_supported_format: tuple = None, name: str = "Python3", allowed_methods: list = None,
                 keep_alive: bool = True, debug: bool = True, favicon: str = None):

        logging.basicConfig(
            level=logging.DEBUG if debug is True else logging.INFO,
            format="%(asctime)s | %(levelname)s | %(message)s",
            handlers=[
                logging.FileHandler("server.log"),
                logging.StreamHandler(),
            ],
        )

        if allowed_methods is None:
            allowed_methods = ["GET"]
        self.name = name
        self.host = host
        self.port = port
        self.__keep_alive = keep_alive
        self.__static_supported_format = static_supported_format
        self.__supported_types = dict(HTML="text/html; charset=UTF-8", JSON="application/json", JPG="image/jpeg",
                                      PNG="image/png", ICO="image/x-icon", MP3="audio/mpeg", SVG="image/svg+xml",
                                      WOFF="font/woff", WOFF2="font/woff2", MP4="video/mpeg", TTF="font/ttf",
                                      JPEG="image/jpeg", GIF="image/gif", ZIP="application/zip",
                                      RAR="application/x-rar-compressed", RTF="application/rtf", SH="application/x-sh",
                                      DOC="application/msword", XLS="application/vnd.ms-excel",
                                      PPT="application/vnd.ms-powerpoint", MID="audio/midi", MIDI="audio/midi",
                                      WAV="audio/x-wav", AVI="video/x-msvideo", BIN="application/octet-stream",
                                      CSS="text/css", CSV="text/csv", EPUB="application/epub+zip", ICS="text/calendar",
                                      JS="application/javascript", MPKG="application/vnd.apple.installer+xml",
                                      PDF="application/pdf", TAR="application/x-tar", XML="application/xml")
        self.__allowed_methods = allowed_methods
        self.__static = static
        self.__path = "/".join(os.path.abspath(__file__).split("/")[:-1])
        self.__urls = dict()
        self.__favicon(favicon)
        self.__loop = asyncio.get_event_loop()
        self.__tasks = self.__loop.create_server(lambda: HTTPHandler(self, self.__loop), self.host, self.port)
        self.__server = self.__loop.run_until_complete(self.__tasks)

    @property
    def path(self) -> str:
        """
        Возвращает путь до директории сервера

        :return:
        """

        return self.__path

    @property
    def static(self) -> str:
        """
        Возвращает путь статической директории директории сервера

        :return: /static
        """

        return self.__static

    @property
    def static_path(self) -> str:
        """
        Возвращает путь до статической директории

        :return: /user/test/static
        """

        return self.__path + self.__static

    @property
    def allowed_methods(self) -> list:
        """
        Возвращает разрешенные методы сервера

        :return:
        """

        return self.__allowed_methods

    @property
    def static_supported_format(self) -> tuple:
        """
        Возвращает поддерживаемые форматы сервером в папке static

        :return:
        """

        return self.__static_supported_format

    @property
    def keep_alive(self) -> bool:
        """
        Возвращает сведение о использовании keep_alive

        :return:
        """

        return self.__keep_alive

    def run(self) -> None:
        """
        Запускает сервер

        :return:
        """

        try:
            logging.info(f"Start server on {self.host}:{self.port}")
            self.__loop.run_forever()
        except KeyboardInterrupt:
            pass
        finally:
            self.__server.close()
            self.__loop.run_until_complete(self.__server.wait_closed())
            self.__loop.close()
            logging.info(f"Stop server")

    def route(self, rule, **options) -> 'function':
        """
        Декоратор для роутинга сервера

        :param rule:
        :param options:
        :return:
        """

        def decorator(function):
            self.__urls[rule] = dict(**options, **dict(route=function))
            return function

        return decorator

    def check_route(self, url) -> dict or None:
        """
        Проверяет существование url в route

        :param url:
        :return:
        """

        if url in self.__urls:
            return self.__urls[url]
        return None

    def check_support_type(self, type: str) -> str or None:
        """
        Проверяет поддержку формата у сервера

        :param type:
        :return:
        """

        return self.__supported_types.get(type)

    @staticmethod
    def http_date(dt: datetime) -> str:
        """
        RFC 1123 datetime (HTTP/1.1)

        :param dt:
        :return:
        """

        weekday = ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"][dt.weekday()]
        month = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"][dt.month - 1]
        return "%s, %02d %s %04d %02d:%02d:%02d GMT" % (weekday, dt.day, month, dt.year, dt.hour, dt.minute, dt.second)

    def __favicon(self, path: str) -> bool:
        """
        Устанавливает Favicon

        :return:
        """

        if path and os.path.isfile(self.path + path):
            @self.route("/favicon.ico", methods=["GET"])
            def open_ico() -> dict:
                with open(self.path + path, "rb") as f:
                    return HTTPTemplate.use_selected_type(template=f.read(), type="ICO")

            return True
        return False
