package main

import (
	"fmt"
	"math"
	"math/rand"
	"runtime"
	"strings"
	"sync"
	"time"
)

var (
	Optimal = "Первый искусственный интеллект"

	PopulationSize uint = 50
	Generations    uint = 9999999999

	DNASize        uint = 0
	MutationChange      = 100
	//LetterBytes         = "abcdefghijklmnopqrstuvwxyz "
	LetterBytes         = "АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМм.НнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя "

	Cores               = 0
	ContinentsStep uint = 50
)

func init() {
	DNASize = uint(len(Optimal))
	Cores = runtime.NumCPU()
}

type Weight struct {
	Individual  string
	Coefficient float64
}

func RandStringBytes(n int) string {
	b := make([]byte, n)
	for i := range b {
		b[i] = LetterBytes[rand.Intn(len(LetterBytes))]
	}
	return string(b)
}

// RandomPopulation возвращает список PopulationSize, каждый из которых генерируется случайным образом путем итерации
// DNASize раз, чтобы сгенерировать строку случайных символов с помощью RandStringBytes.
func RandomPopulation(populationSize uint, dnaSize uint) []string {
	var population []string

	for i := uint(0); i < populationSize; i++ {
		var dna strings.Builder
		var dnaPopulation uint = 0
		for j := uint(0); j < dnaSize; j++ {
			dna.WriteString(RandStringBytes(1))
			dnaPopulation += 1
		}
		population = append(population, dna.String())
	}

	return population
}

// WeightedChoice выбирает случайный элемент из набора значений, где набор значений - это список кортежей в
// форме (шт., вес). Вес определяет вероятность выбора своего
// соответствующего пункта.
func WeightedChoice(items []Weight) string {
	var weightSum float64 = 0
	for _, item := range items {
		weightSum += item.Coefficient
	}

	n := 0 + rand.Float64()*(weightSum-0)

	lastItem := ""
	for _, item := range items {
		if n < item.Coefficient {
			return item.Individual
		}
		n = n - item.Coefficient
		lastItem = item.Individual
	}
	return lastItem
}

// Crossover используя рандомный индекс. Сохраняют свою первую часть до кроссовера. Но их концы меняются местами.
func Crossover(dna1, dna2 string) (string, string) {
	pos := rand.Intn(1) * int(DNASize)
	return dna1[:pos] + dna2[pos:], dna2[:pos] + dna1[pos:]
}

// Fitness каждого гена в ДНК эта функция вычисляет разницу между ним и символом в той же позиции в ОПТИМАЛЬНОЙ строке.
// Значения разницы суммируются, а затем возвращаются.
func Fitness(dna string) int {
	var sum = 0
	for i := 0; i < int(DNASize); i++ {
		sum += int(math.Abs(float64(int(dna[i]) - int(Optimal[i]))))
	}
	return sum
}

// Mutation Для каждого гена в ДНК есть шанс 1 / mutation_chance, что он будет
// замещен  случайным символом. Это обеспечивает разнообразие в
// популяции, и гарантирует, что будет трудно застрять в локальных минимумах.
func Mutation(dna string) string {
	var dnaOut strings.Builder

	for i := uint(0); i < DNASize; i++ {
		if int(rand.Float64()*float64(MutationChange)) == 1 {
			dnaOut.WriteString(RandStringBytes(1))
		} else {
			dnaOut.WriteString(string(dna[i]))
		}
	}

	return dnaOut.String()
}
func Shuffle(src []string) []string {
	final := make([]string, len(src))
	rand.Seed(time.Now().UTC().UnixNano())
	perm := rand.Perm(len(src))

	for i, v := range perm {
		final[v] = src[i]
	}
	return final
}

func base() {
	start := time.Now()
	population := RandomPopulation(PopulationSize, DNASize)
	fittestString := ""
	for generation := uint(1); generation < Generations; generation++ {
		if generation%10 == 0 {
			fmt.Printf("Generation №%d, Random sample: `%s`\n", generation, population[0])
		}

		var weightedPopulation []Weight
		for _, individual := range population {
			fitnessVal := Fitness(individual)

			var coefficient = 1.0
			if fitnessVal != 0 {
				coefficient = 1.0 / float64(fitnessVal)
			}

			weightedPopulation = append(weightedPopulation, Weight{
				Individual:  individual,
				Coefficient: coefficient,
			})
		}

		population = []string{}

		// Выбирает двух случайных особей на основе их вероятностей пригодности,
		// скрещивает их гены в случайной точке,
		// изменяет их и снова добавляет в популяцию для следующей итерации.
		for i := 0; i < int(PopulationSize/2); i++ {
			// Селекция
			ind1 := WeightedChoice(weightedPopulation)
			ind2 := WeightedChoice(weightedPopulation)

			// Переплетение
			ind1, ind2 = Crossover(ind1, ind2)

			// Мутация и возврат обратно в популяцию
			population = append(population, Mutation(ind1), Mutation(ind2))
		}

		// Отображает строку с наивысшим рейтингом после итерации всех поколений.
		// Это будет ближайшая строка к ОПТИМАЛЬНОЙ строке,
		// то есть она будет иметь наименьшее значение пригодности.

		fittestString = population[0]
		minimumFitness := Fitness(population[0])

		for _, individual := range population {
			indFitness := Fitness(individual)
			if indFitness <= minimumFitness {
				fittestString = individual
				minimumFitness = indFitness
			}
		}

		if fittestString == Optimal {
			break
		}
	}

	fmt.Println("------------\nBase method:")
	fmt.Printf("Final string: %s\n", fittestString)
	duration := time.Since(start)
	fmt.Println(duration, "\n------------")
}

