# Ход ферзя
print((lambda x1,y1,x2,y2: 'YES' if (x1 == x2 or y1 == y2 or abs(x1 - x2) == abs(y1 - y2)) else 'NO')(int(input()),int(input()),int(input()),int(input())))