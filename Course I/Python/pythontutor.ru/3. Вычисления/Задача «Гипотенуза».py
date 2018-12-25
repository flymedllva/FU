#Дано два числа a и b. Выведите гипотенузу треугольника с заданными катетами.

from math import sqrt; print((lambda a, b: sqrt(b*b + a*a))(*[int(input()) for i in range(2)]))