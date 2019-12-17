using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TableFunc
{
    class TableFuncClass
    {
        float a;
        float b;
        float h;

        public TableFuncClass(float a, float b, float h)
        {
            this.a = Math.Min(a, b);
            this.b = Math.Max(a, b);

            this.h = h;
        }

        //----------------------------------------------------------------
        public float[,] TableFunc(IFunction obj)
        {

            if (!(obj is IFunction))
            {
                MessageBox.Show("Вы забыли реализовать интерфейс IFunction");
                return null;
            }

            float x1 = a;
            int count = (int)((b-a)/h) + 1;
            float[,] m = new float[count, 2];

           for (int i = 0; i<count; i++)
           {
               m[i,0] = x1;
               m[i,1] = obj.F(x1);

               x1 += h;
           }

           return m;
        }
    }
}
