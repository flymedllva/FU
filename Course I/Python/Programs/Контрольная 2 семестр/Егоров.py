class CarShop:
	
	def __init__(self):
		self.__spisok = []
		self.__limit = 0
		self.__count = -1
	
	def __str__(self):
		return f'{self.__spisok}'
		
	def __iadd__(self, car):
		self.__spisok.append(list(car))
		return self
	
	def __iter__(self):
		return iter(self.__spisok)
		
	def __next__(self):
		if (self.__count + 1) < len(self.__spisok):
			self.__count += 1
			return self.__spisok[self.__count]
		else:
			raise StopIteration
			
	def read_file(self, file_name):
		with open(file_name) as file_one:
			for car in file_one:
				car = car.rstrip().split(",")
				self += car[0], car[1], int(car[2]), int(car[3])
	
	def newFile(self):
		with open("newFile.txt", "w") as _file_:
			print('{:_^65}\n'.format('Таблица всех машин'), file=_file_)
			print(' {:^15} {:^15} {:^20} {:^10} \n'.format("Производитель","модель","мощность двигателя","цена"), file=_file_)
			print('-' * 65, '\n',file=_file_)
			for x in self.__spisok:
				print(x)
				print()
				print('|{:^15}|{:^15}|{:^20}|{:^10}|'.format(x[0],x[1],x[2],x[3]),file=_file_)
				print('-' * 65,file=_file_)
				
	def mashinaByModel(self, model):
		num = 0
		for car in self.__spisok:
			if car[1] == model:
				return f"{car[0]}: модель {car[1]}, мощность: {car[2]}, колличество: {car[3]}"
		return None
			
	def numOfCar(self, value):
		num = 0
		for car in self.__spisok:
			if car[0] == value:
				num += 1
		if num == 0:
			return None
		return num
	
	@property
	def srArif(self):
		return round(sum([car[2] for car in self.__spisok]) / len(self.__spisok), 2)
	
testShop = CarShop()
testShop.read_file("Егоров_данные.txt")
print(testShop)
for i in testShop:
	print(i)
print(testShop.mashinaByModel("M5"))
print(testShop.numOfCar("BMW"))
print(testShop.srArif)
print(f"{next(testShop)} -> {next(testShop)} -> {next(testShop)}")
testShop.newFile()