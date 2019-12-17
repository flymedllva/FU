using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;

            Console.WriteLine("Введите длину 1 катета");
            a = Double.Parse(Console.ReadLine());
             Console.WriteLine("Введите длину 2 катета");
            b = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите длину гипотенузы");
            c = Double.Parse(Console.ReadLine());

            if ((Math.Pow(a,2) + Math.Pow(b,2)) == Math.Pow(c,2))
                Console.WriteLine("Треугольник является прямоугольным");
            else Console.WriteLine("Треугольник не является прямоугольным");

            Console.ReadKey();
        }
    }
}
