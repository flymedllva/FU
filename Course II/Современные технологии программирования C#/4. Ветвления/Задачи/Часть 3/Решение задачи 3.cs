/*  Определить, какая из точек плоскости A(x1,y1), B(x2,y2), C(x3,y3) 
    расположена  ближе к началу координат.
*/
using System;
class Program
{
    static void Main(string[] args)
    {
        string n;
        double x1, y1, x2, y2, x3, y3,     // Координаты
       p1, p2, p3,          // Расстояния до центра
       k;

        Console.Write("Введите координату X первой точки: ");
        x1 = double.Parse(Console.ReadLine());
        Console.Write("Введите координату Y первой точки: ");
        y1 = double.Parse(Console.ReadLine());

        Console.Write("Введите координату X второй точки: ");
        x2 = double.Parse(Console.ReadLine());
        Console.Write("Введите координату Y второй точки: ");
        y2 = double.Parse(Console.ReadLine());

        Console.Write("Введите координату X третьей точки: ");
        x3 = double.Parse(Console.ReadLine());
        Console.Write("Введите координату Y третьей точки: ");
        y3 = double.Parse(Console.ReadLine());


        p1 = Math.Sqrt(x1 * x1 + y1 * y1);
        p2 = Math.Sqrt(x2 * x2 + y2 * y2);
        p3 = Math.Sqrt(x3 * x3 + y3 * y3);

        k = p1; n = "первая";
        if (k > p2) { k = p2; n = "вторая"; }
        if (k > p3) { k = p3; n = "третья"; }

        Console.WriteLine("{0} точка ближе всех к началу координат \n", n);
    }
}



