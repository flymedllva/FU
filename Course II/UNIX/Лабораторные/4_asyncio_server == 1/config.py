import os

basedir = os.path.abspath(os.path.dirname(__file__))


class ServerConfig(object):
    SERVER_HOST = "localhost"
    SERVER_PORT = 9090
    SQLALCHEMY_DATABASE_URI = 'sqlite:///' + os.path.join(basedir, 'server.db')
    SQLALCHEMY_TRACK_MODIFICATIONS = False

