### Map
# 1
text = list(map(len, ('hello', 'world')))
print(text)
# 2
text2 = tuple(map(lambda x: x-1, (1,4,2)))
print(text2) 

# 3
import random
names = ['Маша', 'Петя', 'Вася']
print(tuple(map(lambda x: random.choice(['Шпунтик', 'Винтик', 'Фунтик']), names)))


# 4
names = ['Маша', 'Петя', 'Вася']

for i in range(len(names)):
	names[i] = hash(names[i])
print(names)

print(list(map(hash, names)))
# 5
l1 = [1,2,3]
l2 = [4,5]

new_list = list(map(lambda x,y:  y, l1, l2))

print (new_list)
### Redux
from functools import reduce
#1
print(reduce(lambda a, x: a * x, [3, 4]))

#2
sentences = ['капитан джек воробей',
			 'капитан дальнего плавания',
			 'ваша лодка готова, капитан']

cap_count = 0
for sentence in sentences:
	cap_count += sentence.count('капитан')

print(cap_count)

print(reduce(lambda a, x: a + x.count('капитан'), sentences, 0))
#3
people = [{'имя': 'Маша', 'рост': 160},
	{' рост ': 'Саша', ' рост ': 80},
	{'name': 'Паша'}]

print(tuple(map(lambda x: x['рост'], filter(lambda x: 'рост' in x, people))))
### filter
mixed = ['мак', 'просо', 'мак', 'мак', 'просо', 'мак', 'просо', 'просо', 'просо', 'мак']
zolushka = list(filter(lambda x: x == 'мак', mixed))
 
print (zolushka)
### zip
a = [1,2,3]
b = "xyz"
c = (None, True)
 
res = list(zip(a, b, c))
print (res)

##########################