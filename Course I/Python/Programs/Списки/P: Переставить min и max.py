# P: Переставить min и max
#
# В списке все элементы различны. Поменяйте местами минимальный и максимальный элемент этого списка.

import sys

numbers = list(map(int, "3 4 5 2 1".split(" ")))

mi = 0
ma = 0

for i in range(len(numbers)):
    if numbers[i] > numbers[ma]:
        ma = i
    elif numbers[i] < numbers[mi]:
        mi = i

numbers[mi], numbers[ma] = numbers[ma], numbers[mi]
print(numbers)
