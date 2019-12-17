from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker, scoped_session
from sqlalchemy.pool import StaticPool
from sqlalchemy import create_engine

from config import ServerConfig

engine = create_engine(ServerConfig.SQLALCHEMY_DATABASE_URI,
                       connect_args={'check_same_thread': False},
                       poolclass=StaticPool)

db = declarative_base()
session = scoped_session(sessionmaker(bind=engine))

from server.models import *

db.metadata.create_all(engine)

from server.server import *
