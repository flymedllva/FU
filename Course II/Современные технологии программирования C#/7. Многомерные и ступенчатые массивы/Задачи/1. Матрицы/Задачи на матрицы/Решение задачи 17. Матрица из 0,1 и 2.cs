/* Создать двухмерный массив размером NxM и заполнить его случайным образом 
 * числами 0,1 и 2.
 * Запомнить в одномерном массиве номера строк, которые имеют равное кол-во 
 * нулей и единиц.
 * Значения N и M вводятся пользователем. 
 * Исходный массив и сформированный выдать на экран. 
 */

/* Ограничение: строка, не имеющая ни нулей ни единиц, считается строкой, 
 * имеющей разное кол-во 0 и 1
 */
using System.Collections.Generic;
using System;


class Program
{
    static void Main(string[] args)
    {

        while (true)
        {
            List<int> ar2 = new List<int>();
            uint n = 0, m = 0;

            while (true)
            {
                try
                {
                    Console.Write("Введите количество строк: ");
                    m = uint.Parse(Console.ReadLine());
                    Console.Write("Введите количество столбцов: ");
                    n = uint.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception) { Console.WriteLine("Одно из значений неверно"); }
            }

            int[,] mas = new int[m, n];
            Random r = new Random();

            for (int i = 0; i < m; i++, Console.WriteLine())
                for (int j = 0; j < n; j++)
                {
                    mas[i, j] = r.Next(0, 3);
                    Console.Write(mas[i, j] + " ");
                }
            Console.WriteLine();

            Console.Write("Сроки с равным кол-вом 0 и 1 (индексы идут с 0): ");

            int zero, one;

            for (int i = 0; i < m; i++)
            {
                zero = 0; one = 0;
                for (int j = 0; j < n; j++)
                {
                    if (mas[i, j] == 0) zero++;
                    if (mas[i, j] == 1) one++;
                }
                if ((one == zero) && (one != 0))  ar2.Add(i);
            }


            if (ar2.Count == 0)  
                Console.WriteLine("Таких строк нет!");
            else
                foreach (var a in ar2)
                    Console.Write(a + " ");


            Console.WriteLine("\nДля выхода нажмите ESC");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)  return;
        }
    }
}