from typing import List
from datetime import datetime

from pydantic import BaseModel


class Note(BaseModel):
    id: int
    text: str
    date: datetime


class Notes(BaseModel):
    notes: List[Note]


class NewNote(BaseModel):
    text: str


class DeleteNote(BaseModel):
    id: int


class EditNote(BaseModel):
    id: int
    text: str
