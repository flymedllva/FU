import os


class Config(object):
    SERVER_SECRET = "UNIX"
    SERVER_HOST = "localhost"
    SERVER_PORT = 9090
    BASE_DIR = os.path.abspath(os.path.dirname(__file__))
    FILES_DIR = BASE_DIR + "/files"
    DATABASE_FILE_NAME = "server.db"
    DATABASE_URI = 'sqlite:///' + os.path.join(BASE_DIR, 'server.db')


class Admin(object):
    LOGIN = "admin"
    PASSWORD = "admin"


class Tester(object):
    LOGIN = "test"
    PASSWORD = "test"
