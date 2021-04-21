from abc import ABCMeta, abstractmethod
from random import randint, random
from time import time
from typing import List


class DNAAbstract(metaclass=ABCMeta):
    @abstractmethod
    def get_phrase(self):
        pass

    @abstractmethod
    def fitness(self, target_value: str):
        pass

    @abstractmethod
    def crossover(self, partner: list):
        pass

    @abstractmethod
    def mutate(self, mutation_rate: float):
        pass


class DNA(DNAAbstract):
    genes: List = []

    def __init__(self, num: int):
        # Словарь для перебора
        self.genes = [(chr(randint(32, 126))) for _ in range(num)]

    def get_phrase(self):
        return "".join(self.genes)

    def fitness(self, target_value: str):
        return (lambda s: s * s)(
            sum(
                1 if self.genes[i] == target_value[i] else 0
                for i in range(len(self.genes))
            )
        ) / (len(target_value) * len(target_value))

    def crossover(self, partner: List[DNAAbstract]):
        cnt_genes = len(self.genes)
        child, midpoint = DNA(cnt_genes), randint(0, cnt_genes)
        child.genes = [
            self.genes[i] if i > midpoint else partner.genes[i]
            for i in range(cnt_genes)
        ]
        return child

    def mutate(self, mutation_rate: float):
        for i in range(len(self.genes)):
            if random() < mutation_rate:
                self.genes[i] = chr(randint(32, 126))
        return self


class Population:
    population: List[DNA]

    fitness: List
    max_fitness: int
    mutation_rate: float

    generations: int = 0

    def __init__(self, target_value: str, mutation_rate: float, num: int):
        self.mating_pool = []
        self.max_fitness = 0
        self.population = [DNA(len(target_value)) for _ in range(num)]
        self.mutation_rate = mutation_rate

        self.calc_fitness(target_value)

    def calc_fitness(self, target_value: str):
        self.fitness = [
            self.population[i].fitness(target_value)
            for i in range(len(self.population))
        ]

    def natural_selection(self):
        global index, x
        self.mating_pool = []

        self.max_fitness = 0
        for i in range(len(self.population)):
            if self.fitness[i] > self.max_fitness:
                self.max_fitness = self.fitness[i]
                index = i

        print(
            f"generation: {self.generations}, phrase: {DNA.get_phrase(self.population[index])}"
        )

        def rescale(x, a, b, c, d, force_float=False):
            new_scale = ((float(x - a) / (b - a)) * (d - c)) + c
            if not force_float and all(map(lambda x: type(x) == int, [x, a, b, c, d])):
                return int(round(new_scale))
            return new_scale

        if (DNA.get_phrase(self.population[index])) == target:
            x = False
        for i in range(len(self.population)):
            fitness = rescale(self.fitness[i], 0, float(self.max_fitness), 0, 1)
            n = fitness * 100
            for j in range(int(n)):
                self.mating_pool.append(self.population[i])

    def generate(self):
        self.population = list(
            map(
                lambda _: self.mating_pool[randint(0, len(self.mating_pool) - 1)]
                .crossover(self.mating_pool[randint(0, len(self.mating_pool) - 1)])
                .mutate(self.mutation_rate),
                self.population,
            )
        )
        self.generations += 1


start = time()
target = "intelligent information systems"
population = Population(target, 0.01, 2000)
x, index = True, 0
while x:
    population.natural_selection()
    population.generate()
    population.calc_fitness(target)
end = time()
print(end - start)
