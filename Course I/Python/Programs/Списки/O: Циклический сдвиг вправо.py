# O: Циклический сдвиг вправо
#
# Циклически сдвиньте элементы списка вправо (A[0] переходит на место A[1], A[1] на место A[2], ...,
# последний элемент переходит на место A[0]).
#
# Используйте минимально возможное количество операций присваивания.

numbers = sorted(map(int, "1 2 3 4 5".split(" ")))

for i in reversed(range(len(numbers))):
    if i <= len(numbers) and i != 0:
        numbers[i], numbers[i - 1] = numbers[i - 1], numbers[i]

print(numbers)
