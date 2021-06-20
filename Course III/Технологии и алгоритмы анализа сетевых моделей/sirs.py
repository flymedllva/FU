import networkx as nx
import EoN
from collections import defaultdict
import matplotlib.pyplot as plt

a = 0.1
b = 0.01
y = 0.001
d = 0.001
to_isolation_rate = 0.05
from_isolation_rate = 1

Gnp = nx.gnp_random_graph(600, 0.005)
pos = nx.circular_layout(Gnp)
plt.figure(figsize=(20, 20))
nx.draw(
    Gnp,
    pos,
    node_size=70,
    labels=dict(zip(list(Gnp.nodes()), list(Gnp.nodes()))),
    with_labels=True,
    font_size=14,
    font_weight="bold",
)
plt.show()
H = nx.DiGraph()

H.add_edge("I", "R", rate=b)
H.add_edge("I", "S", rate=y)
H.add_edge("R", "S", rate=d)
H.add_edge("S", "X", rate=to_isolation_rate)
H.add_edge("X", "S", rate=from_isolation_rate)

J = nx.DiGraph()
J.add_edge(("I", "S"), ("I", "I"), rate=a)
IC = defaultdict(lambda: "S")
IC[0] = "I"

t, S, I, R, X = EoN.Gillespie_simple_contagion(
    Gnp, H, J, IC, ("S", "I", "R", "X"), tmax=500
)

plt.plot(t, S, label="Восприимчивые")
plt.plot(t, I, label="Зараженные")
plt.plot(t, R, label="Восстановленные")
plt.plot(t, X, label="В изоляции")
plt.xlabel("$t$")
plt.ylabel("Количество вершин")
plt.legend()
plt.show()
