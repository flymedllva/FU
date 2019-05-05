import turtle

n = 12
l = 90

radiusN = 360 / n
turtle.shape('turtle')
for i in range(n):
	turtle.backward(l)
	turtle.left(180)
	turtle.stamp()
	turtle.backward(l)
	turtle.left(180)
	turtle.left(radiusN)
	
input()