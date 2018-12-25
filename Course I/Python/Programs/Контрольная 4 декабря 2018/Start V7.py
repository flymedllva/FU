# Функция ищет минимум и максиум
def maxAmin(name, num):
	maxx = minn = int(list(name.items())[0][1].split(', ')[0])
	for key, item in name.items():
		item = item.split(', ')
		if int(item[num-1]) > maxx: maxx = int(item[num-1])
		if int(item[num-1]) < minn: minn = int(item[num-1])
	return maxx, minn
		
# Первое – сгенерировать словарь
with open('Оценки.txt') as f1:
	name = {}
	for line in f1:
		line = line.rstrip().split(': ')
		name[line[0]] = line[1]

num = 2 # номер дисциплины
print(maxAmin(name, 2)) # Вызов функции максиума и минимума

# Используя созданную функцию вычислите оценку по всем дисциплинам
print('Оценки по дисциплинам: ')
for i in range(1,4):
	mm = maxAmin(name, i)
	print(f'Дисциплина №{i}: {mm[0]} {mm[1]}')