using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyListObject
{
    public class Student : IMyComparable
    {
       public string fio;
       public int vozrast;
        // . . .

        public Student(string f, int v)
        {
            fio = f;
            vozrast = v;
        }

        //Реализуем интерфейсный метод.
        public int CompareTo(Student obj)
        {
            return this.fio.CompareTo(obj.fio);     //   0 - =, 1 - >, -1 - < 
        }

    }
}
