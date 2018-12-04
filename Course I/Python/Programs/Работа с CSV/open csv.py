def openCSV(FILENAME):
	with open(FILENAME, 'r', errors='ignore') as file1:
		from csv import reader
		users = {}
		file1 = reader(file1)
		for i in file1:
			if i[0] == 'username':
				pass
			else:
				user = i[2]
				users[user] = i[3] + ' ' + i[4] + ', ' + i[1] + ', ' + i[0]
		return users
print(openCSV('PI18.csv'))