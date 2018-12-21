# Hexagon
ax, ay = [int(x) for x in input("Введите координаты точки A через пробел: ").split()]
bx, by = [int(x) for x in input("Введите координаты точки B через пробел: ").split()]
cx, cy = [int(x) for x in input("Введите координаты точки C через пробел: ").split()]
dx, dy = [int(x) for x in input("Введите координаты точки D через пробел: ").split()]
ex, ey = [int(x) for x in input("Введите координаты точки E через пробел: ").split()]
fx, fy = [int(x) for x in input("Введите координаты точки F через пробел: ").split()]
print('{:^4}|{:^6}|{:^6}|\n{:>3}|{:^6}|{:^6}|\n{:>3}|{:^6}|{:^6}|\n{:>3}|{:^6}|{:^6}|\n{:>3}|{:^6}|{:^6}|\n{:>3}|{:^6}|{:^6}|\n{:>3}|{:^6}|{:^6}|\n{}\n| S(ABCDEF) = {} |\n{}'.format(' ', 'X', 'Y', 'A = ', ax, ay, 'B = ', bx, by, 'C = ', cx, cy, 'D = ', dx, dy, 'E = ', ex, ey, 'F = ', fx, fy,'-'*19, ((ax*by + bx*cy + cx*dy + dx*ey + ex*fy + fx*ay)-(ay*bx + by*cx + cy*dx + dy*ex + ey*fx + fy*ax)), '-'*19))