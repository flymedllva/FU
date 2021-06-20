import networkx as nx
import matplotlib.pyplot as plt
import pandas as pd

G = nx.watts_strogatz_graph(200, 4, 0.5, seed=0)
pos = nx.circular_layout(G)
plt.figure(figsize=(20, 20))
nx.draw_networkx(G, pos)

df = pd.DataFrame(nx.floyd_warshall_numpy(G))


#
pieces = []
for col in df.columns[0:99]:
    tmp_series = df[col].value_counts()
    tmp_series.name = col
    pieces.append(tmp_series)
df_value_counts = pd.concat(pieces, axis=1)
df_value_counts["sum"] = df_value_counts.sum(axis=1)
df_value_counts

plt.figure(figsize=(10, 10))
plt.plot([0, 1, 2, 3, 4, 5, 6, 7], df_value_counts["sum"], color="blue")

#
#
# nx.sigma(G, 10, 10, 1)
# nx.omega(G, 10, 10, 1)

sigmas = []
omegas = []
probs = []
for i in range(1, 100, 5):
    p = i / 100
    probs.append(p)
    G = nx.watts_strogatz_graph(20, 4, p, seed=0)
    sigmas.append(nx.sigma(G, 10, 10, 1))
    omegas.append(nx.omega(G, 10, 10, 1))

plt.figure(figsize=(10, 10))
plt.plot(probs, sigmas, color="green", label="sigma")
plt.plot(probs, omegas, color="red", label="omega")
plt.legend(loc="lower right")
plt.show()
