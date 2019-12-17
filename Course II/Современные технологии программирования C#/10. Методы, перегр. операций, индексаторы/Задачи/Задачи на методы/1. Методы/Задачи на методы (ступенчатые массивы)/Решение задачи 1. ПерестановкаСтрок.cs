using System;
using System.Collections.Generic;
using System.Text;
/*
 Дана  целочисленная  таблица  размером NxM элементов. Размер таблицы
 вводится с клавиатуры. Поменять местами строки таблицы по правилу:
 строка с номером 0 меняется с последней, строка с номером 1 с пред-
 последней и т.д. 
 Пример: Таблица исходная     ->   1   2   3   4
				                   5   6   7   8
				                   9  10  11  12

	     Таблица перевернутая ->   9  10  11  12
				                   5   6   7   8
				                   1   2   3   4
 Таблица реализуется как массив массивов.
 Элементы строк физически не меняются местами в памяти, 
 переставляются толко ссылки на строки. 
*/


    class Program
    {
       
        
        static void Прочитать(int[][] a)
        {
            int i, j;
            for (i = 0; i < a.Length; i++)
                for (j = 0; j < a[i].Length; j++)
                {
                    Console.Write("Элемент[{0}][{1}]: ", i, j);
                    a[i][j] = int.Parse(Console.ReadLine());
                }
        }

        static void Вывести(int[][] a, string формат)
        {
            int i, j;
            for (i = 0; i < a.Length; i++, Console.WriteLine())
                for (j = 0; j < a[i].Length; j++)
                    Console.Write(формат, a[i][j]);
        }

        static void Переставить(int[][] a)
        {
             int       np,    //Количество пар строк 
                       ном1,  //Номер первой строки в паре
                       ном2;  //Номер второй строки в паре
             int[] b;
             np = a.Length/2;
             for (ном1 = 0, ном2 = a.Length - 1; ном1 < np; ном1++, ном2--)
             {
                 b = a[ном1];
                 a[ном1] = a[ном2];
                 a[ном2] = b;
             }
        }

        static void Main(string[] args)
        {
            int        n,     //Количество строк
                       m,     //Количество столбцов
                       i;     //
            int[][]    a;     //Исходная таблица
            
            ConsoleKeyInfo клавиша; //Нажатая пользователем клавиша

            do
            {
                Console.Clear();
                Console.Write("Сколько строк: ");
                n = int.Parse(Console.ReadLine());
                Console.Write("Сколько столбцов: ");
                m = int.Parse(Console.ReadLine());

                a = new int[n][];
                for (i = 0; i < n; i++)
                    a[i] = new int[m];

                Прочитать(a);
                Console.WriteLine("\nИсходная таблица");
                Вывести(a, "{0,8:d}");

                Переставить(a);

                Console.WriteLine("\nТаблица после перестановки строк");
                Вывести(a,"{0,8:d}");

                Console.WriteLine("\nДля выхода нажмите клавишу ESC");
                клавиша = Console.ReadKey(true);
            } while (клавиша.Key != ConsoleKey.Escape);
        }
    }
