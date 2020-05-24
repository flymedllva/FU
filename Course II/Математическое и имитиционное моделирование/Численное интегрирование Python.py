import numpy as np
import matplotlib.pyplot as plt
import math


def integrate(h, n, f, v):
	k = np.zeros((n * 4))
	arg = np.zeros(n)

	for i in range(0, n):
		k[i * 4] = f(v)[i]
		arg[i] = v[i] + h * k[i * 4] / 2

	for i in range(0, n):
		k[i * 4 + 1] = f(arg)[i]
		arg[i] = v[i] + h * k[i * 4 + 1] / 2

	for i in range(0, n):
		k[i * 4 + 2] = f(arg)[i]
		arg[i] = v[i] + h * k[i * 4 + 2]

	for i in range(0, n):
		k[i * 4 + 3] = f(arg)[i]

	result = np.zeros(n)
	for i in range(0, n):
		result[i] = v[i] + h * (k[i * 4] + 2 * k[i * 4 + 1] + 2 * k[i * 4 + 2] + k[i * 4 + 3]) / 6

	return result


def f(v):  # v=[t p1 p2 p3]
	y = np.zeros((len(v)))
	y[0] = 1
	y[1] = v[2] * 2 + v[3] * 0 - v[1] * (3 + 2 * math.sin(v[0]) + 2)
	y[2] = v[1] * (3 + 2 * math.sin(v[0])) + v[3] * 0 - v[2] * (2 + 1)
	y[3] = v[1] * 2 + v[2] * 1 - v[3] * (0 + 0)
	y[4] = v[0]* 2 * v[1] + 1*v[2]
	# 	#3 + 2 * math.sin(v[0]) + 2
	# y[5] = v[0]*y[4]*math.exp(-v[4])
	# y[1]=math.sin(v[0])
	# y[1]=-
	return y


x = np.zeros(1)
x[0] = 0
p1 = np.zeros(1)
p2 = np.zeros(1)
p3 = np.zeros(1)
p1[0] = 1
p2[0] = 0
p3[0] = 0
F = np.zeros(1)
F[0] = 0
h = 0.001

v = np.zeros(5)
v[0] = 0
v[1] = 1
v[2] = 0
v[3] = 0
v[4] = 0

for t in range(1, 20000):
	v = integrate(h, 5, f, v)
	# print("v=",v)
	# v[0]=h*t
	x = np.append(x, v[0])
	p1 = np.append(p1, v[1])
	p2 = np.append(p2, v[2])
	p3 = np.append(p3, v[3])
	F = np.append(F, v[4])

# y=np.append(y,math.sin(v[0]))

plt.plot(x, p1, x, p2, x, p3)
plt.show()
plt.plot(x, F)
plt.show()
 

p1, p2, p3, F = map(lambda x: x[-1], (p1, p2, p3, F))
print(f"{p1=}, {p2=}, {p3=}")
print(f"{F=}")
