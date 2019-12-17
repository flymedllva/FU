using System;

class Program
{
    static void Main(string[] args)
    {
        double h, w, a, b, c, min1, min2;

        Console.Write("Введите высоту двери: ");
        h = Double.Parse(Console.ReadLine());

        Console.Write("Введите ширину двери: ");
        w = Double.Parse(Console.ReadLine());

        Console.Write("\nВведите длину первой стороны коробки:  ");
        a = Double.Parse(Console.ReadLine());

        Console.Write("Введите длину второй стороны коробки:  ");
        b = Double.Parse(Console.ReadLine());

        Console.Write("Введите длину третьей стороны коробки: ");
        c = Double.Parse(Console.ReadLine());

        // Определение самой маленькой стороны.
        min1 = Math.Min(a, b);
        min2 = Math.Min(a + b - min1, c);

        // Проверка самой маленькой стороны.
        if (h >= min1 && w >= min2 || h >= min2 && w >= min1)      
            Console.WriteLine("\nКоробка пройдет в дверь! Стороны: " 
                + min1 + ", " + min2);
        else
            Console.WriteLine("Коробка не пройдет в дверь");

        Console.ReadKey();
    }
}
