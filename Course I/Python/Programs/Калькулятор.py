### Калькулятор

# Прибавить
def add(a, b):
	return a + b

# Удалить
def sub(a, b):
	return a - b

# Умножить
def mult(a, b):
	return a * b

# Поделить
def div(a, b):
	return a / b

while (True):
	# Ввод комманд
	a = input('Введите первый аргумент ')
	op = input('Введите операцию: ')
	b = input('Введите 2 аргумент: ')
	try:
		a = int(a)
		b = int(b)
	except ValueError:
		print('Неправильный аргумент...')
		op = None
	if (op != None):
		if (op == "+"):
			print("Сумма: ", add(a, b))
		elif (op == "-"):
			print("Вычитание: ", sub(a, b))
		elif (op == "*"):
			print("Умножение: ", mult(a, b))
		elif (op == "/"):
			print("Деление: ", div(a, b))
		else:
			print('Неправильная операция...')

	q = input('Выйти? [да/нет] ')
	if (q == 'Да' or q == 'да'):
		break
