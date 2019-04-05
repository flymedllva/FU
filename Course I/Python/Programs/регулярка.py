import re

phone = 'Телефон 123-12-12'

print( re.findall(r'\d{2}', phone) )

print( re.search(r'\d\d\D\d\d', phone)[0] )

print( re.search(r'\d{2}\D\d{2}', phone)[0] )

print( re.findall(r'\d{2}\D\d{2}\D\d{4}', r'Эта строка написана 19.01.2018, а могла бы и 01.09.2017') )

print( re.findall(r'@\w+\D+', 'abc.test@gmail.com, xyz@test.in') )

print( re.findall("\b\w{3}\b", "Test kek meow hello Tim Amesit Jin Zigz LEC"))

text = """Он --- серо-буро-малиновая редиска!! 
>>>:->
А не кот. 
www.kot.ru"""

print( re.findall(r" ", text) )