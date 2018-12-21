# Hexagon
ax, ay = [int(x) for x in input("Введите координаты точки A через пробел: ").split()]
bx, by = [int(x) for x in input("Введите координаты точки B через пробел: ").split()]
cx, cy = [int(x) for x in input("Введите координаты точки C через пробел: ").split()]
dx, dy = [int(x) for x in input("Введите координаты точки D через пробел: ").split()]
ex, ey = [int(x) for x in input("Введите координаты точки E через пробел: ").split()]
fx, fy = [int(x) for x in input("Введите координаты точки F через пробел: ").split()]
print('{:^4}|{:^6}|{:^6}|\n{:>3}|{:^6}|{:^6}|\n{:>3}|{:^6}|{:^6}|\n{:>3}|{:^6}|{:^6}|\n{:>3}|{:^6}|{:^6}|\n{:>3}|{:^6}|{:^6}|\n{:>3}|{:^6}|{:^6}|\n{}\n| S(ABCDEF) = {} |\n{}'.format(' ', 'X', 'Y', 'A = ', ax, ay, 'B = ', bx, by, 'C = ', cx, cy, 'D = ', dx, dy, 'E = ', ex, ey, 'F = ', fx, fy,'-'*19, ((ax*by + bx*cy + cx*dy + dx*ey + ex*fy + fx*ay)-(ay*bx + by*cx + cy*dx + dy*ex + ey*fx + fy*ax)), '-'*19))
# or
class point:
	def __init__(self,x,y):   
		self.x = x
		self.y = y
class hexagon(point): 
	def __init__(self,A,B,C,D,E,F): # A,B,C - class Point 
		self.A = A 
		self.B = B 
		self.C = C 
		self.D = D
		self.E = E
		self.F = F
	def __str__(self): 
		a = self.A 
		b = self.B 
		c = self.C 
		d = self.D
		e = self.E
		f = self.F
		return "hexagon("+ str((a.x,a.y))+","+str((b.x,b.y))+","+str((c.x,c.y))+ str((d.x,d.y))+str((e.x,e.y))+str((f.x,f.y))+")" 

	def sides(self): 
		ab =((self.B.x-self.A.x)**2+(self.B.y-self.A.y)**2)**(1/2) 
		bc =((self.C.x-self.B.x)**2+(self.C.y-self.B.y)**2)**(1/2) 
		cd =((self.D.x-self.C.x)**2+(self.D.y-self.C.y)**2)**(1/2) 
		de =((self.E.x-self.D.x)**2+(self.E.y-self.D.y)**2)**(1/2) 
		ef =((self.F.x-self.E.x)**2+(self.F.y-self.E.y)**2)**(1/2)
		fa =((self.A.x-self.F.x)**2+(self.A.y-self.F.y)**2)**(1/2) 
		return ab,bc,cd,de,ef,fa
	def perim(self): 
		a,b,c,d,e,f=hexagon.sides(self) 
		return a+b+c+d+e+f
	def square(self):
		list_of_x_1 = [self.A.x,self.B.x,self.C.x,self.D.x,self.E.x,self.F.x]
		list_of_y_1 = [self.B.y,self.C.y,self.D.y,self.E.y,self.F.y,self.A.y]
		list_of_x_2 = [self.B.x,self.C.x,self.D.x,self.E.x,self.F.x,self.A.x]
		list_of_y_2 = [self.A.y,self.B.y,self.C.y,self.D.y,self.E.y,self.F.y]
		sum_1 = [list_of_x_1[i]*list_of_y_1[i] for i in range(len(list_of_x_1))]
		sum_2 = [list_of_x_2[i]*list_of_y_2[i] for i in range(len(list_of_x_2))]        
		return sum(sum_1)-sum(sum_2)
	
A = point(4,0)
B = point(0,-4)
C = point(0,-12)
D = point(4,-16)
E = point(8,-12)
F = point(8,-4)
h = hexagon(A,B,C,D,E,F)
print(h.square())