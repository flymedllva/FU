using System;
using System.Collections.Generic;
using System.Text;

namespace Интеграл
{
    class Первообразная1:IФормула
    {
        //Реализация первообразной для первого интеграла
        public double f(double x)
        {
            return  x*x;
        }
    }
}
