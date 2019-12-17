using System;
using System.Collections.Generic;
using System.Text;

namespace Интеграл
{
    class Первообразная2:IФормула
    {
        //Реализация первообразной для второго интеграла
        public double f(double x)
        {
            return (x * x * x) / 3.0;
        }

        // другой метод
        public override string ToString()
        {
            return "Первообразная: x*х*х/3";
        }
    }
}
