#	XOR-шифрование
# 	Написать функцию XOR_cipher, принимающая 2 аргумента: строку, которую нужно зашифровать, и ключ шифрования, которая возвращает строку, зашифрованную путем применения функции XOR (^) над символами строки с ключом. Написать также функцию XOR_uncipher, которая по зашифрованной строке и ключу восстанавливает исходную строку.

def XOR_cipher(text, key):
	try:
		cipher_text = [chr(ord(x) + int(len(key)-10+int(key[0]))) for x in text]
		cipher_text = ''.join(cipher_text)
		print('Текст "{}" зашифрован ключем "{}" -> "{}"'.format(text, key, cipher_text))
		return cipher_text
	except Exception:
		print('Произошла ошибка во время зашифровки ключа')

def XOR_uncipher(text, key):
	try:
		cipher_text = [chr(ord(x) - int(len(key)-10+int(key[0]))) for x in text]
		cipher_text = ''.join(cipher_text)
		print('Текст "{}" расшифрован ключем "{}" -> "{}"'.format(text, key, cipher_text))
		return cipher_text
	except Exception:
		print('Произошла ошибка во время расшифровки ключа')

#Configs
key = '14321'
text = 'Привет мир!'

cript_key = '14321'
cript_text = 'ЛмдЮбоидм'

# Start program
XOR_cipher(text, key)
XOR_uncipher(cript_text, cript_key)