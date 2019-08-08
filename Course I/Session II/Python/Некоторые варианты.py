"""
Вариант 4
"""
### №2
# def p_sums(*data):
#     return [sum(data[:item + 1]) for item in range(len(data))]
# print(p_sums(10, 2, 33))
### №3
# from functools import reduce
# def convert_to_str(data):
#     return reduce(lambda accumulator, item: accumulator + ";" + item, map(str, filter(lambda item: item / 2 != 0, data)))
# print(convert_to_str([1,2,3,4,5]))
"""
Вариант 7
"""
### №2
# import sys
# import locale
# from datetime import datetime
# if sys.platform == 'win32':
#     locale.setlocale(locale.LC_ALL, 'rus_rus')
# else:
#     locale.setlocale(locale.LC_ALL, 'ru_RU.UTF-8')
# def date_format(date, year=2019):
#     for item in [f"{item.replace('.', '')}{year}" for item in date.split(', ')]:
#         try:
#             print(f'Дата – {datetime.strptime(item, "%d%m%Y").date().strftime("%d %B %Y")}')
#         except ValueError:
#             print("Ошибка в дате")
#     return date
# date_format("17.09, 18.06, 01.221")
### №3
# def dollar(func):
#     def wrapped(*args, **kwargs):
#         return f'${func(*args, **kwargs):.2f}'
#     return wrapped
# @dollar
# def hello(data):
#     return data
# print(hello(232))
"""
Вариант 12
"""
### №2
# def recursive_calculation(data, accumulator = 0):
#     if accumulator >= len(data): return 0
#     return data[accumulator] + recursive_calculation(data, accumulator + 1)
# print(recursive_calculation([1, 2, 3]))
### №3
# TODO ЧТО ОНА ХОЧЕТ?
"""
Вариант 13
"""
### №2
# def word_generator(data):
#     return [key for key, item in data.items() if sum(item) > 0]
# print(word_generator({'a': [2, -5, 1], 'b': [10], 'c': [5, 8]}))
### №3
# def correct_str(func):
#     def wrapped(*args, **kwargs):
#         func_args = func(*args, **kwargs).strip().lower()
#         while func_args.find('  ') != -1: func_args = func_args.replace('  ', ' ')
#         return func_args
#     return wrapped
# @correct_str
# def hello(data):
#     return data
# print(hello('    fdfdf dfd    adsdqs asdasdas dasda        asdasdsad     '))
"""
Вариант 14
"""
# ## №2
# def psort(*data):
#     return sorted(data, key=lambda item: item[-1])
# print(psort('xyz', 'm', 'kn', 'aaa'))
# ## №3
# def print_list(func):
#     def wrapped(*args, **kwargs):
#         return f"{func.__name__}: " + ', '.join(map(str, func(*args, **kwargs)))
#     return wrapped
# @print_list
# def hello(data):
#     return data
# print(hello([1, 2, 3, 4, 5]))
"""
Вариант 18
"""
### №2
# def recursive_calculation(data, accumulator = 0):
#     if accumulator >= len(data): return 0
#     return data[accumulator] + recursive_calculation(data, accumulator + 1)
# print(recursive_calculation([4, 6, 10]))
### №3
# TODO ХЗЗЗЗЗ
"""
Вариант 22
"""
### №2
# def recursive_calculation(data, accumulator = 0):
#     if accumulator >= len(data): return 0
#     return data[accumulator] + recursive_calculation(data, accumulator + 1)
# print(recursive_calculation([4, 6, 10]))
### №3
# def last_element(data):
#     return list(map(lambda item: item[-1], filter(lambda item: len(item) > 2, data)))
# print(last_element([[1, 2, 3], [2, 3, 4], [0, 1, 1, 1], [0, 0]]))
"""
Вариант 23
"""
### №2
# def asterisks(data):
#     return ['#'*item if item % 2 else '*'*item for item in data]
# print(asterisks([1, 2, 3, 4, 5, 6, 7]))
### №3
# class Покупка:
#     def __init__(self):
#         self.__L = []
    
#     def put(self, name, price, count):
#         try:
#             self.__L.append([name, int(price), int(count)])
#             print(f"Товар «{name}» успешно добавлен")
#             return True
#         except Exception:
#             print("Не удалось добавить товар, проверьте правильность данных")
#             return False
        
#     def cost(self, cost = 0):
#         for item in self.__L: cost += item[1] * item[2]
#         return cost
    
#     def information(self):
#         print(f"{'-'*46}\n{'-'*15} Список покупок {'-'*15}\n{'-'*46}\n|{'Наименование'[:14]:^14}|{'Цена'[:14]:^14}|{'Количество'[:14]:^14}|\n{'-'*46}")
#         for item in self.__L:
#             print(f"|{item[0][:14]:^14}|{str(item[1])+' ₽'[:14]:^14}|{str(item[2])+' шт'[:12]:^14}|")
#         print(f"{'-'*46}\n{'-'*9}{'Общая стоимость: '+str(self.cost())+' ₽'[:28]:^28}{'-'*9}\n{'-'*46}\n")

# список_покупок_1 = Покупка()
# список_покупок_1.put("Булка", 40, 2)
# список_покупок_1.put("Хлебушек", 33, 5)
# print(список_покупок_1.cost())
# список_покупок_1.information()
# список_покупок_2 = Покупка()
# список_покупок_2.put("Человек", 10000000, 5)
# список_покупок_2.put("Рыба", 200, 10)
# список_покупок_2.information()
# список_покупок_2 = Покупка()
"""
Вариант 25
"""
### №2
# def dict_generator(data):
#     return {item[0]:item[1].split(",") for item in [item.split(':') for item in data]}
#     # return {item[0]:item[1].split(",") for item in map(lambda item: item.split(':'), data)}
#     # return {key: value.split(",") for (key, value) in {item.split(":")[0]: item.split(":")[1] for item in data}.items()}
# print(dict_generator(['aaa:bb,c,dd', 'ss:a,fff']))
### №3
# TODO СТЕК ОЧЕРЕДИ? ПИСАТЬ КЛАСС? ИЛИ ЧЕ?
"""
Вариант 26
"""
### №2
# def psort(**data):
#     return [item[0] for item in (lambda item: item[:3] if len(item) > 3 else item)(sorted(data.items(), key=lambda item: item[1], reverse=True))]
# print(psort(a=2, b=45, c=34, d=3))
### №3
# def last_element(data):
#     return list(map(lambda item: item[-1], filter(lambda item: len(item) > 2, data)))
# print(last_element([[1, 2, 3], [2, 3, 4], [0, 1, 1, 1], [0, 0]]))
