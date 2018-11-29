def printText(a,b):
	print('Все четко, переменные: {}, {}'.format(a,b))
import math
a = 4
b = str(math.pi)
if a and b:
	try:
		assert type(a) == int, 'Ошибка типа переменной "a"'
		assert type(b) == int or float, 'Ошибка типа переменной "b"'
	except AssertionError as ErrorName:
		print('Первая найденная ошибка: ', ErrorName)
		print('Попытка преобразовать переменые к типу int...')
		try:
			a = int(a)
			b = int(b)
		except Exception:
			print('Преобразование не удалось')
		else:
			print('Преобразование типов прошло успешно')
			printText(a,b)
	else:
		print('Преобразование типов не потребовалось')
		printText(a,b)