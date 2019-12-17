/* Вариант 1: для поиска среднего значения используем вычитание.
 Разработать консольное приложение, в котором:
 в переменные х1,х2,х3 ввести три разные числа. 
 Определить переменные A, B, C. Переменной А присвоить минимальное из трех чисел, 
 переменной В – среднее, переменной С – максимальное (A <= B <= C). 
 Вывести переменные A, B, C на экран. Класс Math не использовать.
 Вариант1: использовать if.
 */ 
using System;
class MyExample
{
    public static void Main()
    {

        double x1, x2, x3,
              a, b, c;


        Console.Write("Ввести x1:");
        x1 = double.Parse(Console.ReadLine());

        Console.Write("Ввести x2:");
        x2 = double.Parse(Console.ReadLine());

        Console.Write("Ввести x3:");
        x3 = double.Parse(Console.ReadLine());


        //  Ищем минимальное значение
        if (x1 < x2 && x1 < x3)
            a = x1;
        else if (x2 < x3)
            a = x2;
        else
            a = x3;

        //  Ищем максимальное значение
        if (x1 > x2 && x1 > x3)
            c = x1;
        else if (x2 > x3)
            c = x2;
        else
            c = x3;

        //  Ищем среднее значение

        b = x1 + x2 + x3 - a - c;

        Console.WriteLine("\na={0}  b={1}  c={2}", a, b, c);

        Console.ReadLine();
    }
}
