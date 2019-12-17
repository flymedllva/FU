# T: Уникальные элементы
#
# Дан список. Выведите те его элементы, которые встреча ются в списке только один раз.
# Элементы нужно выводить в том порядке, в котором они встречаются в списке.

numbers = list(map(int, "1 2 2 3 3 3".split(" ")))

data = list()
for i in range(len(numbers)):
    for j in range(len(numbers)):
        if i != j and numbers[i] == numbers[j]:
            break
    else:
        data.append(numbers[i])
print(data)

for i in range(10):
    break
else:
    print("gg")

for i in numbers:
    if numbers.count(i) == 1:
        print(i)
