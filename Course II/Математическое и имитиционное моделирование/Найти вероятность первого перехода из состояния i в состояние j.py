import numpy as np


def smfh(p, k):
    p_ = p
    lp = len(p)
    for _ in range(1, k):
        new = np.zeros((lp, lp))
        for i in range(lp):
            for j in range(lp):
                s = 0
                for m in range(lp):
                    s += p[i, m] * p_[m, j] if m != j else 0
                new[i, j] = s
        p_ = new
    return p_


k = 5
p = np.array([[0.5, 0.4, 0.1], [0.25, 0.25, 0.5], [0.1, 0.2, 0.7]])
print(f"{smfh(p, 5)=}")
