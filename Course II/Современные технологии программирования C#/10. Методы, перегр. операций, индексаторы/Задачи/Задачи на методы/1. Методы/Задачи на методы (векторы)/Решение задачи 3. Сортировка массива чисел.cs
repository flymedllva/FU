// Отсортировать в порядке убывания одномерный массив целых чисел, используя методы класса Array.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace сортировка_чисел_массивы_
{
    class Program
    {
        static void zapolnit(int[] b)
        { for(int i=0; i<b.Length; i++)
            {
            Console.Write("B[{0}]=",i);
            b[i] = int.Parse(Console.ReadLine());
            }
        }

        static void zapolnit(int[] b,int A, int B,Random gen)
        {
            for (int i = 0; i < b.Length; i++)
            {
                
                b[i] = gen.Next(A,B);
            }
        }

        static void vuvod(int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write("{0,5}", b[i]);
                if ((i+1) % 10 == 0) Console.WriteLine();
                
            }
        }
            
        static void Main(string[] args)
        {
            int[] a;
            int n;
            Random g= new Random(777);
            Console.Write("n=");
            n = int.Parse(Console.ReadLine());
            a = new int[n];
            //zapolnit(a);
            zapolnit(a, -200, 200, g);
            Console.Clear();
            Console.WriteLine("массив исходный");
            vuvod(a);
            Console.WriteLine();
            Array.Sort(a);
            Array.Reverse(a);
            Console.WriteLine("массив сортитованный");
            vuvod(a);
            Console.WriteLine();

        }
    }
}
