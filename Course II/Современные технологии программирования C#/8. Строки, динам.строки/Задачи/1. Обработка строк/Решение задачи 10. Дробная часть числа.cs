// Ввести значение вещественного числа. 
// Выделить из числа дробную часть и 
// присвоить ее целой переменной. Вывести целую переменную. 

using System;
class Program
{
    static void Main(string[] args)
    {
        float f;
        string[] w;
        string str;
        int x;

        // Ввод исходного числа
        while (true)
        {
            Console.Write("Введите вещественное число: ");
            str = Console.ReadLine();
            if (float.TryParse(str, out f)) break;
            Console.WriteLine("Вы ошиблись при вводе. Повторите!");
        }

        w = str.Split(',');     // Выделить части числа

        if (w.Length > 1)       // Если есть дробная часть
            x = int.Parse(w[1].TrimEnd('0'));   // Удалить нули с конца и преобразовать
        else
            x = 0;

        Console.WriteLine("Дробная часть числа {0} = {1}", str, x);

        Console.ReadKey();
    }
}
