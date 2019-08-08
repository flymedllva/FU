#	Удалить первые буквы слов
#	Дана строка символов, которая обязательно заканчивается символом точки. Удалить из строки первые буквы каждого слова.
	
string = "Удалить из строки первые буквы каждого слова и ничего не забыть."
kar = 1
_string = ""
for i in range(len(string)):
	if kar == 1:
		kar -= 1
		continue
	if string[i] == " ":
		kar += 1
		_string += string[i]
	else: _string += string[i]
print(_string)