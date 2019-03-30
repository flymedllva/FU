class Statement():
	def __init__(self, discipline, group):
		self.discipline = discipline
		self.group = group
		self.dictStudents = {}
		print(f"-----------------\nСоздана ведомость.\nДисциплина: {self.discipline}\nГруппа: {self.group}\n-----------------")

	"""
	Добавляет в ведомость информацию об оценке студента (фамилия, оценка – параметры метода). 
	Возможные оценки – «отлично», «хорошо», «удовл.», «неудовл.», «н/я»
	"""
	def put(self, family, score):
		if score == "отлично" or score == "хорошо" or score == "удовлетворительно" or score == "неудовлетворительно" or score == "н/я":
			self.dictStudents[family] = score
			print(f"\n-----------------\n{self.discipline}\nВ группу {self.group} добавлен новый студент: {family} с оценкой '{score}'\n-----------------")
		else:
			print("Не удалось добавить студента")

	"""
	Возвращает оценку, полученную студентом (фамилия студента – параметр метода);
	"""
	def get(self, family):
		if self.dictStudents.get(family) != None:
			return self.dictStudents[family]
		return None
 
	"""
	Изменяет оценку, полученную студентом (фамилия студента и новая оценка – параметры метода);
	"""
	def change(self, family, score):
		if score == "отлично" or score == "хорошо" or score == "удовлетворительно" or score == "неудовлетворительно" or score == "н/я":
			if self.dictStudents.get(family) != None:
				self.dictStudents[family] = score
		else:
			print("Не удалось изменить оценку")
	
	"""
	Удаляет информацию о студенте из ведомости (фамилия студента – параметр метода)
	"""
	def delete(self, family):
		try:
			self.dictStudents.pop(family) 
		except KeyError:
			pass

	"""
	Возвращает кортеж из 5 чисел (количество каждого вида оценок в ведомости)
	"""
	def result(self):
		scores = [0,0,0,0,0]
		for score in self.dictStudents.values():
			if score == "отлично":
				scores[0] += 1
			elif score == "хорошо":
				scores[1] += 1
			elif score == "удовлетворительно":
				scores[2] += 1
			elif score == "неудовлетворительно":
				scores[3] += 1
			elif score == "н/я":
				scores[4] += 1
		return tuple(scores)
	
	"""
	Возвращает количество студентов в ведомости
	"""
	def count(self):
		return len(self.dictStudents)

	"""
	Возвращает список фамилий, имеющихся в ведомости
	"""
	def names(self):
		return [key for key in self.dictStudents.keys()]

statementOne = Statement("Организация Вычислительных Систем", "ПИ18-1")
statementOne.put("Калугина", "отлично")
statementOne.put("Гриднев", "удовлетворительно")
statementOne.put("Плетнев", "хорошо")
statementOne.put("Пыльцина", "удовлетворительно")
statementOne.put("Абдульна", "неудовлетворительно")
for name in ["Ивленко", "Аратюнян", "Баранюк"]:
	statementOne.put(name, "удовлетворительно")