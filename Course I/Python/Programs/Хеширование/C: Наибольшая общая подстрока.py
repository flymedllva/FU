# C: Наибольшая общая подстрока
#
# Даны две строки. Найдите длину их максимальной общей подстроки.
#
# В первых двух строках записаны строки A и B, состоящие из строчных латинских букв.
# Эти строки непустые и имеют длину не более 30000 символов.
#
# Выведите длину их максимальной общей подстроки.

a = "abacaba"
b = "acabaca"
wordl = 0


def search_word(a, b, wordl):
    lenw = 0
    for i in range(len(a)):
        for j in range(i, len(a)):
            if a[i:j] in b and len(a[i:j]) > lenw:
                lenw = len(a[i:j])
    return lenw


print(search_word(a, b, wordl))
