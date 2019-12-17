using System;

class Program
{
    static void Main()
    {
        int c = 1022, d, d1,d2;
        bool fl = false;


        d = c * 10;

        for (int i = 0; i <= 900000; i+=100000)
        {
            d1 = d + i;

            for (int j = 0; j <= 9; j++)
            {
                d2=d1++;

                if (d2 % 7 == 0 && d2 % 8 == 0 && d2 % 9 == 0)
                {
                    Console.Write("Число, удовлетворяющее условию: " + d2);
                    Console.WriteLine();
                    fl = true;
                }
            }
        }

        if (!fl) Console.WriteLine("Чисел, удовлетворяющих условию, нет");
    }
}
