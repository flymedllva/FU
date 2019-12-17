/*
Разработать консольное приложение для вывода одного из сообщений:

·	точка с координатами (X,Y) попадает в фигуру
·	точка с координатами (X,Y) не попадает в фигуру

Фигура - сектор круга радиусом R=2 в диапазоне углов 180<= fi <=45
Попадание в круг:    x*x + y*y <= R*R  
Аргументы Х и Y ввести с клавиатуры.
 */

using System;

class Operator
{
    public static void Main()
    {
        Console.WriteLine("Введите координату х ");
        string dub = Console.ReadLine();
        double x = Convert.ToDouble(dub);

        Console.WriteLine("Введите координату y ");
        dub = Console.ReadLine();
        double y = double.Parse(dub);

        if ((x * x + y * y <= 4 && y <= 0) || (x * x + y * y <= 4 && x >= y))
            Console.WriteLine("Точка (х,у) принадлежит фигуре.");
        else 
            Console.WriteLine("Точка (х,у) НЕ принадлежит фигуре.");

        Console.ReadKey(true);
    }

}
