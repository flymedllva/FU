#  Напишите программу, которая при попадании значения в диапазон печатает «Yes»,
#  в противном случае – «No». Границы диапазона и значение вводятся.
try:
	x = int(input('Введите начало диапазона: '))
	y = int(input('Введите конец диапазона: '))
	z = int(input('Введите число: '))
except Exception:
	print('Произошла ошибка')
else:
	if x <= z <= y:
		print('Yes')
	else:
		print('No')