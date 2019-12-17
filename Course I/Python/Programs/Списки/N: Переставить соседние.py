# N: Переставить соседние
#
# Переставьте соседние элементы списка (A[0] c A[1], A[2] c A[3] и т.д.).
# Если элементов нечетное число, то последний элемент остается на своем месте.

numbers = sorted(map(int, "1 2 3 4 5".split(" ")))

for i in range(len(numbers)):
    if i % 2 == 0 and i + 1 < len(numbers):
        numbers[i], numbers[i + 1] = numbers[i + 1], numbers[i]

print(numbers)
