def fileOpen(FILE_NAME):
	with open(FILE_NAME) as file_1:
		return {i.rstrip().split(' ')[0]: int(i.rstrip().split(' ')[1]) for i in file_1}
def expensiveGoods(OPENED_FILE):
	maxium = [['', 0]]
	for key,item in OPENED_FILE.items():
		if item > maxium[0][1]:
			maxium = [[key, item]]
		elif item == maxium[0][1]:
			maxium.append([key, item])
	return maxium
def fileWrite(FILE_NAME_TWO, expensiveGoods):
	with open(FILE_NAME_TWO, 'w') as file_1:
		for i in expensiveGoods:
			print('{} {}'.format(i[0], round(i[1]*0.9)), file = file_1)
		
# Config
FILE_NAME = 'Товары1.txt' 
FILE_NAME_TWO = 'Товары1_new.txt' 
OPENED_FILE = fileOpen(FILE_NAME)

# Start program
print(OPENED_FILE) # 1
print(expensiveGoods(OPENED_FILE)) # 2
fileWrite(FILE_NAME_TWO, expensiveGoods(OPENED_FILE)) # 3