// Выяснить, какие цифры (по одной справа и слева) надо приписать к числу 1022, 
// чтобы полученное число одновременно делилось на 7, 8, 9. 
// Задачу решить с использованием операций со строками.

using System;
class Program
{
    static void Main(string[] args)
    {
        int A, B; 	//loop
        int b;    	//конечное число
        string str; 	
        
        Console.Write("Отсчёт начался: ");
        for (A = 0; A < 10; A++)
        {
            for (B = 0; B < 10; B++)
            {
                str = (A + "1022" + B);
                b = int.Parse(str);
                if (b%7 == 0 && b%8 == 0 && b% 9 ==0)
                {
                    Console.WriteLine("число:" + b);
                 
                }
            }
        }
        
        Console.Read();
    }
}

