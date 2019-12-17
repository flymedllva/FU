using System;
using System.Collections.Generic;
using System.Text;

namespace Интеграл
{
    class Формула1 : IФормула
    {
        //Реализация подинтегральной функции, заданной в интерфейсе
        public double f(double x)
        {
            return 2 * x;
        }

        // другой метод
        public override string ToString()
        {
            return "Подинтегральная функция: 2x";
        }
    }
}
