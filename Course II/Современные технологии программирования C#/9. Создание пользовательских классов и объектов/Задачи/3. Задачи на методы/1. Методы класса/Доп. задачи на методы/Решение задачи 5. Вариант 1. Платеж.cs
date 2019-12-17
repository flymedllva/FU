using System;
using System.Collections.Generic;
using System.Text;

namespace Платеж1
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
            Console.WriteLine("Итого: {0:f2}",сум);
        }

        static void Main(string[] args)
        {
            int посл, пред;
            Console.Title = "Расчет стоимости потребления электроэнергии";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            посл = Последнее();
            пред = Предыдущее();
            Вычислить(посл, пред);
            Console.ReadKey();
        }
    }
}
