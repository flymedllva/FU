// —оставить программу, позвол€ющую узнать, войдет ли открытка  
// размерами A,B в конверт размерами X,Y.

using System;
class Program
{
    static void Main(string[] args)
    {
        int t, a, b, x, y;
        Console.Write("¬ведите ширину открытки : ");
        a = int.Parse(Console.ReadLine());

        Console.Write("¬ведите высоту открытки : ");
        b = int.Parse(Console.ReadLine());

        Console.Write("¬ведите ширину конверта : ");
        x = int.Parse(Console.ReadLine());

        Console.Write("¬ведите высоту конверта : ");
        y = int.Parse(Console.ReadLine());

        if (b > a) { t = a; a = b; b = t; }
        if (y > x) { t = x; x = y; y = t; }
        if ((x >= a) & (y >= b))
            Console.WriteLine("ќткрытка войдет в конверт .");
        else
            Console.WriteLine("ќткрытка не войдет в конверт .");

    }
}

