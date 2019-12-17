/*
Разработать приложение, осуществляющее ввод координат точки (X,Y) 
и проверку попадания точки в замкнутую фигуру. 
Фигура образована прямыми, описываемыми следующими уравнениями:    
          Y = -X + 2;   Y = X + 2;   Y = X – 2;   Y = -X - 2
 */

using System;

class Operator
{
    public static void Main()
    {
        Console.Write("Введите координату х: ");
        string str = Console.ReadLine();
        double x = Convert.ToDouble(str);

        Console.Write("Введите координату y: ");
        str= Console.ReadLine();
        double y = double.Parse(str);

        if ((-x + 2) >= y && (x + 2) >= y && (x - 2) <= y &&(-x - 2) <= y)
            Console.WriteLine("Точка (х,у) принадлежит фигуре.");
        else 
            Console.WriteLine("Точка (х,у) НЕ принадлежит фигуре.");

        Console.ReadKey(true);
    }

}
