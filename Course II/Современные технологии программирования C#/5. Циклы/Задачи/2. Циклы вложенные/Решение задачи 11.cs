using System;

class Program
{
    static void Main()
    {
        double a = 200, n = 10, ap, sum, mul;

        sum = 0; mul = 1; ap = 1;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
                ap = ap * a;

            sum = sum + 1 / ap;
            mul = mul * (a - i);

        }

        Console.WriteLine("сумма = " + sum + "   Произведение = " + mul);
    }
}
