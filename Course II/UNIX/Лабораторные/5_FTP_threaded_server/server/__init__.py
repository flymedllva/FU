from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker, scoped_session
from sqlalchemy.pool import StaticPool
from sqlalchemy import create_engine

from config import Config, Admin, Tester

engine = create_engine(Config.DATABASE_URI,
                       connect_args={'check_same_thread': False},
                       poolclass=StaticPool)

db = declarative_base()
session = scoped_session(sessionmaker(bind=engine))

from server.models import *

db.metadata.create_all(engine)

from server.server import Server

if len(session.query(Model).all()) == 0:
    Model.create_user(login=Admin.LOGIN, password=Admin.PASSWORD, role="admin", max_storage_size=10000)
    Model.create_user(login=Tester.LOGIN, password=Tester.PASSWORD)
