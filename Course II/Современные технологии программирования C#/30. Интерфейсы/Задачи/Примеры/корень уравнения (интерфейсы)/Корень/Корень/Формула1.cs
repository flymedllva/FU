using System;
using System.Collections.Generic;
using System.Text;

namespace Корень
{
    class Формула1:IФормула
    {
        //Реализация функции, заданной в интерфейсе
        public double f(double x)
        {
            return 2*x - 1;
        }
    }
}
