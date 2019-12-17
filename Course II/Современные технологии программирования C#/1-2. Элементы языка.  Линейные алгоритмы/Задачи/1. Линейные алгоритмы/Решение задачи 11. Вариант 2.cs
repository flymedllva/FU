// Перевести время, заданное в секундах, в часы, минуты, секунды.
// Вариант 2: используется операция % - получение остатка от деления.

using System;

class Program
{
    static void Main(string[] args)
    {
        int sec;            // Время в секундах (исходное число).
        int hours,          // Ре-
            minutes,        //    зуль-
            seconds;        //         тат.

        Console.Write("Введите время в секундах: ");
        sec = int.Parse(Console.ReadLine());

        hours   = sec / 3600;               // Остаток отбрасывается
        minutes = sec % 3600 / 60;          // Остаток / 60
        seconds = sec % 3600 % 60;          // Остаток

        Console.WriteLine("Текущее время: {0} час. {1} мин. {2} сек.",
                                           hours, minutes, seconds);
        Console.ReadKey();

    }
}
