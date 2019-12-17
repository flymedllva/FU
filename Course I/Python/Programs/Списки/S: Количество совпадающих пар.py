# S: Количество совпадающих пар
#
# Дан список чисел. Посчитайте, сколько в нем пар элементов, равных друг другу.
# Считается, что любые два элемента, равные друг другу образуют одну пару, которую необходимо посчитать.

numbers = list(map(int, "1 1 1 1 1".split(" ")))

amount = 0

for i in range(len(numbers)):
    item = numbers[i]
    for j in range(i + 1, len(numbers)):
        if item == numbers[j]:
            amount += 1

print(amount)
