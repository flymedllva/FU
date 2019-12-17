# B: Снежинка
#
# Дано нечетное число n. Создайте двумерный массив из n×n элементов, заполнив его символами "."
# (каждый элемент массива является строкой из одного символа). Затем заполните символами "*" среднюю строку массива,
# средний столбец массива, главную диагональ и побочную диагональ. В результате единицы в массиве должны образовывать
# изображение звездочки. Выведите полученный массив на экран, разделяя элементы массива пробелами.

n = 5
data = [["." for j in range(n)] for i in range(n)]

for i in range(len(data)):
    for j in range(len(data[i])):
        print(i + j, end="")
    print("")


for i in range(len(data)):
    for j in range(len(data[i])):
        if i == j or i + j == len(data[i]) - 1 or int(len(data[i]) / 2) == j:
            data[i][j] = "*"
        elif i == int(n / 2):
            data[i] = ["*" for j in range(len(data[i]))]

for i in data:
    print("".join(i))