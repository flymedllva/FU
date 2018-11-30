print('''Список команд:
	1 – Поиск цены по товару
	2 – Добавить информацию о новых товарах
	3 – Удалить информацию о товаре''')
command = ' '
while command:
	command = input('Введите команду: ')
	if command == ('1'): ###### 1 command
		name = input('Введите название товара: ')
		with open("file.txt") as file:
			for line in file.readlines():
				if name in line:
					line = line.split()
					print('{} – {} р.'.format(line[0], line[1]))
	elif command == '2': ###### 2 command
		name = input('Введите название товара: ')
		price = input('Введите цену товара: ')
		price = '\n' + name + ' ' + price
		f = open('file.txt','a')
		f.write(price)
		f.close()
	elif command == '3': ###### 3 command
		name = input('Введите название товара, который нужно удалить: ')
		buff = []
		with open("file.txt") as file1:
			for line in file1.readlines():
				if line.split()[0] != name:
					buff.append(line.rstrip())
		buff = '\n'.join(buff)
		f = open('file.txt', 'w')
		f.write(buff)
		f.close()
	else:
		print('Команда не найдена\nЗавершение программы')
		break