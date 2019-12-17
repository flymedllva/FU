using System;
using System.Collections.Generic;

namespace Самолеты
{
    public enum Owner { Аренда, Владелец, Лизинг }

    [System.Flags]          /////
    public enum Day
    {
        понедельник = 1, вторник = 2, среда = 4, четверг = 8,
        пятница = 16, суббота = 32, воскресенье = 64
    }                 

    public class Plane
    {
        public string type;
        public string company;
        public Owner owner;
        public Day days;                     //////

        public Plane(string _type, string _kompan, Owner _owner, Day _days)
        {
            type = _type;
            company = _kompan;
            owner = _owner;
            days = _days;
        }


        public override string ToString()
        {
            return string.Format("Тип самолета: {0}, Компания: {1}, {2}, \n\tДни вылета: {3}",
                type, company, owner, days);
        }

    }
    class Program
    {
        static void Main()
        {
            Plane pl1 = new Plane("Ту-154", "Аэрофлот", Owner.Владелец, Day.понедельник | Day.среда | Day.воскресенье);  ////
            Plane pl2 = new Plane("Ту-134", "Аэрофлот", Owner.Аренда, Day.понедельник | Day.суббота); 
            Plane pl3 = new Plane("Ил-96/1", "Сибирь", Owner.Лизинг, Day.понедельник| Day.вторник | Day.пятница);     ////
            Plane pl4 = new Plane("Ил-96/2", "Сибирь", Owner.Владелец, Day.понедельник | Day.воскресенье);     ////
            Plane pl5 = new Plane("Ил-96/3", "Сибирь", Owner.Лизинг, Day.суббота | Day.воскресенье | Day.вторник);     ////

            List<Plane> lst = new List<Plane>();
            lst.Add(pl1);
            lst.Add(pl2);
            lst.Add(pl3);
            lst.Add(pl4);
            lst.Add(pl5);


            // Вывод всех самолетов списка
            Console.WriteLine("\n---------- Вывод всех самолетов списка ----------");
            foreach (var самолет in lst)
                    Console.WriteLine(самолет);

            // Поиск и вывод всех арендуемых самолетов
            Console.WriteLine("\n---------- Вывод всех арендуемых самолетов ----------");
            foreach (var самолет in lst)
            {
                if (самолет.owner == Owner.Аренда)      
                    Console.WriteLine(самолет);
            }

            // Вывод всех самолетов, летающих по выходным дням

            Console.WriteLine("\n---------- Вывод всех самолетов, летающих по выходным дням ----------");
            foreach (var самолет in lst)
            {
                if ((самолет.days & Day.воскресенье) == Day.воскресенье 
                    || (самолет.days & Day.суббота) == Day.суббота)      
                    Console.WriteLine(самолет);
            }



            // Отменить вылеты по воскресеньям. 
            for (int i = 0; i < lst.Count; i++)
                if ((lst[i].days & Day.воскресенье) == Day.воскресенье)      
                    lst[i].days = lst[i].days ^ Day.воскресенье;  


            // Вывод всех самолетов списка
            Console.WriteLine("\n---------- Вывод всех самолетов без воскресенья ----------");
            foreach (var самолет in lst)
                    Console.WriteLine(самолет);




            // Получение всех членов перечня Owner.
            Console.WriteLine("\n---------- Получение всех членов перечня Owner ----------");
            Array видыСобственности = Enum.GetValues(typeof(Owner));

            for (int i = 0; i < видыСобственности.Length; i++)
            {
                Owner собстенность = (Owner)видыСобственности.GetValue(i);
                Console.WriteLine(собстенность + " = " + (int)собстенность);
            }

        }

    }
}