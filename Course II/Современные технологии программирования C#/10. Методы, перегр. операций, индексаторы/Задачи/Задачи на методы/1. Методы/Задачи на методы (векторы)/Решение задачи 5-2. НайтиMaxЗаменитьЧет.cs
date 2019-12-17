
// Создать вектор, найти максимальное значение,
// Заменить все четные элементы на максимальное значение
using System;
using System.Collections.Generic;
using System.Text;

namespace НайтиЗаменить
{
    class Program
    {
        static Random gen = new Random();

        static void Main(string[] args)
        {
            //double[] a = new double[] { 22.5, 33.0, 12.25 };
            int n = 5;
            double[] a = new double[n];
            double max;
            Zapolnit(a,-50,50);
            Vivesti(a);
            max = Naiti(a);
            Zamenit(a, max);
            Vivesti(a);
        }

        static void Zapolnit(double[] a)
        {
            Console.WriteLine("Zapolnit");
        }

        static void Zapolnit(double[] a, double min, double max)
        {
            Console.WriteLine("Zapolnit");
            for (int i = 0; i < a.Length; i++)
                a[i] = min + (max - min) * gen.NextDouble();
        }

        static void Vivesti(double[] a)
        {
            Console.WriteLine("Vivesti");
            for (int i = 0; i < a.Length; i++)
                Console.Write("{0,8:f2}", a[i]);
            Console.WriteLine();
        }

        static double Naiti(double[] a)
        {
            Console.WriteLine("Naiti");
            double max = a[0];
            for (int i = 0; i < a.Length; i++)
                if (a[i] >= max)
                    max = a[i];
            return max;
        }

        static void Zamenit(double[] a, double zam)
        {
            Console.WriteLine("Zamenit");
            //for (int i = 0; i < a.Length; i++)
                //if (i % 2 == 0) a[i] = zam;
            for (int i = 0; i < a.Length; i=i+2)
                     a[i] = zam;
        }

    }

}
