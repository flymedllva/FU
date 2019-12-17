// Дана точка А с координатами x,y.  
// Определить  в  каком  квадранте координатной оси она расположена.

using System;
class Program
{
    static void Main(string[] args)
    {
        int x, y;
        Console.WriteLine("Введите две координаты т.А");
        x = int.Parse(Console.ReadLine());
        y = int.Parse(Console.ReadLine());

        if (x == 0) Console.WriteLine("Точка на оси Х");
        else if (y == 0) Console.WriteLine("Точка на оси Y");
        else if (x > 0 && y > 0) Console.WriteLine("Точка А в 1-й четверти");
        else if (x < 0 && y > 0) Console.WriteLine("Точка А во 2-й четверти");
        else if (x < 0 && y < 0) Console.WriteLine("Точка А в 3-й четверти");
        else Console.WriteLine("Точка А в 4-й четверти");
    }
}



