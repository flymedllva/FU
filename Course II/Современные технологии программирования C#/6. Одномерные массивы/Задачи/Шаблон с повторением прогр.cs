using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


class Program
{
    static void Main()
    {
        do
        {
            // Описания переменных.
              ______ x;
            int[] m = { 1, 3, 9, 7, 2, 0, 4, 4 };
            List<int> lst = new List<int>();


            Console.Write("Введите ... : ");
            while (!____.TryParse(Console.ReadLine(), out x))			
                   Console.WriteLine("Вы ошиблись при вводе. Повторите!");


	    // Тело программы
            //. . . . . . . . . . . . . . .


            // Вывод масива на экран
            foreach (var v in m)
                Console.Write(v + "  ");

            	Console.WriteLine("\n\nДля выхода нажмите ESC ");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape); 
    }
}

