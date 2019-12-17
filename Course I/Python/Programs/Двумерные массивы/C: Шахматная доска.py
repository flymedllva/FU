# C: Шахматная доска
#
# Даны два числа n и m. Создайте двумерный массив размером n×m и заполните его символами "." и "*" в шахматном порядке.
# В левом верхнем углу должна стоять точка.

n, m = 3, 4

data = list()
for i in range(n):
    line = list()
    if i % 2 == 0:
        data.append(["." if j % 2 == 0 else "*" for j in range(m)])
    else:
        data.append(["*" if j % 2 == 0 else "." for j in range(m)])

for i in data:
    print("".join(i))