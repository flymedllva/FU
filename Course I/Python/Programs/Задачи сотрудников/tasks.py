#1. Консольное приложение +
#2. Авторизация по логину/паролю или секретному ключу +
#3. Два уровня доступа +
#4. Хранение логинов/паролей +
#5. Простейшее шифрование
#	Администратор может:
#		Регистрировать нового пользователя
#		Назначать задачи пользователям +
#		Поставить задаче любого человека "выполнено" +
#	Сотрудник может:
#		Проверить свои задачи +
#		Поставить задаче "выполнено" +

### Functions
# Open File
def openFile(FILE_NAME):
	with open(FILE_NAME, 'rb') as file_1:
		base = pickle.load(file_1)
		return base
def closeFile(FILE_NAME, base):
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
		return 'Выполнение подтвержено пользователем'
	if x == 2:
		return 'Выполнение подтвержено администратором'
	return 'Не выполнена'

### Configuration
### Access level: admin, user
import pickle
from multi_key_dict import multi_key_dict # Import multiple Dict keys

FILE_NAME = 'base.pickle'
userName = 'Flyme'
userPassword = '12345'

base = openFile(FILE_NAME) # Data base
if auth(base, userName, userPassword) != 0:
		command = ''
		currentUser = auth(base, userName, userPassword) # ['Login', 'Secret Key', 'Password', 'Privileges', 'Tasks'(1, 'Name Task')]
		tasksUser = currentUser[4] # [(1, 'Name Task'), (0, 'Name Task')]
		while command != '0':
			### Admin
			if checkPrivileges(currentUser[3]) == 'Администратор':
				print('Доступные вам команды: ')
				print('	0. Завершить программу\n	1. Мои задачи\n	2. Поставить выполено моей задаче\n	3. Новая задача\n	4. Подтвердить выполнение задачи другого пользователя\n	5. Зарегистрировать нового пользователя')
				print('\n{} выберите команду:'.format(currentUser[0]), end='')
				command = input(' ')
#				command = '4'
				
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
					try:
						if int(ready) == 1:
							ready = 2
						elif int(ready) == 0:
							pass
						else:
							print('Команда не найдена')
							break
					except Exception:
						print('Не удалось выполнить команду')
						break
					tasksUser[int(task)-1] = (int(ready), tasksUser[int(task)-1][1])
				if command == '3':
					print(base)
					print('\nПользователи:')
					for num,keys in enumerate(base.keys()):
						print('   {}'.format(keys[0]))
					try:
						userNum = input('Введите имя пользователя, которому хотите дать новую задачу: ')
						selectedUserTasks = base[userNum][4]
						newTask = input('Введите новую задачу: ')
						selectedUserTasks.append((0,newTask))
					except Exception:
						print('\nОшибка при обработке данных\nВыход...')
						break
				if command == '4':
					print(base)
					print('\nПользователи:')
					for num,keys in enumerate(base.keys()):
						print('   {}'.format(keys[0]))
					try:
						userNum = input('Введите имя пользователя, у которого требуется изменить готовность задачи: ')
						selectedUserTasks = base[userNum][4]
						print('\nЗадачи {}:'.format(userNum))
						for num,i in enumerate(selectedUserTasks):
							print('	(№{}) Задача {} {}'.format(num+1, checkCompliteTask(i[0]), i[1]))
						print('\nВведите номер задачи, готовность которой, требуется изменить: ', end='')
						task = input()
						selectedUserTasks[int(task)-1] = (int(input('Выберите выполнена ли задача\n	1 – Выполнение подтвержено пользователем\n	2 – Выполнение подтвержено администратором\n	0 – не выполнена\n')), selectedUserTasks[int(task)-1][1])
						print(selectedUserTasks[int(task)-1])
					except Exception:
						print('\nОшибка при обработке данных\nВыход...')
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
					if ready == 1 or ready == 0:
						tasksUser[int(task)-1] = (int(ready), tasksUser[int(task)-1][1])
					else:
						print('Недостаточно прав')			
			### Other User
			else:
				print('Неизвестный пользователь')
			closeFile(FILE_NAME, base)
				
else:
	print('Авторизация прошла неудачно\nЗавершение программы...')








