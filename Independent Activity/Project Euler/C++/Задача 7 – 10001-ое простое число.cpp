//
//  Задача 7 – 10001-ое простое число.cpp
//  C++
//
//  Created by Дмитрий Гриднев on 09/03/2019.
//  Copyright © 2019 Dmitry Gridnev. All rights reserved.
//
//  Выписав первые шесть простых чисел, получим 2, 3, 5, 7, 11 и 13. Очевидно, что 6-ое простое число - 13.
//  Какое число является 10001-ым простым числом?
//

#include <cmath>
#include <iostream>

using namespace std;
int main(int argc, char *argv[]) {
    for(int i = 0; i < 20; ++i)
    {
        if( i & 1 ) std::cout << i << endl;
    }
    std::cout << endl;
    return 0;
}


// Решить!
