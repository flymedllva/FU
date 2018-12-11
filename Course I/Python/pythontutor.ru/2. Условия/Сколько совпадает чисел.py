# Сколько совпадает чисел
print((lambda a,b,c: 3 if (a == b == c) else (2 if (a == b or b == c or a == c) else 0))(int(input()),int(input()),int(input())))