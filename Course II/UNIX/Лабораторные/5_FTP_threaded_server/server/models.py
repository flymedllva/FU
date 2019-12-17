import hashlib
import os

from sqlalchemy import Integer, Float, String, Column
from config import Config, Admin
from server import db, session
from time import time


class Model(db):
    __tablename__ = "users"

    id = Column(Integer, primary_key=True, index=True, unique=True)
    role = Column(String, default="user")
    login = Column(String, default=None, index=True)
    password = Column(String, default=None)
    token = Column(String, default=None)
    current_directory = Column(String, default=None)
    custom_directory = Column(String, default=None)
    max_storage_size = Column(Float, default=10.0)

    def __init__(self, login: str = None, password: str = None, role: str = None,
                 custom_directory: str = None):
        """
        Конструирует нового пользователя

        :param login:
        :param password:
        :param role:
        :param custom_directory:
        """

        self.role = role
        self.login = login.strip()
        self.password = hashlib.md5((password + Config.SERVER_SECRET).encode()).hexdigest() if password else None
        self.token = self.create_token(self.password) if self.password else None
        self.custom_directory = "/" + (self.login if custom_directory is None else self.login).strip()
        self.current_directory = self.custom_directory
        if not os.path.exists(Config.FILES_DIR + self.custom_directory):
            os.makedirs(Config.FILES_DIR + self.custom_directory)

    @property
    def directory(self) -> str:
        """
        Возвращает ссылку на текущую директорию пользователя

        :return:
        """

        return Config.FILES_DIR + self.current_directory

    def __repr__(self):
        """
        Возвращает печатаемое представление объекта

        :return:
        """

        return f'<User "{self.id}": {self.login}>'

    def update_user(self, **data) -> 'Model':
        """
        Обновляет поля пользователя поданные как kwargs

        :param data:
        :return:
        """

        for key, value in data['data'].items():
            if hasattr(self, key):
                setattr(self, key, value)
        session.commit()

        return self

    @classmethod
    def create_user(cls, login: str, password: str or None, token: str = None, role: str = None,
                    custom_directory: str = None, max_storage_size: float = None) -> 'Model':
        """
        Создает пользователя

        :param max_storage_size:
        :param custom_directory:
        :param role:
        :param token:
        :param login:
        :param password:
        :return:
        """

        user = cls(login, password)
        session.add(user)
        session.flush()

        if token:
            user.token = token
        if role:
            user.role = role
        if custom_directory:
            user.custom_directory = "/" + (login if custom_directory is None else login)
        if max_storage_size:
            user.max_storage_size = max_storage_size

        session.commit()

        return user

    @classmethod
    def search_user(cls, id: int = None, login: str = None, token: str = None) -> None or 'Model':
        """
        Ищет пользователя в базе по id

        :param id:
        :param token:
        :param login:
        :return:
        """

        if id is not None:
            user = session.query(cls).filter_by(id=id).first()
        elif (login and token) is not None:
            user = session.query(cls).filter_by(login=login, token=token).first()
        elif login is not None:
            user = session.query(cls).filter_by(login=login).first()
        elif token is not None:
            user = session.query(cls).filter_by(token=token).first()
        else:
            return None
        return user

    @classmethod
    def clear_table(cls) -> None:
        """
        Очищает текущую таблицу

        :return:
        """

        session.query(cls).delete()
        session.commit()
        Model.create_user(login=Admin.LOGIN, password=Admin.PASSWORD, role="admin", max_storage_size=10000)

    @classmethod
    def create_token(cls, data: str) -> str:
        """
        Создает токен

        :param data:
        :return:
        """

        return hashlib.md5((str(Config.SERVER_SECRET if data is None else data) + str(time())).encode()).hexdigest()
