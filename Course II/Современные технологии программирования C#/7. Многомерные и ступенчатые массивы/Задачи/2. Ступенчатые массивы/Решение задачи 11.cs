/*
Сформировать целочисленную матрицу размером mxn.
Значения m и n ввести с клавиатуры.
Заполнить матрицу случайными числами из диапазона от -9 до +9 включительно.
Отпечатать матрицу.
Создать ступенчатый массив из матрицы путем копирования только положительных 
элементов (0 – положительный).
Отсортировать элементы в каждой строке ступенчатого массива.Отпечатать массив.
Перевернуть массив так, чтобы первая строка стала последней, 
а последняя – первой, вторая – предпоследней и т.д.
Отпечатать массив.
*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using C = System.Console;

class Operator
{
    public static void Main()
    {
        do
        {
            int m, n;           //Количество строк и столбцов.

            C.Write("Введите количество строк матрицы: ");
            while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
                C.Write("Вы ошиблись при вводе. Повторите ввод... : ");

            C.Write("Введите количество столбцов матрицы: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                C.Write("Вы ошиблись при вводе. Повторите ввод... : ");



            // Создание, заполнение и печать матрицы.
            C.WriteLine("\n----Исходная матрица----");
            Random rnd = new Random();
            int[,] matr = new int[m, n];

            for (int i = 0; i < m; i++, C.WriteLine())
            {
                for (int j = 0; j < n; j++)
                {
                    matr[i, j] = rnd.Next(-9, 10);
                    C.Write("{0,4}", matr[i, j]);
                }
            }

            // Создание и заполнение ступенчатого массива. Используем List.
            int[][] a = new int[m][];           //создание вектора ссылок.
            for (int i = 0; i < m; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    if (matr[i, j] >= 0)
                        list.Add(matr[i, j]);
                }
                a[i] = list.ToArray();
            }


            // Сортировка строк ступенчатого массива.
            for (int i = 0; i < m; i++)
                Array.Sort(a[i]);

            // Вывод ступенчатого массива на экран.
            C.WriteLine("\n----Массив положительных чисел----");

            for (int i = 0; i < m; i++, C.WriteLine())
                for (int j = 0; j < a[i].Length; j++)
                    C.Write("{0,4}", a[i][j]);


            //---------------------------------------------------

            // Способ 2. Массив а2. Предварительный подсчет.
            int[][] a2 = new int[m][];           //создание вектора ссылок.
            for (int i = 0, k = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matr[i, j] >= 0)
                        k++;
                }
                a2[i] = new int[k];
                k = 0;

                for (int j = 0; j < n; j++)
                {
                    if (matr[i, j] >= 0)
                        a2[i][k++] = matr[i, j];
                }
                k = 0;
            }

            // Вывод ступенчатого массива a2 на экран.
            C.WriteLine("\n----Способ 2. Массив положительных чисел----");

            for (int i = 0; i < m; i++, C.WriteLine())
                for (int j = 0; j < a2[i].Length; j++)
                    C.Write("{0,4}", a2[i][j]);




            C.WriteLine("Для повторения программы нажмите Enter.");
        } while (C.ReadKey(true).Key == ConsoleKey.Enter);
    }
}
