import random
import sys
from time import time


def weighted_choice(items):
    """
    Выбирает случайный элемент из набора значений, где набор значений - это список кортежей в
    форме (шт., вес). Вес определяет вероятность выбора своего
    соответствующего пункта.
    """

    weight_total = sum((item[1] for item in items))
    n = random.uniform(0, weight_total)
    last_item = None
    for item, weight in items:
        if n < weight:
            return item
        n = n - weight
        last_item = item
    return last_item


def random_char():
    return chr(int(random.randrange(32, 126, 1)))


def random_population():
    """
      Возвращает список POP_SIZE, каждый из которых генерируется случайным образом путем итерации
    DNA_SIZE раз, чтобы сгенерировать строку случайных символов с помощью random_char ().
    """

    pop = []
    for i in range(POP_SIZE):
        dna = ""
        for c in range(DNA_SIZE):
            dna += random_char()
        pop.append(dna)
    return pop


def fitness(dna):
    """
      Для каждого гена в ДНК эта функция вычисляет разницу между
    ним и символом в той же позиции в ОПТИМАЛЬНОЙ строке. Значения разницы
    суммируются, а затем возвращаются.
    """

    a = 0
    for c in range(DNA_SIZE):
        a += abs(ord(dna[c]) - ord(OPTIMAL[c]))
    return a


def mutation(dna):
    """
      Для каждого гена в ДНК есть шанс 1 / mutation_chance, что он будет
    замещен  случайным символом. Это обеспечивает разнообразие в
    популяции, и гарантирует, что будет трудно застрять в локальных минимумах.
    """

    dna_out = ""
    mutation_chance = 100
    for c in range(DNA_SIZE):
        if int(random.random() * mutation_chance) == 1:
            dna_out += random_char()
        else:
            dna_out += dna[c]
    return dna_out


def crossover(dna1, dna2):
    """
    Crossover 2 dna используя рандомный индекс.
    Сохраняют свою первую часть до кроссовера.
    Но их концы меняются местами.
    """

    pos = int(random.random() * DNA_SIZE)
    return dna1[:pos] + dna2[pos:], dna2[:pos] + dna1[pos:]


# Необходимые переменные
# Вводим искомую строчку (фразу)
# Устанавливаем количество поколений

OPTIMAL = "intelligent information systems"
DNA_SIZE = len(OPTIMAL)
POP_SIZE = 400
GENERATIONS = 9999999999

# Будем замерять время вычисления алгоритма
start = time()

# Создает начальную популяцию.
# Это создаст список строк POP_SIZE, каждая из которых инициализирована последовательностью случайных символов.
population = random_population()
fittest_string = None

# Моделируем заданное нами количество поколений
generation = 0
while generation <= GENERATIONS:
    generation += 1
    print(f"Generation №{generation}\n Random sample:{population[0]} ")
    weighted_population = []
    for individual in population:
        fitness_val = fitness(individual)

        # Генерирует пару (individual,fitness),
        # учитывая, чтобы мы случайно не поделили на ноль.
        if fitness_val == 0:
            pair = (individual, 1.0)
        else:
            pair = (individual, 1.0 / fitness_val)

        weighted_population.append(pair)

    population = []

    # Выбирает двух случайных особей на основе их вероятностей пригодности,
    # скрещивает их гены в случайной точке,
    # изменяет их и снова добавляет в популяцию для следующей итерации.
    for _ in range(int(POP_SIZE / 2)):
        # Селекция
        ind1 = weighted_choice(weighted_population)
        ind2 = weighted_choice(weighted_population)

        # Переплетение
        ind1, ind2 = crossover(ind1, ind2)

        #  Мутация и возврат обратно в популяцию
        population.append(mutation(ind1))
        population.append(mutation(ind2))

    # Отображает строку с наивысшим рейтингом после итерации всех поколений.
    # Это будет ближайшая строка к ОПТИМАЛЬНОЙ строке,
    # то есть она будет иметь наименьшее значение пригодности.

    fittest_string = population[0]
    minimum_fitness = fitness(population[0])

    for individual in population:
        ind_fitness = fitness(individual)
        if ind_fitness <= minimum_fitness:
            fittest_string = individual
            minimum_fitness = ind_fitness

    # Обрывает цикл, если мы нашли подходящую  строчку
    if fittest_string == OPTIMAL:
        break

end = time()
print(f"\nTime:{round(end - start, 1)}s.\n")
print(f"Final string: {fittest_string}")
