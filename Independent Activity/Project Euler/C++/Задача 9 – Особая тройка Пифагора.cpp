//
//  Задача 9 – Особая тройка Пифагора.cpp
//  C++
//
//  Created by Дмитрий Гриднев on 11/03/2019.
//  Copyright © 2019 Dmitry Gridnev. All rights reserved.
//
//  Тройка Пифагора - три натуральных числа a < b < c, для которых выполняется равенство
//
//  a^2 + b^2 = c^2
//  Например, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
//
//  Существует только одна тройка Пифагора, для которой a + b + c = 1000.
//  Найдите произведение abc.

#include <iostream>
#include <cmath>

using namespace std;
int main(int argc, char *argv[]) {
    for (int a = 0; a < 500; a++) {
        for (int b = 0; b < 500; b++) {
            for (int c = 0; c < 500; c++) {
                if (pow(a, 2) + pow(b, 2) == pow(c, 2) and a + b + c == 1000 and a < b and b < c) {
                    cout << "a = " << a << ", b = " << b << ", c = " << c << ", a + b + c = " <<  a + b + c << endl;
                    cout << a * b * c << endl;
                    break;
                }
            }
        }
    }
}
