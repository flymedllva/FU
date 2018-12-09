# Следующее и предыдущее
# Напишите программу, которая считывает целое число и выводит текст, аналогичный приведенному в примере (пробелы важны!).
a = int(input())
print('The next number for the number {} is {}.\nThe previous number for the number {} is {}.'.format(a, a+1, a, a-1))