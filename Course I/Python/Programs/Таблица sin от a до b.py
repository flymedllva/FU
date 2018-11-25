## Посчитать синус от a до b
from math import sin
a = -2
b = 4
while a <= b:
	sums = sin(a)
	print("x = {:>.2f}  |  sin(x) = {:>6.2f}".format(a,sums))
	a += 0.1