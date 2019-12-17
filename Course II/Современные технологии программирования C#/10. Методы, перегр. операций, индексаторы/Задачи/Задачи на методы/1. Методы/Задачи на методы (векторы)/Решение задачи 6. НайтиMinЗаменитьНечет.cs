using System;
using System.Collections.Generic;
using System.Text;

namespace ОдномерныйМассив
{
    /// <summary>
    /// Заполнить одномерный массив целых чисел из N эементов
    /// случайными числами из диапазона [A,B). Найти минимальное 
    /// значение в массиве и его номер. Если минимальных значений
    /// несколько - запомнить последнее минимальное значение
    /// и его номер. Заменить все элементы с нечетными
    /// номерами на номер минимального элемента. 
    /// Исходный и преобразованный массив вывести 
    /// на экран (не более 10 чисел на строку) 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo rep;
            int[] a;      //Исходный массив
            int   min,    //Минимальное значение
                   num;   //Номер элемента с минимальным значением
            int   n;        //Количество элементов массива
            bool flag;         //Признак корректного ввода данных  
            const int A = -50, B = 50;         //Границы диапазона
            Random gen = new Random(777);  //Датчик случайных чисел

            do
            {
                Console.Clear();
                do
                {
                    Console.Write("Сколько элементов: ");
                    flag = int.TryParse(Console.ReadLine(), out n);
                } while (flag == false || n < 1);

                a = new int[n];

                Заполнить(a,A,B,gen);
               
                Console.WriteLine("Исходный массив");
                Вывести(a);

                Найти(a,out min, out num);
                Console.WriteLine("\nМинимальное значение: {0}", min);
                Console.WriteLine("Номер минимального значения: {0}", num);

                Заменить(a,num);

                Console.WriteLine("\nПреобразованный массив");
                Вывести(a); 
                
                Console.WriteLine("\nДля выхода нажмите ESC ");
                rep = Console.ReadKey(true);
            } while (rep.Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Поиск минимального элемента и его номера 
        /// </summary>
        /// <param name="a">Исходный массив</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="num">Номер минимального значения</param>
        static void Найти(int[] a, out int min, out int num)
        {
            min = a[0];
            num = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] <= min)
                {
                    min = a[i];
                    num = i;
                }
        }

        /// <summary>
        /// Замена элементов с нечетными номерами на заданное значение
        /// </summary>
        /// <param name="a">Исходный массив</param>
        /// <param name="b">Значение для замены</param>
        static void Заменить(int[] a,  int b)
        {
            for (int i = 1; i < a.Length; i += 2)
                a[i] = b;
        }

        /// <summary>
        /// Заполнение массива случайными числами
        /// </summary>
        /// <param name="a">Исходный массив</param>
        /// <param name="A">Левая граница</param>
        /// <param name="B">Правая граница</param>
        /// <param name="gen">Генератор случайных чисел</param>
        static void Заполнить(int[] a, int A, int B, Random gen)
        {
            for (int i = 0; i < a.Length; i++)
                a[i] = gen.Next(A, B);
        }

        /// <summary>
        /// Вывод массива
        /// </summary>
        /// <param name="a">Выводимый массив</param>
        static void Вывести(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0,5}", a[i]);
                if ((i + 1) % 10 == 0) Console.WriteLine();
            }
        }
    }
}

