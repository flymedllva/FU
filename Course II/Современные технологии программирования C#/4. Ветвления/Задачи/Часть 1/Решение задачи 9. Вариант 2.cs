/*  Вариант 2 (короткий)
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
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите координату y: ");
        double y = double.Parse(Console.ReadLine());



        if (Math.Abs(x) + Math.Abs(y) <= 2)
            Console.WriteLine("Точка (х,у) принадлежит фигуре.");
        else
            Console.WriteLine("Точка (х,у) НЕ принадлежит фигуре.");

        Console.ReadKey(true);
    }

}
