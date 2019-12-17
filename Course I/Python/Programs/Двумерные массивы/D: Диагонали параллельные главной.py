# D: Диагонали параллельные главной
#
# Дано число n. Создайте массив размером n×n и заполните его по следующему правилу.
# На главной диагонали должны быть записаны числа 0. На двух диагоналях, прилегающих к главной, числа 1.
# На следующих двух диагоналях числа 2, и т.д.

n = 5

data = list()
for i in range(n):
    line = list()
    for j in range(n):
        number = j - i
        if number < 0:
            number = -number
        line.append(number)
    data.append(line)


for i in data:
    print("".join(map(str, i)))
