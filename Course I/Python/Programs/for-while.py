buff = [2,4,6,7,8]

#for
summ = 0
for i in buff:
	summ = summ + i
print(summ)

#while
summ = 0
i = 0
while True:
	try:
		summ = summ + buff[i]
		i += 1
	except Exception:
		break
print(summ)
