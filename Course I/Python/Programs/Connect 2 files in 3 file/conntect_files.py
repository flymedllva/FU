################################################################
####### Соеденить 2 файла в 3, при этом отсортировать их #######
################################################################

''' 
	########################
	1 version, in with + defs 
	########################
'''
# Str in Int
def inInt(n): 
	try:
		return int(n)
	except:
		return None
# Read line
def select_readline(sected_file):
	return sected_file.readline().rstrip()
with open('file1.txt') as file1, open('file2.txt') as file2, open('file3.txt', 'w') as file3:
	x = select_readline(file1)
	y = select_readline(file2)
	while (x or y) != '':
		try:
			if (inInt(y) == None) or (inInt(y) > inInt(x)):
				print(x, file = file3)
				x = select_readline(file1)
			else:
				print(y, file = file3)
				y = select_readline(file2)
		except Exception:
			print(y, file = file3)
			y = select_readline(file2)
''' 
	########################
	2 version, list 
	########################
'''
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
	buff_file.sort()
	for i in buff_file:
		file3.write(str(i))
		if i != buff_file[len(buff_file)-1]:
			file3.write('\n')

''' 
	########################
	3 version 
	########################
'''
f1 = open(r"file1.txt", "r")
f2 = open(r"file2.txt", "r")
f3 = open(r"file3.txt", "w")
s1 = (f1.readline()).strip('\n')
s2 = (f2.readline()).strip('\n')
x = s1
y = s2
def Inte(n):
	try:
		return int(n)
	except:
		return None 
while (x or y) != '':
	if Inte(x) == None:
		print(y, file = f3)
		y = (f2.readline()).strip('\n')
	elif Inte(y) == None:
		print(x, file = f3)
		x = (f1.readline()).strip('\n')
	elif (Inte(x) < Inte(y)):
		print(x, file = f3)
		x = (f1.readline()).strip('\n')
		
	else:
		print(y, file = f3)
		y = (f2.readline()).strip('\n')
f1.close()
f2.close()
f3.close()