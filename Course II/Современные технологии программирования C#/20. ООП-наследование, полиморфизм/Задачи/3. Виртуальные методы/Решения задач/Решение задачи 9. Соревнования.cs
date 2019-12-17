/* Разработать консольное приложение для учета результатов спортивных состязаний и вывода справочной информации. Проводятся соревнования по плаванию на 100 м. и по прыжкам в воду с 10 м. трамплина. Для выполнения прыжков в воду дается три попытки, каждая попытка оценивается в баллах, в зачет идет сумма баллов. Известны рекорды в этих видах состязаний. 
Создать список результатов, показанных не менее 5-ю участниками. Исходные данные можно задать в программе в виде констант. Вывести информацию обо всех спортсменах. Определить участников, занявших первое место. Если рекорд побит, вывести об этом сообщение.
При разработке программы использовать наиболее эффективные средства ООП.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Вариант_8
{
    class ЗаявкаНаСоревнование
    {
        private string видСоревнования;

        private string фамилия;

        public ЗаявкаНаСоревнование(string видСоревнования, string фамилия)
        {
            this.видСоревнования = видСоревнования;
            this.фамилия = фамилия;
        }
        public string ВидСоревнования
        { get { return видСоревнования; } }

        public virtual double Результат
        { get { return 0; } }

        public virtual void Вывод()
        {
            Console.WriteLine(видСоревнования + ", спортсмен " + фамилия);
        }
    }


    //---------------------------------------------------------------
    class Плавание100 : ЗаявкаНаСоревнование
    {
        public static double рекордПл = 30.0;
        private double time;


        public Плавание100(string видСоревнования, string фамилия, double time)
            : base(видСоревнования, фамилия)
        {
            this.time = time;
        }

        public override double Результат
        { get { return time; } }

        public override void Вывод()
        {
            base.Вывод();
            Console.WriteLine("   показанное время " + time);
        }
    }

    //---------------------------------------------------------------
    class Прыжки10м : ЗаявкаНаСоревнование
    {
        public static double рекордПр = 60.0;

        private double p1, p2, p3;

        public Прыжки10м(string видСоревнования, string фамилия, double p1, double p2, double p3)
            : base(видСоревнования, фамилия)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        public override double Результат
        { get { return p1 + p2 + p3; } }


        public override void Вывод()
        {
            base.Вывод();
            Console.WriteLine("   набранная сумма баллов " + (p1 + p2 + p3));
        }
    }

    //---------------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            int меню;                       // номер пункта меню
            string фамилия;
            double time, minPl;             // время и минимальный результат по плаванию
            double p1, p2, p3, maxPr;       // очки и максимальный результат по прыжкам в воду
            int m1pl, m1pr;                 // индексы победителей в архиве
            List<ЗаявкаНаСоревнование> Архив = new List<ЗаявкаНаСоревнование>();

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\nРекорд по плаванию на 100 м. баттерфляем   = " + Плавание100.рекордПл + " секунд");
            Console.WriteLine("Рекорд по прыжкам в воду с 10 м. трамплина = " + Прыжки10м.рекордПр + " баллов\n");
            Console.ForegroundColor = ConsoleColor.Yellow;

            while (true)
            {
                Console.WriteLine("\n\t--------------------- МЕНЮ ----------------------");
                Console.WriteLine("\t1 - Добавить в архив результат по плаванию");
                Console.WriteLine("\t2 - Добавить в архив результат по прыжкам в воду");
                Console.WriteLine("\t3 - Выдать список участников и их результаты");
                Console.WriteLine("\t4 - Определить победителей");
                Console.WriteLine("\t5 - Выход");
                Console.WriteLine("\t-------------------------------------------------");
                Console.Write("Введите номер пункта меню: ");

                меню = int.Parse(Console.ReadLine());

                switch (меню)
                {
                    case 1:     // плавание
                        Console.Write("Введите фамилию: ");
                        фамилия = Console.ReadLine();

                        Console.Write("Введите время: ");
                        time = double.Parse(Console.ReadLine());

                        Архив.Add(new Плавание100("Плавание", фамилия, time));

                        break;

                    //-----------------------------
                    case 2:
                        Console.Write("Введите фамилию: ");
                        фамилия = Console.ReadLine();

                        Console.Write("Введите количество баллов за 1-й прыжок: ");
                        p1 = double.Parse(Console.ReadLine());

                        Console.Write("Введите количество баллов за 2-й прыжок: ");
                        p2 = double.Parse(Console.ReadLine());

                        Console.Write("Введите количество баллов за 3-й прыжок: ");
                        p3 = double.Parse(Console.ReadLine());

                        Архив.Add(new Прыжки10м("Прыжки в воду", фамилия, p1, p2, p3));

                        break;

                    //-----------------------------
                    case 3:         // Выдать список участников и их результаты
                        if (Архив.Count == 0)
                        {
                            Console.WriteLine("Данные отсутствуют.");
                            break;
                        }

                        Console.WriteLine("Результаты соревнования:");
                        Console.WriteLine("-----------------------");

                        int j = 1;
                        foreach (ЗаявкаНаСоревнование x in Архив)
                        {
                            Console.Write("\n" + j++ + ". ");
                            x.Вывод();
                        }

                        break;

                    //-----------------------------
                    case 4:         // Определить победителей
                        if (Архив.Count == 0)
                        {
                            Console.WriteLine("Данные отсутствуют.");
                            break;
                        }


                        m1pl = m1pr = 0;
                        minPl = 999999999;      // Заведомо большее значение 
                        maxPr = -1;             // Заведомо меньшее значение

                        for (int i = 0; i < Архив.Count; i++)
                        {
                            if (Архив[i].ВидСоревнования == "Плавание" && minPl > Архив[i].Результат)
                            {
                                m1pl = i;
                                minPl = Архив[i].Результат;
                            }
                            else if (Архив[i].ВидСоревнования == "Прыжки в воду" && maxPr < Архив[i].Результат)
                            {
                                m1pr = i;
                                maxPr = Архив[i].Результат;
                            }
                            else Console.WriteLine(Архив[i].ВидСоревнования + " - этот вид соревнования не обрабатывается!");

                        }

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nПервое место по плаванию на 100 м.");
                        Console.WriteLine("----------------------------------");
                        Архив[m1pl].Вывод();
                        if (Архив[m1pl].Результат < Плавание100.рекордПл)
                            Console.WriteLine("!!!!! Это новый мировой рекорд !!!!");

                        Console.WriteLine("\nПервое место по прыжкам в воду с 10 м. трамплина");
                        Console.WriteLine("------------------------------------------------");
                        Архив[m1pr].Вывод();
                        if (Архив[m1pr].Результат > Прыжки10м.рекордПр)
                            Console.WriteLine("!!!!! Это новый мировой рекорд !!!!");

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine();

                        break;

                    //-----------------------------
                    case 5:         // Выход
                        Console.WriteLine("\nДля завершения программы нажми Esc");
                        if (Console.ReadKey(true).Key == ConsoleKey.Escape)

                            return;
                        else
                            break;

                    //-----------------------------
                    default:
                        Console.WriteLine("Введен неверный номер!");
                        break;
                }
                Console.WriteLine("\n--Готово--");
            }
        }
    }
}
