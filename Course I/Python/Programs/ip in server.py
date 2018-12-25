### Имеются логи с двух серверов. Необходимо узнать на какой сервер заходили чаще
### Логи приходят в виде текста, каждая строка которого имеет вид: 
#			"номер сервера	ip сервера	путь до файла, который открыл пользователь"
## Пример вывода:
#	   178.78.82.1 чаще заходил на 1-й сервера
#	 202.27.11.181 заходил только на 1-й сервер
#	126.31.163.222 заходил только на 1-й сервер
#	154.164.149.83 заходил на оба сервера одинаковое колличество раз
#	 102.27.11.181 заходил только на 1-й сервер
#	226.74.123.135 заходил только на 1-й сервер
#  157.109.106.104 заходил только на 1-й сервер
#	121.31.163.222 заходил только на 1-й сервер
#	226.74.121.135 чаще заходил на 2-й сервера
#		 127.0.0.0 заходил на оба сервера одинаковое колличество раз
#	 202.27.12.181 заходил только на 2-й сервер
#	67.123.248.174 заходил только на 2-й сервер

def countIP(log):
	ipList = {}
	for line in log:
		if ipList.get(line[1]):
			ipList[line[1]] = ipList[line[1]] + 1
		else:
			ipList[line[1]] = 1
	return ipList
	
def conutServerIP(log1, log2):
	return {line: (log1.get(line), log2.get(line)) for line in {**log1, **log2}}
	
log1 = '''1446792139	178.78.82.1	/sphingosine/shop.css
1446792139	202.27.11.181	/myl/hello.rtf
1446792139	126.31.163.222	/accentually.js
1446792139	154.164.149.83	/pyroacid/unkemptly.jpg
1446792139	202.27.11.181	/Chawia.js
1446792139	102.27.11.181	/as.js
1446792139	178.78.82.1	/morphographical/dismain.css
1446792139	178.78.82.1	/mock/dismain.js
1446792139	226.74.123.135	/phanerite.php
1446792139	157.109.106.104	/bisonant.css
1446792139	202.27.11.181	/local.doc
1446792139	178.78.82.1	/arnold/site.css
1446792139	126.31.163.222	/tresh.css
1446792139	121.31.163.222	/loc.js
2416392139	226.74.121.135	/shop.php
2416392139	127.0.0.0	/qwerty.css'''
log2 = '''2416392139	178.78.82.1	/mysite/index.html
2416392139	226.74.121.135	/shop.php
2416392139	178.78.82.1	/accentually.js
2416392139	226.74.121.135	/items.lock
2416392139	154.164.149.83	/pyroacid/unkemptly.jpg
2416392139	202.27.12.181	/Chawia.js
2416392139	67.123.248.174	/morphographical/dismain.css
2416392139	226.74.121.135	/phanerite.php
2416392139	67.123.248.174	/bisonant.css
2416392139	127.0.0.0	/qwerty.css'''
log1 = countIP(list(map(lambda x: x.split('\t'), log1.split('\n'))))
log2 = countIP(list(map(lambda x: x.split('\t'), log2.split('\n'))))
from time import sleep
for ip, items in conutServerIP(log1, log2).items():
	sleep(0.02)
	if items[1] == None or items[0] == None:
		if items[0] != None:
			print(f'{ip:>16} заходил только на 1-й сервер')
		if items[1] != None:
			print(f'{ip:>16} заходил только на 2-й сервер')
	else:
		if items[0] > items[1]:
			print(f'{ip:>16} чаще заходил на 1-й сервера')
		elif items[0] < items[1]:
			print(f'{ip:>16} чаще заходил на 2-й сервера')
		else:
			print(f'{ip:>16} заходил на оба сервера одинаковое колличество раз')