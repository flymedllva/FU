/*Задача. Ввести значение вещественного числа и вывести значение 
         ближайшего к нему по абсолютной величине целого числа. 
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        double x,             // Значение числа 
                   d;            // Поправка 
        int res;          // Ближайшее целое
        string line;          // Строка для приема данных

        Console.Write("Введите вещественное число:  ");
        line = Console.ReadLine();
        x = double.Parse(line);

        d = x > 0 ? 0.5 : -0.5; // Поправка
        res = (int)(x + d);     // Приведение типов
        Console.WriteLine("Ближайшее целое: " + res);
    }
}
