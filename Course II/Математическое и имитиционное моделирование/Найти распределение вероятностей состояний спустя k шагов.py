import numpy as np

k = 100
p = np.array([[0.5, 0.4, 0.1], [0.25, 0.25, 0.5], [0.1, 0.2, 0.7]])
result = np.linalg.matrix_power(p, k)
print(f"{result=}")

print(f"{result[0].dot(result)=}")
