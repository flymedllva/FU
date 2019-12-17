/*  Вариант3: Проверяем все возможные сочетания.
 Разработать консольное приложение, в котором:
 в переменные х1,х2,х3 ввести три разные числа. 
 Определить переменные A, B, C. Переменной А присвоить минимальное из трех чисел, 
 переменной В – среднее, переменной С – максимальное (A <= B <= C). 
 Вывести переменные A, B, C на экран. Класс Math не использовать.
 
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


        // Все возможные сочетания (6):
        //     x1<x2<x3
        //     x1<x3<x2

        //     x2<x1<x3
        //     x2<x3<x1

        //     x3<x1<x2
        //     x3<x2<x1

        if (x1 < x2 && x2 < x3)
        {  a = x1; b = x2; c = x3;}

        else if (x1 < x2 && x3 < x2)
        {  a = x1; b = x3; c = x2;}

        else if (x2 < x1 && x1 < x3)
        {   a = x2; b = x1; c = x3;}

        else if (x2 < x3 && x3 < x1)
        {   a = x2; b = x3; c = x1;}

        else if (x3 < x1 && x1 < x2)
        {   a = x3; b = x1; c = x2; }

        else
        {   a = x3; b = x2; c = x1; }


        Console.WriteLine("\na={0}  b={1}  c={2}", a, b, c);

        Console.ReadLine();
    }
}
