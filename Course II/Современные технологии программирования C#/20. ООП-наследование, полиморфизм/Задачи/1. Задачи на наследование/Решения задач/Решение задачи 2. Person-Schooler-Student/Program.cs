using System;
using System.Collections.Generic;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main()
        {
            Person p;
            Student s1 = new Student("Иванов", 1992, "ГУМФ", 1);
            p = s1;

            List<Person> list = new List<Person>();

            list.Add(p);
            list.Add(new Student("Иванович", 1992, "ГУМФ", 2));
            list.Add(new Student("Иваненко", 1993, "ГУМФ", 2));
            list.Add(new Student("Иванян", 1992, "ГУМФ", 2));
            list.Add(new Schooler("Ивановская", 1999, 52, 8));
            list.Add(new Schooler("Иванидзе", 2000, 90, 4));
            list.Add(new Student("Иванеани", 1993, "ВШЭ", 7));
            list.Add(new Person("Иваноу", 2009));

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is Student)
                    Console.WriteLine(((Student)list[i]).ShowStudent());
                else if (list[i] is Schooler)
                    Console.WriteLine(((Schooler)list[i]).ShowSchooler());
                else
                    Console.WriteLine(list[i].Name.ToString());
            }

        }
    }
}

