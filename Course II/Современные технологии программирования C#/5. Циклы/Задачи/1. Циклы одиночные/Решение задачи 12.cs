using System;

class Program
{
    static void Main()
    {
        int c, c1, c2, c3, c4, count = 0;

        for (int i = 2000; i <= 3000; i++)
        {
            c = i;

            c4 = c % 10;
            c /= 10;

            c3 = c % 10;
            c /= 10;

            c2 = c % 10;
            c /= 10;

            c1 = c % 10;
            
            if (c1!=c2 && c1!=c3 && c1!=c4 && c2!=c3&& c2!=c4 && c3 != c4)
                count++;
        }

        Console.WriteLine("Чисел, удовлетворяющих условию, " + (count == 0 ? "нет" : count.ToString()));
    }
}
