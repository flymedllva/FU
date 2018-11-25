# Вывести колличество чисел, минимальное и максимальное их значение, их сумму, среднее значение. Числа вводятся через enter. Концом является ввод 0
count = 0
summ = 0
mini = 99999999999
maxi = 0
a = ' '
while a:
	try:
		a = int(input('Enter a number: '))
	except Exception:
		print('Произошла ошибка')
	else:
		if a != 0:
			count = count + 1
			summ = summ + a
			if a > maxi:
				maxi = a
			elif a < mini:
				mini = a
		else:
			ser = summ/count
			print('__________________')
			print('Number of entered numbers:{:^4}\nThe minimum number: {:^10}\nMaximum number: {:^6}\nThe sum of the numbers: {:>6}\nThe average of the numbers: {:^6.2f}'.format(count,mini,maxi,summ,ser))
			break
