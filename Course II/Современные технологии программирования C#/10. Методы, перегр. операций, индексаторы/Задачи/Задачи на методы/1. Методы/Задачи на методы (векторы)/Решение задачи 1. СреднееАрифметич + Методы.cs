// Вычислить среднее арифметическое значение элементов вектора.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;           // Длина вектора
            int i;
            float[] a;      // вектор
            float sr;       // среднее арифметическое


            // Ввод исходных данных
            Console.Write("Введите длину вектора: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out n))
                    break;
                Console.Write("Ошибка формата введенного значения. Повторите ввод: ");
            }

            a = new float[n];


            ВводВектора(a, 10, 20);



            // Вычислить среднее арифметическое значение
            for (i = 0, sr = 0; i < n; i++)
            {
                sr = sr + a[i];
            }
            sr = sr / n;


            // Вывод результата

            Console.WriteLine("\n  \t----Исходный вектор---");
            ВыводВектора(a, "{0,7:f2}");
            Console.WriteLine("\n\nсреднее арифметическое значение = " + sr);
        }

        //_______________________________________________________________________
        static void ВводВектора(float[] m)
        {
            for (int i = 0; i < m.Length; i++)
            {
                Console.Write("Введите элемент {0}: ", i);
                if (float.TryParse(Console.ReadLine(), out m[i]) == false)
                {
                    Console.WriteLine("Ошибка формата введенного значения.");
                    i--;
                }
            }
        }

        //_______________________________________________________________________
        static void ВводВектора(float[] m, int a, int b)
        {
            int t;
            if (a > b) { t = b; b = a; a = t; }
            Random rnd = new Random();

            for (int i = 0; i < m.Length; i++)
                m[i] = (b - a) * (float)rnd.NextDouble() + a;
        }
        //_______________________________________________________________________

        static float[] ВводВектора(int n)
        {
            float[] m = new float[n];

            for (int i = 0; i < m.Length; i++)
            {
                Console.Write("Введите элемент {0}: ", i);
                if (float.TryParse(Console.ReadLine(), out m[i]) == false)
                {
                    Console.WriteLine("Ошибка формата введенного значения.");
                    i--;
                }
            }
            return m;
        }

        //_______________________________________________________________________
        static void ВыводВектора(float[] m)
        {
            for (int i = 0; i < m.Length; i++)
                    Console.Write(m[i] + "\t");
        }

        //_______________________________________________________________________
        static void ВыводВектора(float[] m, string format)
        {
            for (int i = 0; i < m.Length; i++)
                    Console.Write(format, m[i]);
        }


    }
}
