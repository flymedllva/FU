# Simple cip
def cipher(text, key):
	try:
		cipher_text = [chr(ord(x) + int(len(key)-10+int(key[0]))) for x in text]
		cipher_text = ''.join(cipher_text)
		print('Текст "{}" зашифрован ключем "{}" -> "{}"'.format(text, key, cipher_text))
		return cipher_text
	except Exception:
		print('Произошла ошибка во время зашифровки ключа')

def uncipher(text, key):
	try:
		cipher_text = [chr(ord(x) - int(len(key)-10+int(key[0]))) for x in text]
		cipher_text = ''.join(cipher_text)
		print('Текст "{}" расшифрован ключем "{}" -> "{}"'.format(text, key, cipher_text))
		return cipher_text
	except Exception:
		print('Произошла ошибка во время расшифровки ключа')

# Authorization
		
#1. Консольное приложение +
#2. Авторизация по логину/паролю или секретному ключу +
#3. Два уровня доступа +
#4. Хранение логинов/паролей
#	Администратор может:
#		Регистрировать нового пользователя
#		Назначать задачи пользователям
#		Подтвердить выполнение
#	Сотрудник может:
#		Проверить свои задачи +
#		Поставить задаче "выполнено"

def auth(base, userName, userPassword):
	try:
		currentUser = base[userName]
		if currentUser[2] == userPassword:
			return currentUser
		return 0
	except KeyError:
		return 0
def checkPrivileges(x):
	if x == 'admin':
		return 'Администратор'
	elif x == 'user':
		return 'Пользователь'
	return 'Неизвестная группа'
def checkCompliteTask(x):
	if x == 1:
		return 'Выполнена'
	return 'Не выполнена'

# Configuration
# Access level: admin, user
from multi_key_dict import multi_key_dict # Import multiple Dict keys

# Multi Dict
base = multi_key_dict( {
						('Flyme', 'qwerty'): ['Flyme', 'qwerty', '12345', 'admin', [(1, 'Сделать Дз'), (0, 'Вынести мусор')] ],
						('Ivan', 'qwertu'): ['Ivan', 'qwertu', '12345', 'user', [(0, 'Выучить историю'), (1, 'Приготовиться к худшему')] ]
					  } )
userName = 'qwertu'
userPassword = '12345'

if auth(base, userName, userPassword) != 0:
		command = ' '
		currentUser = auth(base, userName, userPassword) # ['Login', 'Secret Key', 'Password', 'Privileges', 'Tasks'(1, 'Name Task')]
		tasksUser = currentUser[4] # [(1, 'Name Task'), (0, 'Name Task')]
		print(currentUser,tasksUser)
		while command:
			if checkPrivileges(currentUser[3]) == 'Администратор':
				print('Доступные вам команды: ')
				print('	1. Мои задачи\n	2. Поставить выполено моей задаче\n	3. Регистрировать нового пользователя\n	4. Подтвердить выполнение')
				print('\n{} выберите команду:'.format(currentUser[0]))
				command = '1'
				if command == '1':
					print('\nМои задачи:')
					for num,i in enumerate(tasksUser):
						print('	(№{}) {} – {}'.format(num+1, checkCompliteTask(i[0]), i[1]))
				
			elif checkPrivileges(currentUser[3]) == 'Пользователь':
				print('Доступные вам команды: ')
				print('	1. Мои задачи\n	2. Поставить выполено моей задаче')
				print('\n{} выберите команду:'.format(currentUser[0]))
				command = '2'
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
					ready = input('Выберите выполнена ли задача\n	1 – выполнена\n	2 – не выполнена\n')
					tasksUser[int(task)-1] = (int(ready), tasksUser[int(task)-1][1])
					print(base)
				
				
			else:
				print('Неизвестный пользователь')
				
				
			
			break
else:
	print('Авторизация прошла неудачно\nЗавершение программы...')





#m = multi_key_dict()
#m['aa', 12] = [1,2]
#m['bb', 1] = 'cc and 1'
#m['cc', 13] = 'something else'
#
#
#print(m)
#print(m['aa'])













