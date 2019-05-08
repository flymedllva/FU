class Node:
	def __init__(self, value = None, next = None):
		self.value = value
		self.next = next

class Stack:
	def __init__(self):
		self.firstValue = None
		self.lastValue = None
		self.length = 0

	def __str__(self):
		if self.firstValue != None:
			current = self.firstValue
			head = 'Stack[' + str(current.value)
			while current.next != None:
				current = current.next
				if type(current.value) == str:
					head += ', ' + "'" + str(current.value) + "'"
				else:
					head += ', ' + str(current.value)

			return head + ']'
		return 'Stack []'
				
	def push(self, value):
		"""
		Добавляет элемент в стек
		"""
		if self.firstValue == None:
			self.firstValue = Node(value, None)
			self.lastValue = self.firstValue
		else:
			self.firstValue = Node(value, self.firstValue)
			
	def pop(self):
		"""
		Удаляет элемент расположенный на вершине стека и возращает его значение
		"""
		previous = self.firstValue
		if previous == None:
			return None
		self.firstValue = previous.next
		if self.firstValue == None:
			self.lastValue = None
		return previous.value
	
	def size(self):
		"""
		Возвращает количество элементов в стеке
		"""
		self.length = 0
		if self.firstValue != None:
			self.length +=1
			current = self.firstValue
			while current.next != None:
				current = current.next
				self.length +=1
		return self.length
	
	def top(self):
		"""
		Возращает элемент на вершине стека, элемент из стека не удаляется
		"""
		return self.firstValue.value # Last

	def size(self):
		"""
		Возвращает колличество элементов в стеке
		"""
		length = 0
		if self.firstValue != None:
			current = self.firstValue
			while current.next != None:
				current = current.next
				length += 1
		return length + 1
		
	def empty(self):
		"""
		Возвращает true, если стек не содержит элементов
		"""
		if self.lastValue == None:
			return True
		return False

gg = Stack()
gg.push(433)
gg.push("testStr")
gg.push(666)
gg.push([1, 3, "2"])
gg.push(777)
gg.push(111)
print(f"{gg} Колличество элементов: {gg.size()}")
gg.pop()
print(f"{gg} Колличество элементов после удаления: {gg.size()}")
print(f"Пустой стек: {gg.empty()}")
print(f"Элемент на вершине стека: {gg.top()}")
