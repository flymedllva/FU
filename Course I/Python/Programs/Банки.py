#	Имеется 2 банка.
#	Первый банк ежемесячно начисляет 1.1% от первоначально вложенной суммы (простые проценты).
#	Второй банк ежемесячно начисляет 1% от накопленной к этому моменту суммы (сложные проценты).
#	В каждый из банков в месяц 0 (начальный момент) положили 100 000 руб.
#   Напишите программу, которая выводит на экран в виде таблицы накопленные в этих банках суммы для 24 месяцев.
#	Определите в программе и выведите на экран в какой банк выгоднее вложить деньги на 1 год и на 2 года.
	
#months = 24 # Колличество месяцев
#bank_amount = 100000 # Изначальная сумма в банке
#bank_one = bank_amount
#bank_one_buff = []
#bank_two = bank_amount
#bank_two_buff = []
#for i in range(1,months+1):
#	bank_one = bank_one + (bank_amount * 0.011)
#	bank_one_buff.append(bank_one)
#for i in range(1,months+1):
#	bank_two = bank_two * 1.011
#	bank_two_buff.append(bank_two)
#print('|{:>2}{:>9}  |{:>8}|'.format('','1 банк', '2 банк'))
#
#for i in range(len(bank_two_buff)):
#	print('|{:>2} – {:<8}|{:>8}|'.format(i+1,round(bank_one_buff[i]), round(bank_two_buff[i])))
#	
#if bank_one_buff[len(bank_one_buff)-1] > bank_two_buff[len(bank_two_buff)-1]:
#	print('Выгоднее вложить в первый банк')
#else:
#	print('Выгоднее вложить во 2 банк')
	
''' 2 version '''

months = 24 # Колличество месяцев
bank_amount = 100000 # Изначальная сумма в банке
bank_one = bank_amount
bank_two = bank_amount
print('|{:>2}{:>9}  |{:>8}|'.format('','1 банк', '2 банк'))
for i in range(1,months+1):
	bank_one = bank_one + (bank_amount * 0.011)
	bank_two = bank_two * 1.011
	print('|{:>2} – {:<8}|{:>8}|'.format(i+1,round(bank_one), round(bank_two)))

if bank_one > bank_two:
	print('Выгоднее вложить в первый банк')
else:
	print('Выгоднее вложить во 2 банк')