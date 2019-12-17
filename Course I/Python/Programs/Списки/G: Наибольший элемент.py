# G: Наибольший элемент
#
# Дан список чисел. Выведите значение наибольшего элемента в списке, а затем индекс этого элемента в списке.
# Если наибольших элементов несколько, выведите индекс первого из них.

numbers = list(map(int, "1 2 3 2 1".split(" ")))

nmax, nindx = 0, 0
for i in range(len(numbers)):
    if numbers[i]> nmax:
        nmax = numbers[i]
        nindx = i

print(nmax, nindx)