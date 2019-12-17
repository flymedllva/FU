# Z: Большой сдвиг
#
# Дан список из N (1≤N≤100000) целых чисел и число K (|K|<100000).
# Циклически сдвиньте список на |K| элементов вправо, если K – положительное и влево, если отрицательное число.
#
# Программа получает на вход список целых чисел, затем число K.
#
# Решение должно иметь сложность O(N), то есть не должно зависеть от K. Дополнительным списком пользоваться нельзя.

numbers = list(map(int, "5 3 7 4 6".split(" ")))
K = 3
while K > len(numbers):
    K -= len(numbers)
numbers = numbers[K - 1:] + numbers[:K - 1]
print(numbers)

# n1 = reversed(numbers[:K - 1])
# n2 = reversed(numbers[K - 1:len(numbers)])
# numbers = reversed(list(n1) + list(n2))
# print(list(numbers))

