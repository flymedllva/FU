from sqlalchemy import ForeignKey, Integer, String, Column, DateTime, func
from sqlalchemy.orm import relationship
from datetime import datetime, timedelta
from server import db, session


class User(db):
    __tablename__ = "users"

    id = Column(Integer, primary_key=True, index=True, unique=True)
    login = Column(String, default=None, index=True)
    password = Column(String, default=None)
    token = Column(String, default=None)
    messages = relationship('Message', backref='person', lazy='dynamic')

    def __init__(self, login: str = None, password: str = None, token: str = None, messages=None):
        """
        Конструирует нового пользователя

        :param login:
        :param password:
        """

        self.login = login
        self.password = password
        self.token = token
        self.messages = list() if messages is None else messages

    def __repr__(self):
        return f'<User "{self.id}": {self.login}>'

    def add_new_message(self, message) -> 'User':
        """
        Создает сообщение и добавляет привязку к текущему пользователю

        :param message:
        :return:
        """

        message = Message(message)
        session.add(message)
        session.flush()
        self.messages.append(message)
        session.commit()

        return self

    def update_user(self, **data) -> 'User':
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
    def create_user(cls, login: str, password: str, token: str = None) -> 'User':
        """
        Создает пользователя

        :param token:
        :param login:
        :param password:
        :return:
        """

        if token and password and login:
            user = cls(login=login, password=password, token=token)
        elif login and password:
            user = cls(login=login, password=password)
        else:
            user = cls()

        session.add(user)
        session.commit()
        return user

    @classmethod
    def search_user(cls, id: int = None, login: str = None, token: str = None) -> None or 'User':
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


class Message(db):
    __tablename__ = "messages"

    id = Column(Integer, primary_key=True, index=True, unique=True)
    message = Column(String, default=None, index=True)
    date = Column(DateTime)
    user_id = Column(Integer, ForeignKey('users.id'))

    def __init__(self, message: str):
        """
        Конструктор сообщения

        :param message:
        """

        self.message = message
        self.date = datetime.now()

    @classmethod
    def today_messages(cls):
        """
        Возвращет все сегодняшние сообщения

        :return:
        """

        return session.query(Message).filter(func.DATE(Message.date) >= datetime.today() - timedelta(days=2)).all()
