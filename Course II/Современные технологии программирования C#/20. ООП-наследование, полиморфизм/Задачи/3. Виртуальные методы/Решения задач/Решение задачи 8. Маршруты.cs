/* Разработать консольное приложение для учета маршрутов проезда 
 * из одного пункта города в другой. Маршруты могут быть только 
 * двух типов: на такси и на городском общественном транспорте 
 * с N пересадками.  Маршрут с такси характеризуется его названием, 
 * длиной и расходом бензина на 100 км. Стоимость одного литра 
 * бензина равна 20 руб. Автобусный маршрут характеризуется 
 * названием и количеством пересадок. Стоимость билета равна 25 руб.
 * Создать список маршрутов (не менее 5-и). Исходные данные можно 
 * задать в программе в виде констант. 
 * Вывести информацию обо всех маршрутах, включая цену проезда. 
 * Определить маршрут, стоимость проезда по которому является самой низкой.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class Проезд
    {
        public static double стоимБензина;
        public static double стоимБилета;
        private string название;

        public Проезд(string назв)
        { название = назв; }

        public string Название
        { get { return название; } }


        public virtual double Цена()
        {
            Console.Write("Стоимость проезда по маршруту ");
            return 0;
        }

        public virtual void Вывод()
        {
            Console.Write("Название маршрута: " + название);
        }
    }

    //--------------------------------------------------------------------
    class Такси : Проезд
    {
        private double длина;
        private double расход;

        public Такси(string назв, double дл, double расх) : base(назв)
        {
            длина = дл;
            расход = расх;
        }

        public double Длина
        { get { return длина; } }

        public double Расход
        { get  { return расход; } }


        public override double Цена()
        {
            //Console.WriteLine("цена такси = " + длина * расход * стоимБензина);
            return длина * расход / 100 * стоимБензина;
        }

        public override void Вывод()
        {
            Console.WriteLine("Маршрут " + Название + ", длина маршрута " + длина
                + " км, расход бензина " + расход + " л на 100 км, стоимость " + Цена() + " руб.");
        }
    }

    //--------------------------------------------------------------------
    class ГорОбщТранс : Проезд
    {
        private double колвоПересадок;

        public ГорОбщТранс(string назв, double пересадки) : base(назв)
        {  колвоПересадок = пересадки;  }

        public double KолвоПересадок
        {  get  { return колвоПересадок;  }  }       
        
        public override void Вывод()
        {
            Console.WriteLine("Маршрут " + Название + ", количество пересадок " 
                + колвоПересадок + ", стоимость " + Цена() + " руб.");
        }

        public override double Цена()
        {
            // Console.WriteLine("цена автобус = " + колвоПересадок * стоимБилета);
            return (колвоПересадок+1) * стоимБилета;
        }
    }

    //--------------------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            Проезд.стоимБензина = 20;
            Проезд.стоимБилета = 25;
            double min=0;             // Минимум по цене
            int i, n=0;

            List<Проезд> tранспорт = new List<Проезд>();

            tранспорт.Add(new Такси("БМВ", 50.0, 20.0));
            tранспорт.Add(new ГорОбщТранс("Автобус-470", 3));
            tранспорт.Add(new Такси("Волга", 100.0, 30.0));
            tранспорт.Add(new Такси("Мерседес", 100.0, 15.0));
            tранспорт.Add(new ГорОбщТранс("Автобус-595", 4));
            tранспорт.Add(new Такси("Запорожец", 200.0, 5.0));


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\tАрхив маршрутов:");
            Console.WriteLine("\t_______________\n");


            // Вывод всей информации
            foreach (Проезд elem in tранспорт)
            {
                elem.Вывод();
                //elem.Цена();
                Console.WriteLine();
            }

            // Поиск минимального по цене маршрута
            if (tранспорт.Count > 0)
                min = tранспорт[0].Цена();
            else
            {
                Console.WriteLine("Архив маршрутов пустой!");
                goto M;
            }

            for (i = 0; i < tранспорт.Count; i++)
            {
                if (tранспорт[i].Цена() < min)
                {
                    min = tранспорт[i].Цена();
                    n = i;
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nМаршрут с самой низкой стоимостью проезда:");
            Console.WriteLine("-----------------------------------------");
            tранспорт[n].Вывод();

            M:
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("\n\n Для выхода нажмите любую клавишу:");
            Console.ReadKey();

        }
    }
}
