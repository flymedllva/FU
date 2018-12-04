# Config
title = 'Новый сайт'	# Заголовок
lang = 'ru' 	   		# Язык
encoding = 'utf-8' 		# Кодировка
tab = '    '			# Размер табуляции
cssList = ['https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.4/css/bootstrap.min.css']
jsList = ['https://ajax.googleapis.com/ajax/libs/jquery/3.0.0/jquery.min.js', 'https://cdnjs.cloudflare.com/ajax/libs/tether/1.2.0/js/tether.min.js', 'https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.4/js/bootstrap.min.js']

# Генерация шапки сайта
def header(index):
	print('<!DOCTYPE html>', file = index, end = '\n')
	print('<html lang="{}">'.format(lang), file = index, end = '\n')
	print('{}<head>'.format(tab,encoding), file = index, end = '\n' + tab*2)
	print('<meta charset="{}">'.format(encoding), file = index, end = '\n' + tab*2)
	print('<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">'.format(encoding), file = index, end = '\n' + tab*2)
	print('<meta http-equiv="x-ua-compatible" content="ie=edge">'.format(encoding), file = index, end = '\n' + tab*2)
	for i in cssList:
		print('<link rel="stylesheet" href="{}">'.format(i), file = index, end = '\n' + tab)
	print('</head>'.format(encoding), file = index, end = '\n' + tab)
# Генерация основы сайта
def body(index):
	print('<body>'.format(encoding), file = index, end = '\n')
	print('{}<h1>{}</h1>'.format(tab*2,title), file = index, end = '\n' + tab)
	for i in jsList:
			print('{}<link rel="stylesheet" href="{}">'.format(tab,i), file = index, end = '\n' + tab)
	print('</body>'.format(encoding), file = index, end = '\n')
	print('</html>'.format(lang), file = index)

# Start gen
with open('index.html', 'w', encoding='utf-8') as index:
	header(index)
	body(index)
	