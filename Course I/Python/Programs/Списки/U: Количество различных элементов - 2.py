# U: Количество различных элементов - 2
#
# Дан список. Посчитайте, сколько в нем различных элементов, не изменяя самого списка.

numbers = list(map(int, "3 2 1 2 3".split(" ")))

data = list()
for i in range(len(numbers)):
    check = False
    for j in range(len(data)):
        if numbers[i] == data[j]:
            check = True
            break
    if not check:
        data.append(numbers[i])
print(len(data))
