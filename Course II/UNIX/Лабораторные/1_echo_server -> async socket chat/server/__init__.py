from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker, scoped_session
from sqlalchemy import create_engine

from config import ServerConfig

engine = create_engine(ServerConfig.SQLALCHEMY_DATABASE_URI)

db = declarative_base()
session = scoped_session(sessionmaker(bind=engine))

from server.models import *

# db.metadata.drop_all()
db.metadata.create_all(engine)

from server.server import *
