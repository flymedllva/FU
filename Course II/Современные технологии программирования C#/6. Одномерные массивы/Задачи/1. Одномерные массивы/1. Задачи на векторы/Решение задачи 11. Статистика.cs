using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Статистика
{
    /// <summary>
    /// Заполнить одномерный массив вещественных чисел из N элементов
    /// случайными числами из диапазона [A,B). Найти оценку математического
    /// ожидания, дисперсии и среднего квадратического отклонения
    /// элементов этого массива.
    /// Исходный массив вывести на экран (не более 10 чисел на строку) 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo rep;
            double[]  a;      //Исходный массив
            double    mo,    //Математическое ожидание
                          d,      //Дисперсия
                          cko;   //Среднее квадратическое отклонение
            int          n;      //Количество элементов массива
            bool flag;         //Признак корректного ввода данных  
            const double A = -50, B = 50;         //Границы диапазона
            Random gen = new Random(777);  //Датчик случайных чисел

            do
            {
                Console.Clear();
                do
                {
                    Console.Write("Сколько элементов: ");
                    flag = int.TryParse(Console.ReadLine(), out n);
                } while (flag==false || n < 2);

                a = new double[n];

                Заполнить(a, A, B, gen);

                Console.WriteLine("Исходный массив");
                Вывести(a);

                mo = МатОжидание(a);

                d = Дисперсия(a, mo);

                cko = Math.Sqrt(d);

                Console.WriteLine("\nМатематическое ожидание: {0:F2}", mo);
                Console.WriteLine("\nДисперсия: {0:F2}", d);
                Console.WriteLine("\nСреднее квадратическое отклонение: {0:F2}", cko);

                Console.WriteLine("\nДля выхода нажмите ESC ");
                rep = Console.ReadKey(true);
            } while (rep.Key != ConsoleKey.Escape); 
        }

        /// <summary>
        /// Вычисление оценки дисперсии
        /// </summary>
        /// <param name="a">Исходный массив</param>
        /// <param name="mo">Математическое ожидание</param>
        /// <returns>Оценка дисперсии</returns>
        static double Дисперсия(double[] a, double mo)
        {
            double d = 0;
            for (int i = 0; i < a.Length; i++) d += ((a[i] - mo) * (a[i] - mo));
            d /= (a.Length - 1);
            return d;
        }

        /// <summary>
        /// Вычисление оценки математического ожидания
        /// </summary>
        /// <param name="a">Исходный массив</param>
        /// <returns>Оценка математического ожидания</returns>
        static double МатОжидание(double[] a)
        {
            double mo = 0;
            for (int i = 0; i < a.Length; i++) mo += a[i];
            mo /= a.Length;
            return mo;
        }

        /// <summary>
        /// Вывод массива
        /// </summary>
        /// <param name="a">Выводимый массив</param>
        static void Вывести(double[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0,8:F2}", a[i]);
                if ((i + 1) % 10 == 0) Console.WriteLine();
            }
        }

        /// <summary>
        /// Заполнение массива случайными числами
        /// </summary>
        /// <param name="a">Исходный массив</param>
        /// <param name="A">Левая граница</param>
        /// <param name="B">Правая граница</param>
        /// <param name="gen">Генератор случайных чисел</param>
        static void Заполнить(double[] a, double A, double B, Random gen)
        {
            for (int i = 0; i < a.Length; i++)
                a[i] = A + (B - A) * gen.NextDouble();
        }
    }
}
