import unittest
import socket
import json


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


class MyTestCase(unittest.TestCase):

    def setUp(self):
        self.host = "localhost"
        self.port = 9090
        self.login = "test"
        self.password = "test"
        self.token = ""
        self.socket = socket.socket()
        self.connect_error = False
        try:
            self.socket.connect((self.host, self.port))
            self.socket.send(
                Data(type="authorization", data={"login": self.login, "password": self.password}).to_json())
            data = self.recv()
            if all(item in data for item in ("notice", "data", "type")):
                self.token = data["data"]["token"]
        except ConnectionRefusedError:
            print("Не удалось подключиться к серверу, включите сервер и повторите попытку")
            self.connect_error = True

    def recv(self):
        try:
            while True:
                data = list()
                while True:
                    recv_data = self.socket.recv(4)
                    if recv_data == b"":
                        break
                    data.append(recv_data.decode("utf-8"))
                    try:
                        return json.loads("".join(data))
                    except json.decoder.JSONDecodeError:
                        continue
        except (ConnectionAbortedError, OSError):
            print("Произошла ошибка")

    def test_01_mkdir(self):
        self.socket.send(Data(type="command", data={"command": "mkdir",
                                                    "dir_name": "123",
                                                    "login": self.login,
                                                    "token": self.token}).to_json())
        data = self.recv()
        if (data["notice"] == "Error" and data["data"]["answer"] == "Папка уже существует") or data["notice"] == "OK":
            data = "OK"
        else:
            data = "ERROR"
        self.assertEqual(data, "OK", "mkdir error")

    def test_02_cd(self):
        self.socket.send(Data(type="command", data={"command": "cd",
                                                    "name": "123",
                                                    "login": self.login,
                                                    "token": self.token}).to_json())
        self.assertEqual(self.recv()["notice"], "OK", "cd error")
        self.socket.send(Data(type="command", data={"command": "cd",
                                                    "name": "..",
                                                    "login": self.login,
                                                    "token": self.token}).to_json())
        self.assertEqual(self.recv()["notice"], "OK", "cd error")

    def test_03_ls(self):
        self.socket.send(Data(type="command", data={"command": "ls",
                                                    "login": self.login,
                                                    "token": self.token}).to_json())
        self.assertEqual("OK" if "123" in self.recv()["data"]["answer"] else "ERROR", "OK", "ls error")

    def test_04_rename(self):
        self.socket.send(Data(type="command", data={"command": "rename",
                                                    "name": "123",
                                                    "name_new": "321",
                                                    "login": self.login,
                                                    "token": self.token}).to_json())
        self.assertEqual(self.recv()["notice"], "OK", "rename error")

    def test_04_rm(self):
        self.socket.send(Data(type="command", data={"command": "rm",
                                                    "name": "321",
                                                    "login": self.login,
                                                    "token": self.token}).to_json())
        self.assertEqual(self.recv()["notice"], "OK", "rm error")


if __name__ == '__main__':
    unittest.main()
