# L: Вывести в обратном порядке
#
# Выведите элементы данного списка в обратном порядке, не изменяя сам список.

numbers = sorted(map(int, "1 2 3 4 5".split(" ")))

len_n = len(numbers)
for i in range(len_n):
    print(len_n - i, end=" ")