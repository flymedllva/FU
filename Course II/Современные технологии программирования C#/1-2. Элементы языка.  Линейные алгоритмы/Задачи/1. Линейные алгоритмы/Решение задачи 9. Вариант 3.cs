using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¬ведите число: ");
            int x = Convert.ToInt32(Console.ReadLine());  //  int.Parse(...)
            int x1000 = x / 1000;
            int rab2 = x / 100;
            int rab3 = x / 10;
            int x100 = rab2 - (x1000 * 10);
            int x10 = rab3 - (rab2 * 10);
            int x1 = x - (rab3 * 10);
            Console.WriteLine("" + x1 + x10 + x100 + x1000);
        }
    }
}
