import random
x = -100
y = 100
guess = random.randint (x, y)
tries = 1
try:
	number = int(input("Введите число от -100 до 100: "))
	if x <= number <= y:
		pass
	else:
		print('Ваше число вышло из диапазона')
		raise(ValueError)
except Exception:
	print('Произошла ошибка')
else:
	if number == guess:
		print('С первой попытки!')
	else:
		while guess != number:
			if number > guess:
				print("Загаданное число больше: ", guess)
				x = guess
				guess = random.randint(x, y)
				tries += 1
			elif number < guess:
				print("Загаданное число меньше: ", guess)
				y = guess
				guess = random.randint(x, y) 
				tries += 1
		print ('Число: ',number)
		print ('Отгадано', tries, 'попытки')