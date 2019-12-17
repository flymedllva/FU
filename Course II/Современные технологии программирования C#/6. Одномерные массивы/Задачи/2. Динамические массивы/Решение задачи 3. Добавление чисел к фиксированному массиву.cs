/*Создать фиксированный массив и проинициализировать его целыми числами. 
Ввести с клавиатуры два числа и добавить их к этому массиву. 
Вывести расширенный массив на экран.
*/

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        do
        {
            // Описания переменных.
            int[] m = { 1, 3, 9, 7, 2, 0, 4, 4 };
            int m1, m2;
            List<int> lst = new List<int>();

            Console.Write("Введите число 1: ");
            while (!int.TryParse(Console.ReadLine(), out m1))
                Console.WriteLine("Вы ошиблись при вводе. Повторите!");

            Console.Write("Введите число 2: ");
            while (!int.TryParse(Console.ReadLine(), out m2))
                Console.WriteLine("Вы ошиблись при вводе. Повторите!");


            // Тело программы
            lst = m.ToList();
            lst.Add(m1);
            lst.Add(m2);

            m = lst.ToArray();

            foreach (var v in m)
                Console.Write(v + "  ");
            Console.WriteLine("\nДля выхода нажмите ESC ");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}

