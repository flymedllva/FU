using System;
using System.Collections.Generic;
using System.Text;

namespace Корень
{
    class Формула2:IФормула
    {
        //Реализация функции, заданной в интерфейсе
        public double f(double x)
        {
            return (x+1)*(x+1) - 2;
        }
    }
}
