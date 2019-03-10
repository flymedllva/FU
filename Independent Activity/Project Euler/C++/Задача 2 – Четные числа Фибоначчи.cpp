//
// Задача 2
// Четные числа Фибоначчи
//
//  Created by Дмитрий Гриднев on 09/03/2019.
//  Copyright © 2019 Dmitry Gridnev. All rights reserved.
//
// Каждый следующий элемент ряда Фибоначчи получается при сложении двух предыдущих. Начиная с 1 и 2, первые 10 элементов будут:
// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
// Найдите сумму всех четных элементов ряда Фибоначчи, которые не превышают четыре миллиона.
//

#include <iostream>

using namespace std;
int main(int argc, char *argv[]) {
	int a = 1;
	int b = 2;
	int number = 0;
	while (true) {
		if (b <= 4000000) {
			if (b % 2 == 0) {
				number += b;
			}
			b += a;
			a = b - a;
		} else {
			break;
		}
	}
	cout << number << endl;
}
