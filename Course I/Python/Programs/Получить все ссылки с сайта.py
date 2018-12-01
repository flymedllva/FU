# Получить все ссылки с сайта
def urlInSite(url):
	from urllib.request import urlopen
	from re import findall
	with urlopen(url) as htmlFile:
		data = htmlFile.read().decode('utf-8')
		urls = findall(r'href=[\'"]?([^\'" >]+)', data)
		allUrls = []
		for i in urls:
			url = findall(r'https://[\'"]?([^\'" >]+)', i)
			if url:
				allUrls.append('https://' + url[0])
		return(allUrls)
		
url = "https://google.com"
print(urlInSite(url))