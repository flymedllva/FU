//
//  Задача 5
//  Наименьшее кратное
//
//  Created by Дмитрий Гриднев on 09/03/2019.
//  Copyright © 2019 Dmitry Gridnev. All rights reserved.
//
//  2520 - самое маленькое число, которое делится без остатка на все числа от 1 до 10.
//  Какое самое маленькое число делится нацело на все числа от 1 до 20?
//

#include <iostream>

using namespace std;
int main(int argc, char *argv[]) {
    int number = 1;
    int i = 1;
    while (i <= 20)
    {
        if (number % i == 0) {
            i++;
        } else {
            number++;
            i = 1;
        }
    }
    cout << number << endl;
}
