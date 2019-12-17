using System;


class Program
{
    static void Main(string[] args)
    {
        double r,           //Радиус
               s;           //Площадь
        string str;         //Строка ввода 

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Clear();
        Console.Write("Введите радиус: ");
        str = Console.ReadLine();
        r = double.Parse(str);
        s = Math.PI * r * r;
        Console.WriteLine("Площадь=" + s);
        Console.Beep(500, 1000);
    }
}