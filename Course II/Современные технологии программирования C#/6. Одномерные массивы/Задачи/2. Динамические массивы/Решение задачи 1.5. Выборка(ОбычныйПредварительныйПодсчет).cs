using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Выборка
{
    /// <summary>
    /// Создать массив целых чисел из N элементов. Заполнить массив
    /// путем чтения данных с клавиатуры.
    /// Вывести исходный массив на экран.
    /// 1. Выполнить копирование из исходного массива в выходной массив
    ///     всех элементов, значение которых находится в заданном
    ///     диапазоне [A,B].
    /// 2. Вывести выходной массив на экран.
    /// 3. Вычислить сумму элементов в выходном массиве
    /// Пример: Исходный массив ->  5   10    7     13
    ///               A = 10
    ///               B = 15 
    ///	           Выходной массив ->   10  13
    ///               Сумма = 23 
    /// Вариант решения: Используем выходной массив с размером,
    /// совпадающим по размеру с количеством   копируемых элементов.
    /// Количество копируемых элементов считается предварительно               
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo rep;
            int[] a;             //Исходный массив
            int n;               //Количество элементов в исходном массиве
            int[] b=null;     //Выходной массив
            int k;                //Количество скопированных элементов
            int s=0;            //Сумма скопированных элементов
            bool flag;          //Признак корректного ввода данных  
            const int A = 10, B = 15;         //Границы диапазона

            do
            {
                Console.Clear();
                do
                {
                    Console.Write("Сколько элементов: ");
                    flag = int.TryParse(Console.ReadLine(), out n);
                } while (flag == false || n < 1);

                a = new int[n];

                Заполнить(a);

                Console.WriteLine("Исходный массив");
                Вывести(a);

                k = СчитатьКоличество(a, A, B);

                if (k == 0)
                    Console.WriteLine("\nВыходной массив пуст");
                else
                {
                    b = new int[k];
                    Копировать(a, b, A, B);
                    Console.WriteLine("\nВыходной массив");
                    Вывести(b);
                    s = ВычислитьСумму(b);
                    Console.WriteLine("\nСумма скопированных элементов={0}", s);
                }

                Console.WriteLine("\nДля выхода нажмите ESC ");
                rep = Console.ReadKey(true);
            } while (rep.Key != ConsoleKey.Escape);
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
                    Console.Write("Элемент номер {0}: ", i);
                    flag = int.TryParse(Console.ReadLine(), out buf);
                } while (flag == false);

                a[i] = buf;
            }
        }

       
        /// <summary>
        /// Вывод первых элементов массива 
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

        /// <summary>
        /// Вычисление суммы элеметов массива
        /// </summary>
        /// <param name="a">Обрабатываемый массив</param>
       /// <returns>Сумма первых  элементов</returns>
        static int ВычислитьСумму(int[] a)
        {
            int s = 0;
            for (int i = 0; i < a.Length; i++) s += a[i];
            return s;
        }

        /// <summary>
        /// Копирование элементов в заданном диапазоне значений
        /// </summary>
        /// <param name="a">Обрабатываемый массив</param>
        /// <param name="b">Массив для хранения копий</param>
        /// <param name="A">Левая граница лиапазона</param>
        /// <param name="B">Правая граница лиапазона</param>
        /// <returns>Количество скопированных элементов</returns>
        static void Копировать(int[] a, int[] b, int A, int B)
        {
            int k = 0;
            for (int i = 0; i <a.Length; i++)
                if (a[i] >= A && a[i] <= B)
                {
                    b[k] = a[i];
                    k++;
                }
        }

        /// <summary>
        /// Вычисление количества элементов в заданном диапазоне значений
        /// </summary>
        /// <param name="a">Обрабатываемый массив</param>
        /// <param name="A">Левая граница лиапазона</param>
        /// <param name="B">Правая граница лиапазона</param>
        /// <returns>Количество элементов</returns>
        static int СчитатьКоличество(int[] a, int A, int B)
        {
            int k = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] >= A && a[i] <= B) 
                    k++;
            return k;
        }
    }
}
