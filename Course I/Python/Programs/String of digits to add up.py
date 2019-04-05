# You will be given a string of digits to add up. Start adding them up, but if at any time one of the digits is 0, reset the sum back to 
# Input
# Line 1: An integer N telling the number of digits in the string.
# Line 2: A string S of N digits.
# Output
# The sum, given as an integer.
# Constraints
# 1 ≤ N ≤ 1000

s = input()
ss = 0
for i in range(len(s)):
	if s[i] != "0":
		ss += int(s[i])
	else:
		ss = 0
print(ss)