/*
 Вычислить значение функции Y=F(X)
	      /  
	     |   X + 2         при   X<=0
    Y =    <    Sqrt(4-X*X)   при 0<X<=2
	     |   0             при   X>2
	      \
  Задача решается методом декомпозиции в соответствии со структурным
  подходом
*/

using System;
namespace Функция
{
    class Program
    {
        static void Main(string[] args)
        {
            double x,       // Аргумент
                   y;       // Значение функции 

            Console.Write("Введите аргумент: ");
            x = double.Parse(Console.ReadLine());


            if (x <= 0)
                y = x + 2;
            else
                if (x <= 2)
                    y = Math.Sqrt(4.0 - x * x);
                else
                    y = 0.0;

            Console.WriteLine("При X = " + x + " значение функции = " + Math.Round(y, 2));

            Console.WriteLine("\nДля выхода нажми Enter");
            Console.ReadLine();
        }
    }
}

