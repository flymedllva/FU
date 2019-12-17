using System;
using System.Collections.Generic;
using System.Text;

namespace Платеж2
{
    class Program
    {
        public static double тариф = 2.08;

        public static int Последнее()
        {
            Console.Write("Последнее показание счетчика: ");
            return int.Parse(Console.ReadLine());
        }

        public static int Предыдущее()
        {
            Console.Write("Предыдущее показание счетчика: ");
            return int.Parse(Console.ReadLine());
        }

        public static void Вычислить(int посл, int пред)
        {
            double сум;
            int потр;
            потр = посл - пред;
            сум = потр * тариф;
            Console.WriteLine("Потребление: {0}", потр);
            Console.WriteLine("Итого: {0:f2}", сум);
        }

        static void Main(string[] args)
        {
            int посл=0, пред=0;
            ConsoleKeyInfo событие;
            Console.Title = "Расчет стоимости потребления электроэнергии";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Последнее\n2.Предыдущее");
                Console.WriteLine("3.Вычислить\n4.Выход");
                событие = Console.ReadKey(true);
                switch (событие.KeyChar)
                {
                    case '1': посл = Последнее(); break;
                    case '2': пред = Предыдущее(); break;
                    case '3': Вычислить(посл, пред); Console.ReadKey(); break;
                    default: return;
                }
            }
        }
    }
}
