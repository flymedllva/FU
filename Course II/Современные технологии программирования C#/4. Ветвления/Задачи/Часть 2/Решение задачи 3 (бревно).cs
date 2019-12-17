using System;
    class Program
    {
        static void Main(string[] args)
        {
            double D, W;

            Console.Write("Введите диаметр бревна: ");
            D = Double.Parse(Console.ReadLine());
            Console.Write("Введите ширину бруса: ");
            W = Double.Parse(Console.ReadLine());

            if (W * Math.Sqrt(2) < D)
                Console.WriteLine("Можно выпилить брус");
            else Console.WriteLine("Нельзя выпилить брус");

            Console.ReadKey();

        }
    }
