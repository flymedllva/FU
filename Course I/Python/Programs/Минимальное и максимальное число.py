# Минимальное и максимальное число
x = ' '
buff = []
print('Вводите числа и нажимайте Enter')
print('Программа выведет максимальное и минимальное число по вводу пустого значения')
while x:
	x = str(input(''))
	if x != ' ':
		try:
			buff.append(int(x))
		except Exception:
			print('Произошла ошибка во время добавления числа в буффер')
	else:
		break
print('Максимальное число = {}\nМинимальное число = {}'.format(max(buff),min(buff)))