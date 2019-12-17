using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication5
{
    class Student //: IComparable<Student>  //IComparable
    {
        public static bool flag = true;
        public string Name { get; set; }
        public int Age { get; set; }


        //--------------------------------------------
        public class ByName : IComparer<Student>
        {
            public int Compare(Student st1, Student st2)
            {
                return st1.Name.CompareTo(st2.Name);
            }
        }


        //--------------------------------------------
        public class ByAge : IComparer<Student>
        {
            public int Compare(Student st1, Student st2)
            {
                return st1.Age.CompareTo(st2.Age);
            }
        }


        //--------------------------------------------
        public Student(string N, int A)
        {
            Name = N;
            Age = A;
        }

        public override string ToString()
        {
            return string.Format("Студент {0} родился в {1} году", Name, Age);
        }

        /*
        public int CompareTo(object st)
        {

            if (flag == true)
                return this.Name.CompareTo(((Student)st).Name);
            else
                return this.Age.CompareTo(((Student)st).Age);

        }
        */


        /*
                public int CompareTo(Student st)
                {
                    if (flag == true)
                        return this.Name.CompareTo(st.Name);
                    else
                        return this.Age.CompareTo(st.Age);

                }
         */

    }
}
