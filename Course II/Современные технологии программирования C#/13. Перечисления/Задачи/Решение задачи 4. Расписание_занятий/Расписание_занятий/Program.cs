using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Расписание_занятий
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Расписание> list = new List<Расписание>();

            list.Add(new Расписание("1БИ1", Дисциплины.Математика, Дни.понедельник | Дни.среда));
            list.Add(new Расписание("1БИ1", Дисциплины.Программирование, Дни.вторник | Дни.среда | Дни.пятница));
            list.Add(new Расписание("1БИ1", Дисциплины.Физкультура, Дни.вторник));


            foreach (var lst in list)
                Console.WriteLine("Группа {0}  Предмет {1} Дни занятий: {2}", 
                    lst.group, lst.предмет.ToString().PadRight(17), lst.дниЗанятий);

            list[2].дниЗанятий = list[2].дниЗанятий | Дни.среда;
            list[1].дниЗанятий = list[1].дниЗанятий ^ Дни.среда;



            Console.WriteLine("\n");
            foreach (var lst in list)
                Console.WriteLine("Группа {0}  Предмет {1} Дни занятий: {2}",
                    lst.group, lst.предмет.ToString().PadRight(17), lst.дниЗанятий);

            Console.WriteLine("\n");
            if ((list[0].дниЗанятий & Дни.понедельник) == (Дни)0)
                Console.WriteLine("По математике в понедельник Нет занятия");
            else
                Console.WriteLine("По математике в понедельник Есть занятие");


        }
    }
}
