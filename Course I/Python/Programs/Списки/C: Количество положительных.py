# C: Количество положительных
#
# Найдите количество положительных элементов в данном списке.

numbers = list(map(int, "1 -2 3 -4 5".split(" ")))

positive = 0
for number in numbers:
    if number > 0:
        positive += 1

print(positive)