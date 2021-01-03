import os
import json
from datetime import datetime
from random import randint

from app.schemas.note import Note


class MetaSingleton(type):
    _instances = {}

    def __call__(cls, *args, **kwargs):
        if cls not in cls._instances:
            cls._instances[cls] = super(MetaSingleton, cls).__call__(*args, **kwargs)
        return cls._instances[cls]


class NoteStore(metaclass=MetaSingleton):
    data = {}
    file_name = "/../data.json"

    def __init__(self, file_name: str = None):
        if file_name is not None:
            self.file_name = file_name

    def __get_new_id(self) -> int:
        """
        Возвращает случайный id не входящий в базу

        Такой писать не надо в реале))
        """

        new_id = None
        while True:
            if new_id is None or new_id in self.data:
                new_id = randint(10000000000, 99999999999)
            else:
                break
        return new_id

    async def create_new_note(self, text: str) -> Note:
        """
        Создает новую заметку в памяти
        """
        new_note = Note(id=self.__get_new_id(), text=text, date=datetime.now())
        self.data[new_note.id] = new_note
        self.write_to_file()
        return new_note

    async def delete_note(self, id: int) -> Note or None:
        """
        Удаляет заметку из памяти
        """
        if id in self.data:
            return self.data.pop(id)
        self.write_to_file()
        return None

    async def edit_note(self, id: int, text: str) -> Note or None:
        """
        Редактирует заметку в памяти
        """
        if id in self.data:
            note = self.data[id]
            note.text = text
            note.date = datetime.now()
            self.data[id] = note
            return self.data[id]
        self.write_to_file()
        return None

    def read_from_file(self):
        try:
            with open(os.path.abspath(os.curdir) + self.file_name) as f:
                date_format = "%Y-%m-%dT%H:%M:%S.%f"
                data = json.load(f)
                for k, v in data.items():
                    v = json.loads(v)
                    note = Note(
                        id=v["id"],
                        text=v["text"],
                        date=datetime.strptime(v["date"], date_format),
                    )
                    self.data[k] = note
        except FileNotFoundError:
            pass

    def write_to_file(self):
        with open(os.path.abspath(os.curdir) + self.file_name, "w") as f:
            data = {}
            for k, v in self.data.items():
                data[k] = v.json()
            json.dump(data, f)
