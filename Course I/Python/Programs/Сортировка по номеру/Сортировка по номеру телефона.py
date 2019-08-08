#	Сортировка по номеру телефона в файле
#
#	Напишите программу которая сортирует записи в файле в порядке возрастания номера телефона и выводит их в другой файл.
#	В текстовом файле находятся записи о номерах телефонов. В каждой строке записана информация: номер телефона, ФИО, адрес.
#	
#	или 
#	
#	Напишите класс, который хранит данную информацию и позволяет:
#		- Выводит информацию о всех номерах в порядке возрастания
#		- Выводит информацию о определенном номере
#		– Выводит номер и адрес определенного аббонента
#		– Выводит выводит номер и имя всех аббонентов по одному адресу
#		– Добавлять новые номера
#		- Редактировать данные для каждого из номеров
#		- Определяет оператора, регион или страну(если не Россия) аббонента
#		
#	Информация https://phonenum.info/phone/

#class Phones:
#	def __init__(self, fileName):
#		self.__fileName = fileName
#		self.__data = self.readFile()
#		
#	def readFile(self):
#		data = []
#		with open(self.__fileName) as fileOne:
#			for line in fileOne:
#				line = line.rstrip().split(' | ') 
#				addres = line[1]
#				line = line[0].split(' ', maxsplit=1)
#				phone = int(line[0].replace("+", "").replace("-", ""))
#				name = line[1]
#				data.append([phone, name, addres])
#		return self.sortData(data)
#	
#	def appendInFile(self, thisD):
#		with open(self.__fileName, "a") as fileOne:
#			fileOne.write("\n" + self.numberFormat(thisD[0]) + " " + thisD[1] + " | " + thisD[2])
#		
#	def numberFormat(self, number):
#		number = str(number)
#		text = "+"
#		if number[0] == "7":
#			text += "7"
#			number = number[1:]
#		elif number[0:3] == "380":
#			text += "380"
#			number = number[3:]
#		text += "-" + number[0:3] + "-" + number[3:6] + "-" + number[6:8] + "-" + number[8:]
#		return text
#	
#	def sortData(self, data = None):
#		if data == None:
#			data = self.__data
#		data.sort(key=lambda x: x[0])
#		return data
#		
#	def addNumber(self, name, number, address):		
#		self.__data.append([name, number, address])
#		self.appendInFile([name, number, address])
#		
#	def allData(self):
#		for i in self.__data:
#			print(f"Имя: {i[1]:<20} Номер: {i[0]:<14} Адрес: {i[2]}")
#	
#	def checkPhone(self, number):
#		for i in self.__data:
#			if int(number) == i[0]:
#				print(f"Имя: {i[1]:<20} Номер: {i[0]:<14} Адрес: {i[2]}")
#				
#	def checkName(self, name):
#		for i in self.__data:
#			if name == i[1]:
#				print(f"Имя: {i[1]:<15} Номер: {i[0]:<15} Адрес:  {i[2]:<15}")
#	
#	def allPeople(self, adress):
#		for i in self.__data:
#			if adress == i[2]:
#				print(f"Имя: {i[1]:<15} Номер: {i[0]:<15} Адрес:  {i[2]:<15}")
#	
#	def checkNumberInformation(self, number):
#		
#		
#		
#	
#phonesList = Phones("phones.txt")
#phonesList.allData()
#phonesList.checkPhone("79333423545")
#phonesList.checkName("Иванов Юрий")
#phonesList.allPeople("Петрович Чайковского 1 кв 1")
#phonesList.addNumber(79636606603, "Калугина Евгения", "Веерная 666")

		