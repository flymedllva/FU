#
# Задача 3
# Наибольший простой делитель
#
#  Created by Дмитрий Гриднев on 09/03/2019.
#  Copyright © 2019 Dmitry Gridnev. All rights reserved.
#
# Простые делители числа 13195 - это 5, 7, 13 и 29.
# Каков самый большой делитель числа 600851475143, являющийся простым числом?
#
n = 600851475143
max_factor = 1
d = 2
while (d < n):
	if (n % d == 0):
		# Сейчас d - простой делитель
		max_factor = d;
		n /= d;
	else:
		d += 1
		
if (n != 1):
	# Сейчас n - простой делитель
	max_factor = n
			
print(int(max_factor))