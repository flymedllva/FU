using System;
using System.Collections.Generic;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main()
        {

            List<Person> list = new List<Person>();

            list.Add(new Student("Иванов", 1992, "ГУМФ", 1));
            list.Add(new Student("Иваноу", 1992, "ГУМФ", 1));
            list.Add(new Student("Иванеску", 1992, "ГУМФ", 1));
            list.Add(new Schooler("Ивановская", 1999, 52, 8));
            list.Add(new Schooler("Иванидзе", 2000, 90, 4));
             list.Add(new Student("Иванович", 1992, "ГУМФ", 2));
            list.Add(new Student("Иваненко", 1993, "ГУМФ", 2));
            list.Add(new Student("Иванян", 1992, "ГУМФ", 2));
            list.Add(new Schooler("Иванешвили", 2000, 90, 4));
            list.Add(new Student("Иванеани", 1993, "ВШЭ", 7));

            for (int i = 0; i < list.Count; i++)
            {
                    Console.WriteLine(list[i].Show());
            }

        }
    }
}

