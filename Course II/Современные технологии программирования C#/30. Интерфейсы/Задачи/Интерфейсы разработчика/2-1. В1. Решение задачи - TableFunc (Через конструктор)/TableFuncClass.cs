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
        public TableFuncClass(object fx)
        {
            this.fx = fx;
        }

        //-------------------------------------------------------
        public float[,] TableFunc(float a, float b, float h)
        {
            if (!(fx is IFunction))
            {
                // Лучше возбудить исключение
                MessageBox.Show("Вы забыли реализовать интерфейс IFunction");
                return null;
            }
            int count = (int)((b-a)/h) + 1;
            float[,] m = new float[count, 2];

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