func isIsland() {
	start := time.Now()
	population := RandomPopulation(PopulationSize, DNASize)
	var timers []time.Duration
	for i := 0; i < Cores; i++ {
		timers = append(timers, time.Since(start))
	}

	wg := sync.WaitGroup{}
	for i := 0; i < Cores; i++ {
		wg.Add(1)
		go func(i int, population []string) {
			fittestString := ""
			for generation := uint(1); generation < Generations; generation++ {
				if generation%500 == 0 {
					fmt.Printf("Core %d Generation №%d, Random sample: `%s`\n", i+1, generation, population[0])
				}

				var weightedPopulation []Weight
				for _, individual := range population {
					fitnessVal := Fitness(individual)

					var coefficient = 1.0
					if fitnessVal != 0 {
						coefficient = 1.0 / float64(fitnessVal)
					}

					weightedPopulation = append(weightedPopulation, Weight{
						Individual:  individual,
						Coefficient: coefficient,
					})
				}

				population = []string{}

				// Выбирает двух случайных особей на основе их вероятностей пригодности,
				// скрещивает их гены в случайной точке,
				// изменяет их и снова добавляет в популяцию для следующей итерации.
				for i := 0; i < int(PopulationSize/2); i++ {
					// Селекция
					ind1 := WeightedChoice(weightedPopulation)
					ind2 := WeightedChoice(weightedPopulation)

					// Переплетение
					ind1, ind2 = Crossover(ind1, ind2)

					// Мутация и возврат обратно в популяцию
					population = append(population, Mutation(ind1), Mutation(ind2))
				}

				// Отображает строку с наивысшим рейтингом после итерации всех поколений.
				// Это будет ближайшая строка к ОПТИМАЛЬНОЙ строке,
				// то есть она будет иметь наименьшее значение пригодности.

				fittestString = population[0]
				minimumFitness := Fitness(population[0])

				for _, individual := range population {
					indFitness := Fitness(individual)
					if indFitness <= minimumFitness {
						fittestString = individual
						minimumFitness = indFitness
					}
				}

				if fittestString == Optimal {
					break
				}
			}
			timers[i] = time.Since(start)
			wg.Done()
		}(i, population)
	}
	wg.Wait()

	smallDuration := time.Since(start)
	for i := 0; i < Cores; i++ {
		if timers[i] < smallDuration {
			smallDuration = timers[i]
		}
	}
	fmt.Println("------------\nIslands method:")
	fmt.Println(smallDuration, "\n", timers, "\n------------")
}

func isContinents() {
	var populations [][]string
	var fittestStrings []string
	for i := 0; i < Cores; i++ {
		populations = append(populations, RandomPopulation(PopulationSize, DNASize))
		fittestStrings = append(fittestStrings, "")
	}
	start := time.Now()
	done := false
	result := ""

	wg := sync.WaitGroup{}
	j := 0
	for {
		j += 1
		for i := 0; i < Cores; i++ {
			wg.Add(1)
			go func(i, j int, population []string) {
				for generation := uint(1); generation < Generations; generation++ {
					if generation%10 == 0 {
						fmt.Printf("Gen №%d Core %d GenSub №%d, Random sample: `%s`\n", j, i+1, generation, population[0])
					}

					var weightedPopulation []Weight
					for _, individual := range population {
						fitnessVal := Fitness(individual)

						var coefficient = 1.0
						if fitnessVal != 0 {
							coefficient = 1.0 / float64(fitnessVal)
						}

						weightedPopulation = append(weightedPopulation, Weight{
							Individual:  individual,
							Coefficient: coefficient,
						})
					}

					population = []string{}

					// Выбирает двух случайных особей на основе их вероятностей пригодности,
					// скрещивает их гены в случайной точке,
					// изменяет их и снова добавляет в популяцию для следующей итерации.
					for i := 0; i < int(PopulationSize/2); i++ {
						// Селекция
						ind1 := WeightedChoice(weightedPopulation)
						ind2 := WeightedChoice(weightedPopulation)

						// Переплетение
						ind1, ind2 = Crossover(ind1, ind2)

						// Мутация и возврат обратно в популяцию
						population = append(population, Mutation(ind1), Mutation(ind2))
					}

					// Отображает строку с наивысшим рейтингом после итерации всех поколений.
					// Это будет ближайшая строка к ОПТИМАЛЬНОЙ строке,
					// то есть она будет иметь наименьшее значение пригодности.

					fittestStrings[i] = population[0]
					minimumFitness := Fitness(population[0])

					for _, individual := range population {
						indFitness := Fitness(individual)
						if indFitness <= minimumFitness {
							fittestStrings[i] = individual
							minimumFitness = indFitness
						}
					}

					if fittestStrings[i] == Optimal {
						done = true
						result = fittestStrings[i]
						break
					}
					if generation%ContinentsStep == 0 {
						populations[i] = population
						break
					}
				}
				wg.Done()
			}(i, j, populations[i])
		}
		wg.Wait()
		if done {
			fmt.Println(result)
			break
		}
		fittestStrings = Shuffle(fittestStrings)
		for i := 0; i < Cores; i++ {
			populations[i][0] = fittestStrings[i]
		}
	}

	fmt.Println("------------\nContinents method:")
	fmt.Printf("Final string: %s\n", result)
	duration := time.Since(start)
	fmt.Println(duration, "\n------------")
}

func main() {
	base()
	//isIsland()
	//isContinents()
}

//------------
//Base method:
//Final string: intelligent information systems
//485.982045ms
//------------

//------------
//Islands method:
//3.237399432s
//[10.615225143s 10.04523796s 12.676438251s 13.6830411s 11.976252401s 13.468926962s 3.237399432s 8.592980627s 13.649594732s 12.136401387s 12.308397911s 4.55056674s]
//------------

//------------
//Continents method:
//Final string: intelligent information systems
//2.849730337s
//------------

