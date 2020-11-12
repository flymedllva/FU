from fastapi import HTTPException
from starlette.status import HTTP_409_CONFLICT

# Core

UNKNOWN_ERROR_EXCEPTION = HTTPException(
    status_code=HTTP_409_CONFLICT, detail="Unknown error."
)
