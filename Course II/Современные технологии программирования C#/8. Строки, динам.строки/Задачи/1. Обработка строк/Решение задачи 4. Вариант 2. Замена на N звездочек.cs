using System;
using System.Collections.Generic;
using System.Text;

/*
 Прочитать с клавиатуры строку символов и заменить в ней все 
 десятичные цифры на звездочки. 
 Решение основано на формировании новой строки с 
 последующим копированием ее на место исходной
*/
class Program
{


    static void Main(string[] args)
    {
        string str;
        ConsoleKeyInfo rep;
        do
        {
            Console.Clear();
            Console.Write("Cтрока:  ");
            str = Console.ReadLine();


            string buf = "";
            for (int i = 0; i < str.Length; i++)
                if (str[i] >= '0' && str[i] <= '9')
                    buf = buf.PadRight(buf.Length+(str[i]-'0'), '*');
                else
                    buf = buf + str[i];
            str = buf;



            Console.WriteLine(str);

            Console.WriteLine("Для выхода нажмите ESC ");
            rep = Console.ReadKey(true);
        } while (rep.Key != ConsoleKey.Escape);
    }
}