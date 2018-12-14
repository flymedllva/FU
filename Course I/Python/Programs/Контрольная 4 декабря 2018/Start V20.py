# Functions
def openFile(FILE_NAME): # openFile
	with open(FILE_NAME) as file1:
		return [i.rstrip() for i in file1]
def allCount(line): # count
	dictCount = {}
	for i in line:
		i = i.split(': ')
		try:
			if dictCount.get(i[0]):
				dictCount[i[0]] = (dictCount[i[0]][0] + int(i[1]), dictCount[i[0]][1] + 1)
			else:
				dictCount[i[0]] = (int(i[1]), 1)
		except TypeError:
			print('Произошла ошибка')
	return dictCount
	
# Config
FILE_NAME = 'Товары.txt'
OPEN_FILE = openFile(FILE_NAME)

# Используя данные этого файла создайте список строк
print(OPEN_FILE)

# Общее колличество каждого товара и сколько раз он продавался
print(allCount(OPEN_FILE))

# Используя созданную функцию, выведите на экран результат в виде таблицы из 3 столбцов: товар, колличество, количество продаж
print('{}\n| {:^20} | {:^20} | {:^20} |\n{}'.format('-'*70,'Товар', 'Количество','Колличество продаж','-'*70))
for key, value in allCount(OPEN_FILE).items():
	print('| {:^20} | {:^20} | {:^20} |'.format(key, value[0], value[1]))
print('{}'.format('-'*70))