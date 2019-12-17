using System;

class Program
{
    static void Main(string[] args)
    {
        int sec;            // Время в секундах (исходное число).
        int seconds,
            minutes,
            hours;

        Console.Write("Введите время в секундах: ");
        sec = int.Parse(Console.ReadLine());

        hours = sec / 3600;                 // Остаток отбрасывается
        minutes = (sec - hours * 3600) / 60;          // Остаток / 60
        seconds = (sec - hours * 3600) - minutes * 60;          // Остаток

        Console.WriteLine("Текущее время: {0} час. {1} мин. {2} сек.",
                                           hours, minutes, seconds);
        Console.ReadKey();

    }
}
