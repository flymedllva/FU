// Найти корни квадратного уравнения

using System;
class Program
{
    static void Main(string[] args)
    {
        double d, a, b, c;
        double x1, x2;

        Console.WriteLine("\n Решение квадратного уравнения ");
        Console.WriteLine("Ведите коэффициенты уравнения a,b,c");

        Console.Write("a=");
        a = double.Parse(Console.ReadLine());

        Console.Write("b=");
        b = double.Parse(Console.ReadLine());

        Console.Write("c=");
        c = double.Parse(Console.ReadLine());

        d = b * b - 4 * a * c;      // Дискриминант

        Console.Write("Дискриминант = " + d);

        if (d < 0)
            Console.Write("Корней нет");
        else
        {
            if (d > 0)
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("Корни уравнения x1={0}  x2={1}", x1, x2);
            }
            else
            {
                x1 = (-b) / (2 * a);
                Console.WriteLine("Корень уравнения x1=" + x1);
            }
        }
    }
}

