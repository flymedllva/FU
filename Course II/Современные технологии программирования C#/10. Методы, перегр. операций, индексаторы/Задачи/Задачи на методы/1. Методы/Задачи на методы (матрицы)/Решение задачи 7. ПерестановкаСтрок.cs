using System;
using System.Collections.Generic;
using System.Text;
/*
 Дана  вещественная  таблица  размером NxM элементов. Размер таблицы
 вводится с клавиатуры. Поменять местами строки таблицы по правилу:
 строка с номером 0 меняется с последней, строка с номером 1 с пред-
 последней и т.д. 
 Пример: Таблица исходная     ->   1.0   2.0   3.0   4.0
				                   5.0   6.0   7.0   8.0
				                   9.0  10.0  11.0  12.0

	     Таблица перевернутая ->   9.0  10.0  11.0  12.0
				                   5.0   6.0   7.0   8.0
				                   1.0   2.0   3.0   4.0
 Решение "в лоб": таблица рассматривается как двухмерный массив.
 Элементы строк физически меняются местами в памяти. 
*/



    class Program
    {
        static void Прочитать(double[,] a, int n, int m)
        {
            int i, j;
            for (i = 0; i < n; i++)
                for (j = 0; j < m; j++)
                {
                    Console.Write("Элемент[{0},{1}]: ", i, j);
                    a[i, j] = double.Parse(Console.ReadLine());
                }
        }

        static void Вывести(double[,] a, int n, int m, string формат)
        {
            int i, j;
            for (i = 0; i < n; i++, Console.WriteLine())
                for (j = 0; j < m; j++)
                    Console.Write(формат, a[i, j]);
        }

        
        //Назначение - Перестановка пары заданных строк таблицы
        //Входные параметры
        //  a   -  исходная таблица
        //  ном1 - номер первой строки в паре
        //  ном2 - номер второй строки в паре
        //  m -   количество столбцов
        static void Переставить(double[,] a, int n, int m)
        {
            int    i,j,ном1,ном2;    
            int    np;   
            double b;    // буфер для временного хранения элемента таблицы
            np = n / 2;
            for (ном1 = 0, ном2 = n - 1; ном1 < np; ном1++, ном2--) 
            for (j = 0; j < m; j++)
            {
                b = a[ном1, j];
                a[ном1, j] = a[ном2, j];
                a[ном2, j] = b;
            }         
        }

        static void Main(string[] args)
        {
            int       n,     //Количество строк
                      m,     //Количество столбцов
                      mp,    //Количество пар строк 
                      ном1,  //Номер первой строки в паре
                      ном2;  //Номер второй строки в паре
            double[,] a;     //Исходная таблица
           
            ConsoleKeyInfo клавиша; //Нажатая пользователем клавиша

            do
            {
                Console.Clear();
                Console.Write("Сколько строк: ");
                n = int.Parse(Console.ReadLine());
                Console.Write("Сколько столбцов: ");
                m = int.Parse(Console.ReadLine());

                a = new double[n, m];
                Прочитать(a, n, m);
                Console.WriteLine("\nИсходная таблица");
                Вывести(a, n, m, "{0,8:f2}");
               
                Переставить(a, n, m); 

                Console.WriteLine("\nТаблица после перестановки строк");
                Вывести(a, n, m, "{0,8:f2}");

                Console.WriteLine("\nДля выхода нажмите клавишу ESC");
                клавиша = Console.ReadKey(true);
            } while (клавиша.Key != ConsoleKey.Escape);
        }
        
    }

