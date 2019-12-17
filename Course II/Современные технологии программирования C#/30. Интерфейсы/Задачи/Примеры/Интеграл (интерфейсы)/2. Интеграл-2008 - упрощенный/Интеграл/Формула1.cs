using System;
using System.Collections.Generic;
using System.Text;

namespace Интеграл
{
    class Формула1:IФормула
    {
        //Реализация подинтегральной функции, заданной в интерфейсе
        public double f(double x)
        {
            return 2 * x;
        }
    }
}
