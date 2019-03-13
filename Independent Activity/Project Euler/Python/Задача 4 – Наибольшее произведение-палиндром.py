# 
#  Задача 4
#  Наибольшее произведение-палиндром
# 
#  Created by Дмитрий Гриднев on 09/03/2019.
#  Copyright © 2019 Dmitry Gridnev. All rights reserved.
# 
#  Число-палиндром с обеих сторон (справа налево и слева направо) читается одинаково.
#  Самое большое число-палиндром, полученное умножением двух двузначных чисел – 9009 = 91 × 99.
#  Найдите самый большой палиндром, полученный умножением двух трехзначных чисел.
# 

maxNumber = 0
for i in range(100, 999):
	for j in range(100, 999):
		number = str(i * j)
		reversedNumber = number[::-1]
		if reversedNumber == number:
			if int(number) > maxNumber:
				maxNumber = int(number)
print(maxNumber)
