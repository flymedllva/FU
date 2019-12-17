using System;

class Program
{
    static void Main(string[] args)
    {
        double h, w, a, b, c;

        Console.WriteLine("Введите высоту двери");
        h = Double.Parse(Console.ReadLine());

        Console.WriteLine("Введите ширину двери");
        w = Double.Parse(Console.ReadLine());

        Console.WriteLine("Введите высоту коробки");
        a = Double.Parse(Console.ReadLine());

        Console.WriteLine("Введите ширину коробки");
        b = Double.Parse(Console.ReadLine());

        Console.WriteLine("Введите длину коробки");
        c = Double.Parse(Console.ReadLine());


        if (h >= a && w >= b || h >= b && w >= a      // проверка одной стороны
            || h >= a && w >= c || h >= c && w >= a   // проверка второй стороны
            || h >= b && w >= c || h >= c && w >= b)  // проверка третьей стороны
            Console.WriteLine("Коробка пройдет в дверь");
        else
            Console.WriteLine("Коробка не пройдет в дверь");

        Console.ReadKey();
    }
}
