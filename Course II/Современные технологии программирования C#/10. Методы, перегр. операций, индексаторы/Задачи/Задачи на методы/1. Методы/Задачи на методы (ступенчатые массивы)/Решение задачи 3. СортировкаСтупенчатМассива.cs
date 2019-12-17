// Отсортировать по возрастанию строки ступенчатого массива целых чисел. 
// Для сортировки строки использовать метод класса Array.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace среднее_значение_2_хмерный_массив_
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int n,m;
            int[][] a;
            Random g = new Random(777);
            n = 10;
            m = 3;

            a = new int[n][];//создание массива ссылок
            for (int i = 0; i < n; i++)
            {
                a[i]= new int[m];
            }

            Ввод(a, g, 10, 90);
            Console.WriteLine("Исходная матрица");
            Вывод(a);
            Сортировать(a);
            Console.WriteLine("\nПосле сортировки");
            Вывод(a);
            Console.WriteLine();
        }



        //---------------------------------------
        static void Ввод(int[][] a, Random g, int min, int max)
        {
            int n = a.Length;
            int m = a[0].Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i][j] = g.Next(min, max + 1);
                }
            }
        }

        //---------------------------------------
        static void Вывод(int[][] a)
        {
            int n = a.Length;
            int m = a[0].Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,5}", a[i][j]);
                }
                Console.WriteLine();
            }
        }

        //---------------------------------------
        static void Сортировать(int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Array.Sort(a[i]);
            }
        }

    }
}
