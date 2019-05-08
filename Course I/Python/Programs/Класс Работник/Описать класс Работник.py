#	Создать класс, описывающий понятие работник, со свойствами:
#		– имя;
#		– фамилия;
#		– стаж;
#		– часовая заработная плата;
#		– количество отработанных часов.
#
#	Рассчитать с помощью методов заработную плату, за отработанное время, и премию, размер которой определяется в зависимости от стажа (при стаже до 1 года 0%, до 3 лет 5%, до 5 лет 8%, свыше 5 лет 15%).
#	С помощью метода печати, реализовать вывод информации о работнике на экран. Предусмотреть метод для записи в файл данных о работнике.
#	
#	Реализовать хранилище этой информации
	

class Worker:
	def __init__(self, firstName, secondName, workAges, timeMoney, timeNumber):
		self.__firstName = firstName
		self.__secondName = secondName
		self.__workAges = workAges
		self.__timeMoney = timeMoney
		self.__timeNumber = timeNumber
		
	def __str__(self):
		return f"Имя: {self.__firstName}\nФамилия: {self.__secondName}\nСтаж: {self.__workAges}\nЧасовая заработная плата: {self.__timeMoney}\nКоличество отработанных часов: {self.__timeNumber}\nЗаработная плата: {self.wages()}\nПремия: {self.prize()}"
	
	def wages(self):
		money = self.__timeMoney * self.__timeNumber
		return money
		
	def prize(self):
		if self.__workAges < 1:
			return "Нет премии"
		elif 1 <= self.__workAges < 3:
			return self.wages() * 0.05
		elif 3 <= self.__workAges < 5:
			return self.wages() * 0.08
		else:
			return self.wages() * 0.15
		
				
secondWorker = Worker("Евгеша", "Калугина", 3, 123, 160)
print(secondWorker)
