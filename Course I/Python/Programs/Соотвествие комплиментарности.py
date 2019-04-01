def compl(name):
	newDnk = ""
	for i in name.upper():
		if i == "A" or i == "А":
			newDnk += "Т"
		if i == "Г" or i == "G":
			newDnk += "Ц"
	return newDnk
print(compl(input("Введите строку для преобразования: ")))