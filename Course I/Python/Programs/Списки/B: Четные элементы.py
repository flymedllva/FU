# B: Четные элементы
#
# Выведите все четные элементы списка.

numbers = list(map(int, "1 2 2 3 3 3 4".split(" ")))

for number in numbers:
    if number % 2 == 0:
        print(number, end=" ")