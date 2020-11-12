import os

SERVER_NAME = os.getenv("SERVER_NAME")
SERVER_HOST = os.getenv("SERVER_HOST")
PROJECT_NAME = os.getenv("PROJECT_NAME") or "Task 6-7"
PROJECT_DESCRIPTION = os.getenv("PROJECT_DESCRIPTION") or "API"
PROJECT_VERSION = os.getenv("PROJECT_VERSION") or "1.0"
PROJECT_DOCS_URL = "/documentation"
PROJECT_API_V1_URL = "/api/v1"
