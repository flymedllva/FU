#1. Консольное приложение +
#2. Авторизация по логину/паролю или секретному ключу +
#3. Два уровня доступа +
#4. Хранение логинов/паролей +
#	Администратор может:
#		Регистрировать нового пользователя
#		Назначать задачи пользователям
#		Подтвердить выполнение
#	Сотрудник может:
#		Проверить свои задачи +
#		Поставить задаче "выполнено" +

### Functions
# Open File
def openFile(FILE_NAME):
	with open(FILE_NAME, 'rb') as file_1:
		base = pickle.load(file_1)
		return base
def closeFile(FILE_NAME):
	with open(FILE_NAME, 'wb') as file_1:
		return pickle.dump(base, file_1)
# Authorization
def auth(base, userName, userPassword):
	try:
		currentUser = base[userName]
		if currentUser[2] == userPassword:
			return currentUser
		return 0
	except KeyError:
		return 0
# Check user Privileges
def checkPrivileges(x):
	if x == 'admin':
		return 'Администратор'
	elif x == 'user':
		return 'Пользователь'
	return 'Неизвестная группа'
# Check Complite Task
def checkCompliteTask(x):
	if x == 1:
		return 'Выполнена'
	return 'Не выполнена'

### Configuration
### Access level: admin, user
import pickle
from multi_key_dict import multi_key_dict # Import multiple Dict keys

FILE_NAME = 'base.pickle'
userName = 'Flyme'
userPassword = '12345'

base = openFile(FILE_NAME) # Data ase
print(base)
if auth(base, userName, userPassword) != 0:
		command = ''
		currentUser = auth(base, userName, userPassword) # ['Login', 'Secret Key', 'Password', 'Privileges', 'Tasks'(1, 'Name Task')]
		tasksUser = currentUser[4] # [(1, 'Name Task'), (0, 'Name Task')]
		while command != '0':
			### Admin
			if checkPrivileges(currentUser[3]) == 'Администратор':
				print('Доступные вам команды: ')
				print('	0. Завершить программу\n	1. Мои задачи\n	2. Поставить выполено моей задаче\n	3. Новая задача\n	4. Подтвердить выполнение\n	5. Регистрировать нового пользователя')
				print('\n{} выберите команду:'.format(currentUser[0]), end='')
				command = input(' ')
				
				if command == '1':
					print('\nМои задачи:')
					for num,i in enumerate(tasksUser):
						print('	(№{}) {} – {}'.format(num+1, checkCompliteTask(i[0]), i[1]))
				if command == '2':
					print('\nМои задачи:')
					for num,i in enumerate(tasksUser):
						print('	(№{}) {} – {}'.format(num+1, checkCompliteTask(i[0]), i[1]))
					print('\nВыберите номер вашей задачи, которой требуется изменить готовность: ', end='')
					task = input()
					ready = input('Выберите выполнена ли задача\n	1 – выполнена\n	0 – не выполнена\n')
					tasksUser[int(task)-1] = (int(ready), tasksUser[int(task)-1][1])
				if command == '3':
					print(base)
					print('\nПользователи:')
					for num,keys in enumerate(base.keys()):
						print('   {}'.format(keys[0]))
					try:
						userNum = input('Введите имя пользователя, которому хотите дать новую задачу: ')
						selectedUserTasks = base['Flyme'][4]
						newTask = input('Введите новую задачу: ')
						selectedUserTasks.append((0,newTask))
					except Exception:
						print('\nОшибка при обработке данных\nВыход...')
						break
					break
			
			### User
			elif checkPrivileges(currentUser[3]) == 'Пользователь':
				print('Доступные вам команды: ')
				print('	0. Завершить программу\n	1. Мои задачи\n	2. Поставить выполено моей задаче')
				print('\n{} выберите команду:'.format(currentUser[0]), end='')
				command = input(' ')
				if command == '1':
					print('\nМои задачи:')
					for num,i in enumerate(tasksUser):
						print('	(№{}) {} – {}'.format(num+1, checkCompliteTask(i[0]), i[1]))
				if command == '2':
					print('\nМои задачи:')
					for num,i in enumerate(tasksUser):
						print('	(№{}) {} – {}'.format(num+1, checkCompliteTask(i[0]), i[1]))
					print('\nВыберите номер вашей задачи, которой требуется изменить готовность: ', end='')
					task = input()
					ready = input('Выберите выполнена ли задача\n	1 – выполнена\n	0 – не выполнена\n')
					tasksUser[int(task)-1] = (int(ready), tasksUser[int(task)-1][1])				
			### Other User
			else:
				print('Неизвестный пользователь')
				
else:
	print('Авторизация прошла неудачно\nЗавершение программы...')








