# D: Больше предыдущего
#
# Дан список чисел. Выведите все элементы списка, которые больше предыдущего элемента.

numbers = list(map(int, "1 5 2 4 3".split(" ")))

prev = numbers[0]
for number in numbers:
    if number > prev:
        print(number, end=" ")
    prev = number
