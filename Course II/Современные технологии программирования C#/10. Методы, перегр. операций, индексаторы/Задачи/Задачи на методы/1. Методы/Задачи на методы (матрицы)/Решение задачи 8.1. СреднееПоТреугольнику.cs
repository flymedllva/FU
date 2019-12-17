/*  Вариант вызова: Прочитать(a);
 Дана  вещественная  таблица  размером NxN элементов. Размер таблицы
 вводится с клавиатуры. Вычислить среднеее значение элементов,
 расположенных в треугольнике, образованном левой и нижней
 стороной и главной диагональю таблицы
*/

using System;


class Program
{
    static void Прочитать(int[,] a)
    {
        uint i, j;
        uint n = (uint)a.GetLength(0);

        for (i = 0; i < n; i++)
            for (j = 0; j < n; j++)
            {
                Console.Write("Элемент[{0},{1}]: ", i, j);
                a[i, j] = int.Parse(Console.ReadLine());
            }
            Console.Beep();
    }


    //-----------------------------------------------
    static void Вывести(int[,] a, string формат)
    {
        int i, j;
        uint n = (uint)a.GetLength(0);

        for (i = 0; i < n; i++, Console.WriteLine())
            for (j = 0; j < n; j++)
                Console.Write(формат, a[i, j]);
    }


    //-----------------------------------------------
    static double Вычислить(int[,] a)
    {
        uint i, j, k;
        int s;
        uint n = (uint)a.GetLength(0);

        for (i = 0, k = 0, s = 0; i < n; i++)
            for (j = 0; j <= i; j++)
            {
                k++;
                s = s + a[i, j];
            }
        return (double)s / (double)k;
    }



    //-----------------------------------------------
    static void Main(string[] args)
    {
        int n;        //Размер таблицы
        int[,] a;     //Исходная таблица
        double sr;        //Среднее   

        do
        {
            Console.Write("Размер: ");
            n = int.Parse(Console.ReadLine());

            a = new int[n, n];
            Прочитать(a);

            Console.WriteLine("\nИсходная таблица");
            Вывести(a, "{0,8}");

            sr = Вычислить(a);

            Console.WriteLine("\nСреднее={0:f5}", sr);


            Console.WriteLine("\nДля выхода нажмите клавишу ESC");

        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

}

