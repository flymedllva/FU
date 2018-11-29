####
def viewBoard(): # Print board
	for i,x in enumerate(board):
		if i == 0:
			pass
		elif i % 3 == 0:
			print(x, end='\n')
		else:
			print(x, end=' | ')
def newMove(movePlayer):
	global board
	global move
	if type(board[movePlayer]) != int:
		print('Сюда уже ходили')
	else:
		board[movePlayer] = move
		# New move
		if move == 'o':
			move = 'x'
		else:
			move = 'o'
def checkWin():
	global move
	global win
	for cell in win:
		for pod in board:
			if (board[cell[0]] == 'x') and (board[cell[1]] == 'x') and (board[cell[2]] == 'x'):
				print('Победа x')
				move = ''
				break
			elif (board[cell[0]] == 'o') and (board[cell[1]] == 'o') and (board[cell[2]] == 'o'):
				print('Победа o')
				move = ''
				break		
	
		
# Config
board = [i for i in range(0,10)] # Generate board
win = [[1,2,3],[4,5,6],[7,8,9],[1,4,7],[2,5,8],[3,6,9],[1,5,9],[3,5,7]]
# Start program

print('------------------------------------')
move = str(input('Введите чей ход первый (О или Х): '))
print('------------------------------------')

while move:
	viewBoard()
	print('Ход ', move)
	movePlayer = int(input('Введите куда вы хотите пойти: '))
	newMove(movePlayer)
	checkWin()