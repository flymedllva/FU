summ = 0
c = 0
with open('file.txt') as  grusha:
	for nn in grusha.readlines():
		p=nn.split()
		summ=summ+int(p[2])
		c+=1
		if int(p[2])<3:
			print(nn.strip('\n'))

print('Средний бал = ',summ/c)