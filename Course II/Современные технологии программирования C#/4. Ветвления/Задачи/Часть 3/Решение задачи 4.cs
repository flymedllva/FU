
// Выдать по введенному дню недели или имени
// дня сообщение о характере дня.

using System;

class Program
{
    static void Main(string[] args)
    {
        string день,
               сообщение;

        Console.Title = "День недели";
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Write("\nВведите номер или название дня: ");
        день = Console.ReadLine();

        день = день.ToUpper();

        switch (день)
        {
            case "1":
            case "ПОНЕДЕЛЬНИК":
            case "2":
            case "ВТОРНИК":
            case "3":
            case "СРЕДА":
            case "4":
            case "ЧЕТВЕРГ":
            case "5":
            case "ПЯТНИЦА":
                сообщение = "Рабочий день";
                break;
            case "6":
            case "СУББОТА":
                сообщение = "Для кого-то выходной, а для кого-то нет";
                break;
            case "7":
            case "ВОСКРЕСЕНЬЕ":
                сообщение = "Выходной";
                break;
            default: сообщение = "Не знаю такого дня";
                break;
        }

        Console.WriteLine(сообщение);

        Console.WriteLine("\nДля выхода нажмите Enter");
        Console.ReadLine();
    }
}


