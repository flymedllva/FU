/*
Квадратная целочисленная матрица размером NxN заполняется от датчика случайных чисел 
 * в диапазоне значений от 1 до 10.   Значение N вводится пользователем. 
 * Вычислить  и вывести сумму элементов каждой строки квадратной матрицы, 
 * начиная с элемента, расположенного на побочной диагонали и вправо. 
*/

using System;
class Operator
{
    public static void Main()
    {
        int n,              //Количество строк
               nd,          //Номер диагонали (совпадает с номером строки)
               MIN = 1,     //Левая граница диапазона
               MAX = 10;    //Правая граница диапазона
        int[,] a;           //Ссылка на формируемую матрицу
        int[] s;            //Ссылка на массив сумм
        int i,              //Номер строки
               j;	        //Номер столбца
        string rep;         //Признак повторного выполнения
        string str;         //Строка для вывода и ввода данных
        ConsoleColor color;

        Random ran = new Random(); //Объект - генератор чисел

        do
        {
            Console.Write("Число строк:  ");
            n = int.Parse(Console.ReadLine());

            a = new int[n, n];
            s = new int[n];

            // Инициализация матрицы
            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                    a[i, j] = ran.Next(MIN, MAX + 1);

            // Вывод матрицы
            for (i = 0; i < n; i++, Console.WriteLine())
                for (j = 0; j < n; j++)
                {
                    if (j >= n - i - 1)
                    {
                        color = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0,4}", a[i, j]);
                        Console.ForegroundColor = color;
                    }
                    else
                        Console.Write("{0,4}", a[i, j]);
                }

            //Вычисление сумм подстрок от диагонали вправо
            for (i = 0; i < n; i++)
                for (s[i] = 0, j = n - i - 1; j < n; j++)
                    s[i] += a[i, j];




            // Вывод сумм
            Console.WriteLine("\n\n---Вычисленные суммы подстрок---");
            for (i = 0; i < n; i++)
                Console.Write("{0,4}", s[i]);


            Console.Write("\nДля повтора вычислений намите клавишу Y: ");
            rep = Console.ReadLine();
            Console.WriteLine();
        } while (rep == "Y" || rep == "y");
    } //Конец определения метода
} //Конец объявления класса


