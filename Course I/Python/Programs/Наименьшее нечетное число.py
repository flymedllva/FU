# С клавиатуры вводятся n целых чисел. Найти среди них наименьшее нечетное число.

n = ' '
buff = []
while n:
	try:
		n = int(input('Введите целое число: '))
	except Exception:
		print('Произошла ошибка')
		n = ''
	else:
		buff.append(n)
n = buff[0]
for i in buff:
	if i < n and i % 2 != 0:
		n = i
print('Наименьшее нечетное число =', n)