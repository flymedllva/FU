# D: Наибольшая общая подстрока - 2
#
# Даны K строк из маленьких латинских букв. Требуется найти их наибольшую общую подстроку.
#
# В первой строке дано число K (1≤K≤10). В следующих K строках — собственно K строк (длины строк от 1 до 10000).
#
# Выведите наибольшую общую подстроку данных строк.

k = 3
data = ["abacaba",
        "mycabarchive",
        "acabistrue"]

word = ""

for item in data:
    for i in range(len(item)):
        for j in range(i + 1, len(item)):
            if all(item[i:j] in m for m in data) and len(item[i:j]) > len(word):
                word = item[i:j]

print(word)
