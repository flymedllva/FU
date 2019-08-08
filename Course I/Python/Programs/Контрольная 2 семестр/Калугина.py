class ZooShop:
	def __init__(self):
		self.__data = []
		self.min_price = None
		
	def __str__(self):
		return f'{self.__data}'
		
	def __iadd__(self, animal):
		self.__data.append(list(animal))
		return self
	
	def get_min_price(self):
		return self._min_price

	def set_min_price(self, value):
		self._min_price = value

	def del_min_price(self):
		self._min_price = None
		
	min_price = property(get_min_price, set_min_price, del_min_price, 'Это свойство минимальной цены')
	
	def openFile(self):
		with open("Калугина_данные.txt") as fileOne:
			for line in fileOne:
				line = line.rstrip().split("|")
				self += line[0], line[1], int(line[2]), int(line[3])
	
	def printTableInFile(self, fileName = "Калугина_результат.txt"):
		
		with open(fileName, "w") as fileOne:
			print(f"{'-'*93}\n| {'Название магазина':<20} | {'Название животного':<20} | {'Количество животных':<20} | {'Цена животных':<20} |\n{'-'*93}", file = fileOne)
			for animal in self.__data:
				price = f"{animal[3]} ₽"
				if (self.min_price is not None and animal[3] >= self.min_price) or self.min_price is None:
					print(f"| {animal[0]:<20} | {animal[1]:<20} | {animal[2]:<20} | {price:<20} |", file = fileOne)

			print(f"{'-'*93}", file = fileOne)
	
	def findAnimal(self, min_price, shop_name):
		print(f"{'-'*93}\n| {'Название магазина':<20} | {'Название животного':<20} | {'Количество животных':<20} | {'Цена животных':<20} |\n{'-'*93}")
		for animal in self.__data:
			if shop_name == animal[0] and animal[3] <= min_price and ((self.min_price is not None and animal[3] >= self.min_price) or self.min_price is None):
				price = f"{animal[3]} ₽"
				print(f"| {animal[0]:<20} | {animal[1]:<20} | {animal[2]:<20} | {price:<20} |")

				
shopOne = ZooShop()
#shopOne += "1", "1", "1", "1"
#print(f"{shopOne}")
shopOne.openFile()
#print(f"{shopOne}")
shopOne.min_price = 200
#del shopOne.min_price
shopOne.printTableInFile()
shopOne.findAnimal(1300, "Котейная")
print(next(shopOne  ))