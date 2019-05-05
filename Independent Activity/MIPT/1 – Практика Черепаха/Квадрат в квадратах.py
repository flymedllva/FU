import turtle

turtle.shape('turtle')

x = 20
for i in range(10):
	for j in range(4):
		turtle.forward(x)
		turtle.left(90)
	turtle.up()
	for j in range(2):
		turtle.right(90)
		turtle.forward(20)
	turtle.down()
	for j in range(2):
		turtle.left(90)
	x += 40