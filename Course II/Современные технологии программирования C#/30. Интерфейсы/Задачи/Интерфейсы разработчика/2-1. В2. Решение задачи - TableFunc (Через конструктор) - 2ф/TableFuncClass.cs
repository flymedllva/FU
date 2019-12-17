using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TableFunc
{
    class TableFuncClass
    {
        object fx;

        //-------------------------------------------------------
        public TableFuncClass(IFunction fx)
        {
            this.fx = fx;
        }

        //-------------------------------------------------------
        public double[,] TableFunc(double a, double b, double h)
        {
            //if (!(fx is IFunction))
            //{
            //    // Лучше возбудить исключение
            //    MessageBox.Show("Вы забыли реализовать интерфейс IFunction");
            //    return null;
            //}

            int count = (int)((b-a)/h) + 1;
            double[,] m = new double[count, 2];

           for (int i = 0; i<count; i++)
           {
               m[i,0] = a;
               m[i,1] = ((IFunction)fx).F(a);

               a += h;
           }

           return m;

        }
    }
}
