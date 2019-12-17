using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Сортировка
{
    /// <summary>
    /// Заполнить одномерный массив целых чисел из N элементов.
    /// Варианты заполнения: 
    ///    - случайными числами из диапазона [A,B)
    ///    - путем ввода данных с клавиатуры
    /// Вариант заполнения определяет пользователь   
    /// Отсортировать массив по убыванию значения элементов,
    /// используя методы класса Array.
    /// Исходный и преобразованный массив вывести 
    /// на экран (не более 10 чисел на строку) 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            char var;          //Вариант выполнения программы
            int[] a;            //Исходный массив
            int   n;            //Количество элементов массива
            bool flag;         //Признак корректного ввода данных  
            const int A = 10, B = 50;         //Границы диапазона
            Random gen = new Random(777);  //Датчик случайных чисел

            while(true)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("ВЫБЕРИТЕ ВАРИАНТ ВЫПОЛНЕНИЯ ПРОГРАММЫ");
                    Console.WriteLine("1. Заполнение вручную");
                    Console.WriteLine("2. Заполнение от датчика");
                    Console.WriteLine("3. Завершение программы");
                    var = Console.ReadKey(true).KeyChar;
                } while (var < '1' || var > '3');

                if(var == '3') return;

                Console.Clear();
                do
                {
                    Console.Write("Сколько элементов: ");
                    flag = int.TryParse(Console.ReadLine(), out n);
                } while (flag == false || n < 1);

                a = new int[n];
               
                if(var == '1')  Заполнить(a);
                if(var == '2')  Заполнить(a, A, B, gen);

                Console.WriteLine("Исходный массив");
                Вывести(a);

                Array.Sort(a);
                Array.Reverse(a);

                Console.WriteLine("\nМассив после сортировки");
                Вывести(a); 
                
                Console.WriteLine("\nНажмите любую клавишу");
                Console.ReadKey(true);
            } 
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
        /// Заполнение массива путем ввода данных с клавиатуры
        /// </summary>
        /// <param name="a">Исходный массив</param>
        static void Заполнить(int[] a)
        {
            int buf;     //Прочитанное значение
            bool flag;  //Признак корректного ввода данных  
            for (int i = 0; i < a.Length; i++)
            {
                do
                {
                    Console.Write("Элемент номер {0}: ",i);
                    flag = int.TryParse(Console.ReadLine(), out buf);
                } while (flag == false);

                a[i] = buf;
            }
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
