from fastapi import APIRouter, HTTPException

from app.core import store
from app.schemas.note import NewNote, Note, Notes, EditNote

router = APIRouter()


@router.get("/note/all", tags=["note"], response_model=Notes)
async def get_notes():
    """
    Отдает все заметки
    """

    return Notes(notes=list(reversed(store.data.values())))


@router.post("/note/new", tags=["note"], response_model=Note)
async def create_new_note(new_note: NewNote) -> Note:
    """
    Создает заметку
    """

    if new_note.text:
        return await store.create_new_note(new_note.text)
    raise HTTPException(status_code=400, detail="Заметка слишком короткая")


@router.put("/note/edit", tags=["note"], response_model=Note)
async def edit_note(new_note: EditNote) -> Note:
    """
    Изменить заметку
    """

    if new_note.text:
        new_note = await store.edit_note(new_note.id, new_note.text)
        if new_note is not None:
            return new_note
        raise HTTPException(status_code=400, detail="Не удалось найти заметку в базе")
    raise HTTPException(status_code=400, detail="Заметка слишком короткая")


@router.delete(
    "/note/{id}",
    tags=["note"],
    response_model=bool,
)
async def delete_note(id: int):
    """
    Удаляет заметку
    """

    note = await store.delete_note(id)
    if isinstance(note, Note):
        return True
    raise HTTPException(status_code=400, detail="Заметка не найдена в базе")
