/* Вариант 4. Используем условную операцию. 
        Ввести значения трех переменных x, y, z. 
        Применяя выражения с тернарной операцией ?:, обменяйте 
        значения переменных, чтобы выполнялось требование: 
        x <= y <= z. (Не применять оператор if.)
*/

using System;
namespace Сортировка
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y, z;
            int a1, a2, a3;
            string str;    // Строка для приема данных

            Console.Write("Введите значение x: ");
            x = int.Parse(Console.ReadLine());

            Console.Write("Введите значение y: ");
            y = int.Parse(Console.ReadLine());


            Console.Write("Введите значение z: ");
            z = int.Parse(Console.ReadLine());

            a1 = x;
            a1 = a1 < y ? a1 : y;
            a1 = a1 < z ? a1 : z;

            a3 = x;
            a3 = a3 > y ? a3 : y;
            a3 = a3 > z ? a3 : z;

            a2 = x;
            a2 = a2 > a1 && a2 < a3 ? a2 : y;
            a2 = a2 > a1 && a2 < a3 ? a2 : z;
            x = a1; y = a2; z = a3;


            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + y);
            Console.WriteLine("z = " + z);


            Console.WriteLine("Для выхода из программы нажмите ENTER.");
            Console.ReadLine();

        }
    }
}
