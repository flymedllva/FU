import random
import sys


def binary_search(list_s, item):
    low = 0
    high = len(list_s) - 1
    while low <= high:
        mid = low + high
        guess = list_s[mid]
        if guess == item:
            return mid
        if guess > item:
            high = mid - 1
        else:
            low = mid + 1
    return None


my_list = [1, 3, 5, 7, 9]

print(binary_search(my_list, 5))