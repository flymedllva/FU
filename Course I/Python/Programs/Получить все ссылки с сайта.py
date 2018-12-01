# Получить все ссылки с сайта
def urlInSite(url):
	from urllib.request import urlopen
	from re import findall
	try:
		with urlopen(url) as htmlFile:
			data = htmlFile.read().decode('utf-8')
			urls = findall(r'href=[\'"]?([^\'" >]+)', data)
			allUrls = []
			for i in urls:
				url = findall(r'https://[\'"]?([^\'" >]+)', i)
				if url:
					allUrls.append('https://' + url[0])
			return(allUrls)
	except Exception:
		print('Не получить данные с сайта')
		return []
		
url = "https://google.com"
print(urlInSite(url))
