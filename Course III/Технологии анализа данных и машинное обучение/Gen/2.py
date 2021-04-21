import random

import numpy as np


# Выполните реализацию генетического алгоритма, способного максимизировать значение Y = w1x1 - w2x2 + w3x3 * w4x4 + w5x5

# Функция имеет 5 входных данных (от x1 до x5) и 5 весовых коэффициентов (от w1 до w5),
# как показано, а входные значения (x1, x2, x3, x4, x5) = (-4, 12, -3, 2, 8)

def cal_pop_fitness(equation_inputs, pop):
    calcs = []
    for i in range(len(pop)):
        array = pop[i]
        calc = equation_inputs[0] * array[0]
        calc -= equation_inputs[1] * array[1]
        calc += equation_inputs[2] * array[2] * equation_inputs[3] * array[3]
        calc += equation_inputs[4] * array[4]
        calcs.append(calc)
    return calcs


def mutation(offspring_crossover, num_mutations=1):
    mutations_counter = np.uint8(offspring_crossover.shape[1] / num_mutations)
    # Mutation changes a single gene in each offspring randomly.
    for idx in range(offspring_crossover.shape[0]):
        gene_idx = mutations_counter - 1
        for mutation_num in range(num_mutations):
            # The random value to be added to the gene.
            np.random.seed(1)
            random_value = np.random.uniform(-1.0, 1.0, 1)
            offspring_crossover[idx, gene_idx] = (
                    offspring_crossover[idx, gene_idx] + random_value
            )
            gene_idx = gene_idx + mutations_counter
    return offspring_crossover


def select_mating_pool(pop, fitness, num_parents=2):
    # Selecting the best individuals in the current generation as parents for producing the offspring of the next generation.
    parents = np.empty((num_parents, pop.shape[1]))
    for parent_num in range(num_parents):
        max_fitness_idx = np.where(fitness == np.max(fitness))
        max_fitness_idx = max_fitness_idx[0][0]
        parents[parent_num, :] = pop[max_fitness_idx, :]
        fitness[max_fitness_idx] = -99999999999
    return parents


equation_inputs = [2, -1, 3.5, 2, -20, -3.7]
num_weights = len(equation_inputs)
sol_per_pop = 5

# Defining the population size.
pop_size = (
    sol_per_pop,
    len(equation_inputs),
)  # The population will have sol_per_pop chromosome where each chromosome has num_weights genes.
# Creating the initial population.
new_population = np.random.uniform(low=-4.0, high=4.0, size=pop_size)

num_generations = 6
num_parents_mating = 2


def crossover(parents, offspring_size, crossover_point=0):
    offspring = np.empty(offspring_size)
    # The point at which crossover takes place between two parents. Usually it is at the center.
    if crossover_point == 0:
        crossover_point = np.uint8(offspring_size[1] / 2)

    for k in range(offspring_size[0]):
        # Index of the first parent to mate.
        parent1_idx = k % parents.shape[0]
        # Index of the second parent to mate.
        parent2_idx = (k + 1) % parents.shape[0]
        # The new offspring will have its first half of its genes taken from the first parent.
        offspring[k, 0:crossover_point] = parents[parent1_idx, 0:crossover_point]
        # The new offspring will have its second half of its genes taken from the second parent.
        offspring[k, crossover_point:] = parents[parent2_idx, crossover_point:]
    return offspring


for generation in range(num_generations):
    fitness = cal_pop_fitness(equation_inputs, new_population)
    if generation == 1:
        print(f"First fitness values:\n{fitness}\n")
    if generation == num_generations - 1:
        print(f"Last fitness values:\n{fitness}\n")

    # Выбирает лучших родителей для вязки
    parents = select_mating_pool(new_population, fitness, num_parents_mating)
    offspring_crossover = crossover(
        parents, offspring_size=(pop_size[0] - parents.shape[0], num_weights)
    )

    new_population[0: parents.shape[0], :] = parents

    if random.randint(0, 1) == 1:
        offspring_mutation = mutation(offspring_crossover, num_mutations=2)
        new_population[parents.shape[0]:, :] = offspring_mutation

best_match_idx = np.where(fitness == np.max(fitness))[0][0]

print(f"Best solution :\n  {new_population[best_match_idx, :]}\n")
print(f"Best solution fitness: {round(fitness[best_match_idx], 3)}")
