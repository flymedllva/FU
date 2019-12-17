import json


class Data(object):

    def __init__(self, data: dict, type: str = "message", notice: str = None):
        """
        Конструктор данных

        :param data:
        :param type:
        :param notice:
        """

        self.notice = notice
        self.data = data
        self.type = type

    def to_json(self) -> json:
        """
        Возвращает данные в виде JSON

        :return:
        """

        return json.dumps(dict(type=self.type, data=self.data, notice=self.notice)).encode("utf-8")

    def to_dict(self) -> dict:
        """
        Возвращает данные в виде словаря
        """

        return dict(type=self.type, data=self.data, notice=self.notice)