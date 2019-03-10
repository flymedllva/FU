//
// Задача 1
// Числа, кратные 3 или 5
//
//  Created by Дмитрий Гриднев on 09/03/2019.
//  Copyright © 2019 Dmitry Gridnev. All rights reserved.
//
// Если выписать все натуральные числа меньше 10, кратные 3 или 5, то получим 3, 5, 6 и 9. Сумма этих чисел равна 23.
// Найдите сумму всех чисел меньше 1000, кратных 3 или 5.
//

#include <iostream>

using namespace std;
int main(int argc, char *argv[]) {
	int i;
	int number = 0;
	for (i = 1; i < 1000; i++) {
		if ((i % 3 == 0) || (i % 5 == 0)) {
			number += i;
		}
	}
	cout << number << endl;
}
