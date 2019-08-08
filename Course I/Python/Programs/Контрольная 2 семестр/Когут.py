class FlowerShop:
	
	def __init__(self):
		self.__storage = []
		self.__country = None
	
	def __str__(self):
		return "FlowerShop"
		
	def __iadd__(self, data):
		self.__storage.append(list(data))
		return self
		
	def __iter__(self):
		return iter(self.__storage)
	
	def __next__(self):
		if not self.__storage:
			raise StopIteration
		return self.__storage.pop()
	
	
	def getter_country(self):
		return self.__country

	def setter_country(self, value):
		self.__country = value

	def deleter_country(self):
		self.__country = None
	
	country = property(getter_country, setter_country, deleter_country, 'Свойство country')
		
	def read(self, file_name):
		with open(file_name, 'r', encoding="utf-8") as file_one:
			for line in file_one:
				line = line.strip().split(";")
				self += line[0], line[1], line[2], int(line[3])
		return self
	
	def print_table_in_file(self, file_name):
		with open(file_name, 'w', encoding="utf-8") as file_one:
			file_one.write(f"{'-'*29} Цветочный магазин {'-'*29}\n| {'Название цветка':<16} | {'Сорт цветка':<16} | {'Страна':<16} | {'Цена':<16} |\n| {'-'*16:<16} | {'-'*16:<16} | {'-'*16:<16} | {'-'*16:<16} |\n")
			for flor in self.__storage:
				file_one.write(f"| {flor[0]:<16} | {flor[1]:<16} | {flor[2]:<16} | {str(flor[3]) + ' ₽':<16} |\n")
				print(flor)
			file_one.write(f"{'-'*77}")
		return self
	
	def databaseSearch(self, word, sort_by_price = True):
		storage = []
		for flor in self.__storage:
			if word in flor:
				if self.__country is None:
					storage.append(flor)
				else:
					if flor[2] == self.__country:
						storage.append(flor)
		if sort_by_price is True:
			storage.sort(key=lambda item: item[3], reverse=True)
		if len(storage) > 0:
			header = f"По запросу \"{word}\" найдено {len(storage)} совпадения"
			country_filter = f"Использовался фильтр по слову {self.__country}"
			print(f"{'-'*77}\n {header:^75} \n{'-'*77}")
			if self.__country is not None:
				print(f"{country_filter:^75}\n{'-'*77}")
			print(f"| {'Название цветка':<16}   {'Сорт цветка':<16}   {'Страна':<16}   {'Цена':<16} |\n{'-'*77}")
			[print(f"| {flor[0]:<16} | {flor[1]:<16} | {flor[2]:<16} | {str(flor[3]) + ' ₽':<16} |") for flor in storage]
			print(f"{'-'*77}")
		else:
			print(f"Нет совпадений с запросом {word}")

		
	

shop = FlowerShop()
shop.read("Когут_данные.txt") # Чтение данных
shop += "Роза", "Муви Стар", "Эквадор", 150 # +=
[print(item) for item in shop] # __iter__
print(next(shop), next(shop)) # __next__
shop.print_table_in_file("Когут_результат.txt") # метод, который выводит данные в новый текстовый файл в удобном для восприятия виде (в виде таблицы с заголовками);
shop.country = "Иран" # Свойство страна для print в консоли
shop.databaseSearch("Тюльпан", sort_by_price = True) # Метод с несколькими параметрами
