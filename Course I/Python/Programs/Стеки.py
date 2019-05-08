"""
	Stacks
"""

#	Значением переменной S является текст, содержащий три вида скобок: (), [] и {}. Проверьте правильность расстановки скобок в тексте, т.е. имеется ли для каждой открывающей скобки соответствующая закрывающая скобка и наоборот, а также, не нарушены ли правила вложенности скобок. Символы, не являющиеся скобками, игнорируйте.
def matchedOne(string):
	count = 0
	for i in string:
		if i == "(" or i == "[" or i == "{": count += 1
		elif i == ")" or i == "]" or i == "}": count -= 1
		if count < 0: return False
	return count == 0
	
def matchedTwo(string):
	bufferList=[]
	for word in range(len(string)):
		if string[word] == '(' or string[word] == '[' or string[word] == '{':
			bufferList.append('(')
		elif string[word] ==')' or string[word] == ']' or string[word] == '}' :
			if not bufferList:
				return False
			else:
				bufferList.pop()
	if not bufferList:
		return True
	else:
		return False
		
jj = "3 + 323 [2(223 + 32 [3949 + 342]])"
jj = "fgfggfgf (ktktk {yy tjjjtjj [jjjjj]gg)}"
print(matchedTwo(jj))

#	Напишите программу c использованием стека, которая переводит заданное десятичное число N в систему счисления с основанием p (p ≤ 16). Результатом является строка, соответствующая вычисленному значению. 
def convert(number, base):
	if number == base:
		return number
	if not(2 <= base <= 16):
		return None
	listConverted = []
	while number > 0:
		nextNumber = str(number % base)
		if 10 <= int(nextNumber) <= 16:
			listConverted.append({n + 10: word for n, word in enumerate("ABCDEFGHIJKLMNOPQRSTUVWXYZ")}[int(nextNumber)])
		else:
			listConverted.append(nextNumber)
		number //= base
	return "".join(reversed(listConverted))
print(convert(1001456789022, 14))