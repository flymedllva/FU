# V: Самое частое число
#
# Дан список. Не изменяя его и не используя дополнительные списки, определите,
# какое число в этом списке встречается чаще всего.
#
# Если таких чисел несколько, выведите любое из них.

numbers = list(map(int, "1 2 3 2 3 3".split(" ")))

number = 0
count = 0
for i in range(len(numbers)):
    number_i = numbers[i]
    count_i = 0
    for j in range(i + 1, len(numbers)):
        if numbers[j] == number_i:
            count_i += 1
    if count < count_i:
        number = number_i
        count = count_i

print(number)
