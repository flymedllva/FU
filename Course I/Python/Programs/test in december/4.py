#	Имеется текстовый файл, содержащий информацию о товарах и ценах на них. Каждая строка файла имеет вид: НАЗВАНИЕ ТОВАРА: ЦЕНА.
#	Напишите функцию, которая возвращает цену товара или -1, если цена не известна. Параметрами функции являются название товара и имя файла.
#	Покупка задается в виде списка кортежей (товар, количество). Вычислите общую стоимость покупки.
#	Найдите самый дорогой товар в покупке. Выведите на экран его название, цену и количество.
	
def priceGoods(goodsName,fileName): # возращает цену товара или -1 если его нет
	with open(fileName) as file1:
		while True:
			line = file1.readline().rstrip().split(': ')
			if line[0] == goodsName:
				return int(line[1])
			elif line == ['']:
				return -1
			else:
				continue
			
productName = 'Молоко' # Для проверки функции
fileName = 'file1.txt' # Открываемый файл
goodsList = [('Молоко', 2), ('Хлеб', 3)] # Список кортежей покупки
totalCost = maxPrice = 0

print('{}, его цена = {}'.format(productName, priceGoods(productName,fileName)))

for i in goodsList:
	totalCost += priceGoods(i[0],fileName)*i[1] # Общая стоимость покупок
	if priceGoods(i[0],fileName) > maxPrice: # Самая дорогая покупка
		maxPrice = priceGoods(i[0],fileName)
		
print('Общаая стоимоть: ', totalCost)
print('Самая дорогая покупка: ', maxPrice)