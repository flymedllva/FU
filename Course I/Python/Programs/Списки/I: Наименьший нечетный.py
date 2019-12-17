# I: Наименьший нечетный
#
# Выведите значение наименьшего нечетного элемента списка, а если в списке нет нечетных элементов - выведите число 0.

import sys

numbers = list(map(int, "0 1 2 3 4".split(" ")))

n = sys.maxsize

for i in numbers:
    if i < n and i % 2 != 0 and i != 0:
        n = i

if n == sys.maxsize:
    print(0)
else:
    print(n)
