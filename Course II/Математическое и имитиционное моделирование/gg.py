import numpy as np
import plotly.graph_objects as px


def gen(n, p, k=100):
    for _ in range(k):
        yield (n := n.dot(p))


n = np.array([0.2, 0.2, 0.1])
p = np.array([[0.7, 0.2, 0.1],
              [0.3, 0.3, 0.4],
              [0.6, 0.2, 0.2]])
nlen = np.arange(100)

fig = px.Figure()
for i in range(len(n)):
    fig.add_trace(px.Scatter(x=nlen, y=[j[i] for j in gen(n, p)]))
fig.show()
