// Задача 4
// Наибольшее произведение-палиндром

// Число-палиндром с обеих сторон (справа налево и слева направо) читается одинаково.
// Самое большое число-палиндром, полученное умножением двух двузначных чисел – 9009 = 91 × 99.
// Найдите самый большой палиндром, полученный умножением двух трехзначных чисел.

#include <iostream>

using namespace std;
int main(int argc, char *argv[]) {
	int i, j;
    int max = 0;
	for (i = 100; i <= 999; i++) {
		for (j = 100; j <= 999; j++) {
            auto number = std::to_string(i * j);
            if (number[0] == number[number.length()-1]) {
                if (number[1] == number[number.length()-2]) {
                    if (number[2] == number[number.length()-3]) {
                        if (i * j > max) {
                            max = i * j;
                        }
                    }
                }
            }
		}
	}
    cout << max << endl;
}
