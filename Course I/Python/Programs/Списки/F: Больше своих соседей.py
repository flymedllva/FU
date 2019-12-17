# F: Больше своих соседей
#
# Дан список чисел. Определите, сколько в этом списке элементов,
# которые больше двух своих соседей и выведите количество таких элементов.

numbers = list(map(int, "1 0 1 0 1".split(" ")))

prev = numbers[0]
act = numbers[1]
amount = 0
for i in range(2, len(numbers)):
    if act > prev and act > numbers[i]:
        amount += 1
    prev = act
    act = numbers[i]

print(amount)