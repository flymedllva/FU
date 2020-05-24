import numpy as np

k = 50
p = np.array([[0.5, 0.5], [0.8, 0.2]])
result = np.linalg.matrix_power(p, k)
print(result)
print(sum(result[0]))
