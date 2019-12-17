// Выдать по введенному дню недели или имени
// дня сообщение о характере дня

using System;

class Program
{
    static void Main(string[] args)
    {
        string day, msg = "";
        day = Console.ReadLine();
        switch (day)
        {
            case "6":
            case "Суббота": msg = "Выходной"; break;
            case "7":
            case "Воскресенье": msg = "Выходной"; break;
            default: msg = "Рабочий"; break;
        }
        Console.WriteLine(msg);
    }
}


