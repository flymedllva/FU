print('''Список команд:
	1 – Поиск цены по товару
	2 – Добавить информацию о новых товарах
	3 – Удалить информацию о товаре''')
command = ' '
while command:
	command = str(input('Введите команду: '))
	if command == ('1'): ###### 1 command
		name = str(input('Введите название товара: '))
		with open("file.txt") as file:
			for line in file.readlines():
				if name in line:
					line = line.split()
					print('{} – {} р.'.format(line[0], line[1]))
	elif command == '2': ###### 2 command
		name = str(input('Введите название товара: '))
		price = str(input('Введите цену товара: '))
		price = '\n' + name + ' ' + price
		f = open('file.txt','a')
		f.write(price)
		f.close()
	elif command == '3': ###### 3 command
		name = str(input('Введите название товара, который нужно удалить: '))
		buff = []
		with open("file.txt") as file:
			for line in file.readlines():
				if line.split()[0] != name:
					buff.append(line.rstrip())
		buff = '\n'.join(buff)
		f = open('file.txt', 'w')
		f.write(buff)
		f.close()
	else:
		print('Команда не найдена\nЗавершение программы')
		break
'''Хлебушек 12
Булочка 43
Молочко 65
КЕФИР 999'''

name = 'Булочка'
buff = []
with open('file.txt') as row:
	for jj in row.readlines():
		y = jj.find(name)
		if y != 0:
			buff.append(jj)
print(buff)
print(''.join(buff))