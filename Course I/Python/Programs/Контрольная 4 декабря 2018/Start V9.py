def fileOpen(FILE_NAME):
	with open(FILE_NAME) as file_1:
		listC = []
		for line in file_1:
			line = line.rstrip().split(': ')
			listC.append((line[0], int(line[1].split(', ')[0]), int(line[1].split(', ')[1]), int(line[1].split(', ')[2])))
		return listC
def maxAndMinO(OPENED_FILE, numd):
	maxium = OPENED_FILE[0][numd]
	minimum = OPENED_FILE[0][numd]
	for line in OPENED_FILE:
		if line[numd] > maxium:
			maxium = line[numd]
		if line[numd] < minimum:
			minimum = line[numd]
	return (maxium,minimum)

# Config
FILE_NAME = 'Товары9.txt' 
OPENED_FILE = fileOpen(FILE_NAME)
numd = 3 # - номер дисциплины

# Start program
print(OPENED_FILE) # 1
print(maxAndMinO(OPENED_FILE, numd))
