// Создать вектор А, , скопировать в вектор В все элементы, 
// значение которых больше min и меньше max.

// Вариант 1. Заранее создаем массив В, равный по длине массиву А. 
// В процессе копирования в массив В элементов, удовлетворяющих условию, 
// подсчитываем их количество, то есть реальную длину массива В.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Копирование1
{
    class Program
    {
        static void zapolnit(int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write("B[{0}]=", i);
                b[i] = int.Parse(Console.ReadLine());
            }
        }

        static int kopia(int[] a, int[] b, int min, int max)
        {
            int k=0;
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i]<=max && a[i]>=min)
                   b[k++] = a[i];
            }
            return k;
        }

        static void zapolnit(int[] b, int A, int B, Random gen)
        {
            for (int i = 0; i < b.Length; i++)
            {

                b[i] = gen.Next(A, B);
            }
        }

        static void vuvod(int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write("{0,5}", b[i]);
                if ((i + 1) % 10 == 0) Console.WriteLine();

            }
        }
        static void vuvod(int[] b, int k)
        {
            for (int i = 0; i < k; i++)
            {
                Console.Write("{0,5}", b[i]);
                if ((i + 1) % 10 == 0) Console.WriteLine();

            }
        }

        static void Main(string[] args)
        {
            int[] a;
            int[] b;
            int n,k;
            Random g = new Random(777);
            Console.Write("n=");
            n = int.Parse(Console.ReadLine());
            a = new int[n];
            b = new int[n];
            zapolnit(a);
            //zapolnit(a, -200, 200, g);
            Console.Clear();
            Console.WriteLine("массив исходный");
            vuvod(a);
            Console.WriteLine();
            Console.WriteLine("массив выходной");
            k = kopia(a, b, 11, 14);
            vuvod(b, k);
            Console.WriteLine();
        }
    }
}
