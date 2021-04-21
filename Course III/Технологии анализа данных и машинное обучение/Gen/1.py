import numpy as np


#  Y = w1x1 + w2x2 + w3x3 + w4x4 + w5x5 + w6x6
#  Функция имеет 6 входных данных (от x1 до x6) и 6 весовых коэффициентов (от w1 до w6), как показано,
#  а входные значения (x1, x2, x3, x4, x5, x6) = (4, -2, 7, 5, 11, 1).
#
#  Задача состоит в поиске весовых коэффициентов, которые максимизируют значение функции при заданных значениях Х.


# This project is extended and a library called PyGAD is released to build the genetic algorithm.
# PyGAD documentation: https://pygad.readthedocs.io
# Install PyGAD: pip install pygad
# PyGAD source code at GitHub: https://github.com/ahmedfgad/GeneticAlgorithmPython


def cal_pop_fitness(equation_inputs, pop):
    # Calculating the fitness value of each solution in the current population.
    # The fitness function caulcuates the sum of products between each input and its corresponding weight.
    fitness = np.sum(pop * equation_inputs, axis=1)
    return fitness


def select_mating_pool(pop, fitness, num_parents):
    # np the best individuals in the current generation as parents for producing the offspring of the next generation.
    parents = np.empty((num_parents, pop.shape[1]))
    for parent_num in range(num_parents):
        max_fitness_idx = np.where(fitness == np.max(fitness))
        max_fitness_idx = max_fitness_idx[0][0]
        parents[parent_num, :] = pop[max_fitness_idx, :]
        fitness[max_fitness_idx] = -99999999999
    return parents


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


# Inputs of the equation.
equation_inputs = [4, -2, 3.5, 5, -11, -4.7]
# Number of the weights we are looking to optimize.
num_weights = 6
sol_per_pop = 8
# Defining the population size.
# The population will have sol_per_pop chromosome where each chromosome has num_weights genes.
pop_size = (sol_per_pop, num_weights)
# Creating the initial population.
new_population = np.random.uniform(low=-4.0, high=4.0, size=pop_size)

num_generations = 8
num_parents_mating = 4
for generation in range(num_generations):
    # Measuring the fitness of each chromosome in the population.
    fitness = cal_pop_fitness(equation_inputs, new_population)
    if generation == 1:
        print(f"First fitness values:\n{fitness}\n")

    # Selecting the best parents in the population for mating.
    parents = select_mating_pool(new_population, fitness, num_parents_mating)
    offspring_crossover = crossover(
        parents, offspring_size=(pop_size[0] - parents.shape[0], num_weights)
    )

    offspring_mutation = mutation(offspring_crossover, num_mutations=2)

    new_population[0 : parents.shape[0], :] = parents

    new_population[parents.shape[0] :, :] = offspring_mutation

print(f"Best parents:\n{parents}\n")


best_match_idx = np.where(fitness == np.max(fitness))

print(f"Best solution :\n  {new_population[best_match_idx, :][0][0]}\n")
print(f"Best solution fitness: {round(fitness[best_match_idx][0],3)}")


