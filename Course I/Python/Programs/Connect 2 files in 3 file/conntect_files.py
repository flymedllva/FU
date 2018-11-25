# Соеденить 2 файла в 3, при этом отсортировать их
with open('file1.txt') as file1, open('file2.txt') as file2, open('file3.txt', 'w') as file3:
	buff_file = []
	while(True):
		line1 = file1.readline().rstrip()
		line2 = file2.readline().rstrip()
		if line1 == '' and line2 == '':
			break
		else:
			try:
				line1 = int(line1)
			except ValueError:
				pass
			else:
				buff_file.append(line1)
			try:
				line2 = int(line2)
			except ValueError:
				pass
			else:
				buff_file.append(line2)
	for i in buff_file:
		file3.write(str(i))
		if i != buff_file[len(buff_file)-1]:
			file3.write('\n')
		
		
		
		
		
		
		
		
		
		
		
		
		