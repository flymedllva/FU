/*   Вариант 2: используем обмен значениями переменных (пузырек).
 * Разработать консольное приложение, в котором:
 * В переменные х1,х2,х3 ввести три разные числа. Определить переменные A, B, C. 
 * Переменной А присвоить минимальное из трех чисел, 
 * переменной В – среднее, переменной С – максимальное (A <= B <= C). 
 * Вывести переменные A, B, C на экран.
 * Класс Math не использовать.
 * 
 */ 
using System;
class MyExample
{
    public static void Main()
    {

        double x1, x2, x3,
              a, b, c,
            t;


        Console.Write("Ввести x1:");
        x1 = double.Parse(Console.ReadLine());

        Console.Write("Ввести x2:");
        x2 = double.Parse(Console.ReadLine());

        Console.Write("Ввести x3:");
        x3 = double.Parse(Console.ReadLine());

        a = x1; b = x2; c = x3;

        //  Сдвигаем большее значение вправо
        if (a > b)
        {
            t = a; a = b; b = t;
        }

        if (a > c)
        {
            t = a; a = c; c = t;
        }

        if (b > c)
        {
            t = b; b = c; c = t;
        }

        Console.WriteLine("\na={0}  b={1}  c={2}", a, b, c);

        Console.ReadLine();
    }
}
