using System;
using System.Collections.Generic;
using System.Text;

namespace Интеграл
{
    class Формула2:IФормула
    {
        //Реализация подинтегральной функции, заданной в интерфейсе
        public double f(double x)
        {
            return x * x;
        }

        // другой метод
        public override string ToString()
        {
            return "Подинтегральная функция: x*х";
        }
    }
}
