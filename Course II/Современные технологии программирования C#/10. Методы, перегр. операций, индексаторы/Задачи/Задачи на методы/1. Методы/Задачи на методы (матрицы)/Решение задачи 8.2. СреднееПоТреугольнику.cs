/*  Вариант вызова: double[,] a = Прочитать(n, n);     
 Дана  вещественная  таблица  размером NxN элементов. Размер таблицы
 вводится с клавиатуры. Вычислить среднеее значение элементов,
 расположенных в треугольнике, образованном левой и нижней
 стороной и главной диагональю таблицы
 
*/

using System;

class Program
{
    static double[,] Прочитать(int m, int n)
    {
        int i, j;
        double[,] a = new double[m, n];       
        for (i = 0; i < m; i++)
            for (j = 0; j < n; j++)
            {
                Console.Write("Элемент[{0},{1}]: ", i, j);
                a[i, j] = double.Parse(Console.ReadLine());
            }
        Console.Beep();

        return a;
    }

    //--------------------------------------------------
    static void Вывести(double[,] a, string формат)
    {
        int i, j;
        int n = a.GetLength(0);
        for (i = 0; i < n; i++, Console.WriteLine())
            for (j = 0; j < n; j++)
                Console.Write(формат, a[i, j]);
    }


    //--------------------------------------------------
    static double Вычислить(double[,] a)
    {
        int i, j, k, jmax;
        int n = a.GetLength(0);
        double s;

        for (i = 0, k = 0, s = 0, jmax = 0; i < n; i++, jmax++)
            for (j = 0; j <= jmax; j++)
            {
                k++;
                s = s + a[i, j];
            }
        return s / k;
    }

    //--------------------------------------------------
    static void Main(string[] args)
    {
        int n;        //Размер таблицы
        double sr;        //Среднее   

        do
        {
            Console.Write("Размер: ");
            n = int.Parse(Console.ReadLine());

            double[,] a = Прочитать(n, n);     //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            Console.WriteLine("\nИсходная таблица");
            Вывести(a, "{0,8:f2}");

            sr = Вычислить(a);

            Console.WriteLine("\nСреднее={0:f2}", sr);


            Console.WriteLine("\nДля выхода нажмите клавишу ESC");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

}

