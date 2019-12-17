// Создать ступенчатый массив целых чисел. Проверить упорядоченность по возрастанию каждой строки.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace среднее_значение_2_хмерный_массив_
{
    class Program
    {
        static void Ввод(int[][] a, Random g,int min, int max)
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

        static void Вывод(int[][] a)
        {
            int n = a.Length;
            int m = a[0].Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,5}",a[i][j]);
                }
                Console.WriteLine();
            }
        }

        static void Вывод(List<int> a)
        {
            if (a.Count == 0)
            {
                Console.WriteLine("PUSTO");
                return;
            }

            for (int i = 0; i < a.Count; i++)
            {
              Console.Write("{0,5}", a[i]);
            }
        }


        static bool ПроверитьСтроку(int[] a)
        {
            for (int i = 0; i < a.Length-1; i++)
                if (a[i] > a[i + 1]) return false;
            return true;
        }

        static void ЗапомнитьНомер(int[][] a, List<int> b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (ПроверитьСтроку(a[i]) == true)
                    b.Add(i);
            }
        }

        static void Main(string[] args)
        {
            int n,m;
            int[][] a;
            List<int> b;
            b=new List<int>();
            Random g = new Random(777);
            n = 5;
            m = 2;

            a = new int[n][];//создание массива ссылок
            for (int i = 0; i < n; i++)
            {
                a[i]= new int[m];
            }

            Ввод(a, g, 1, 7);
            Console.WriteLine("Исходная матрица");
            Вывод(a);
            ЗапомнитьНомер(a, b);
            Console.WriteLine("\nНомера");
            Вывод(b);
            Console.WriteLine();
        }
    }
}
