using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Person
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public Person(string name, int year)
        {
            Name = name; Year = year;
        }

        public virtual string Show()
        {
            return string.Format("Человек {0}, год рождения {1}", Name, Year);
        }

    }
    //--------------------------------------------
    class Schooler : Person
    {
        public int NumbSc { get; set; }
        public int Grade { get; set; }

        public Schooler(string name, int year, int ns, int g)
            : base(name, year)
        {
            NumbSc = ns; Grade = g;
        }

        public override string Show()
        {
            return string.Format("Школьник {0}, год рождения {1}, номер школы {2}, класс {3}",
                Name, Year, NumbSc, Grade);
        }
    }


    //--------------------------------------------
    class Student : Person
    {
        public string NameUn { get; set; }
        public int Group { get; set; }

        public Student(string name, int year, string nameUn, int g)
            : base(name, year)
        {
            NameUn = nameUn; Group = g;
        }
        public override string Show()
        {
            return string.Format("Студент {0}, год рождения {1}, вуз {2}, группа {3}",
                Name, Year, NameUn, Group);
        }
    }
}
