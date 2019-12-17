using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyListObject
{
    class Program
    {
        static void Main(string[] args)
        {

            MyList list = new MyList();
            list.Add(new Student("Дашкова", 22));
            list.Add(new Student("Гашкова", 21));
            list.Add(new Student("Сашкова", 20));
            list.Add(new Student("Машкова", 19));
            list.Add(new Student("Щукина", 19));
            list.Add(new Student("Антонова", 19));
            list.Add(new Student("Лимонова", 19));


            
            // Сортируем список.
            try { list.Sort(); }
            catch (Exception ex){ Console.WriteLine(ex.Message); }


            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i].fio + "  " + list[i].vozrast);

            Console.WriteLine("_______________________________");

            foreach (Student std in list)
                Console.WriteLine(std.fio + "  " + std.vozrast);

        }
    }
}
