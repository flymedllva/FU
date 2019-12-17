using System;

class Program
{
    static void Main(string[] args)
    {
        int kol;
        string положение, расположение;

        Console.Write("Введите номер вашего места: ");
        kol = Convert.ToInt32(Console.ReadLine());


        if (kol % 2 == 0)		// Четный номер
            положение = "Верхняя полка";
        else
            положение = "Нижняя полка";


        if (kol % 5 == 0 || kol % 6 == 0)
            расположение = "Боковое место";
        else
            расположение = "Купейное место";

        Console.WriteLine(положение + ", " + расположение);
        Console.ReadKey();
    }
}
