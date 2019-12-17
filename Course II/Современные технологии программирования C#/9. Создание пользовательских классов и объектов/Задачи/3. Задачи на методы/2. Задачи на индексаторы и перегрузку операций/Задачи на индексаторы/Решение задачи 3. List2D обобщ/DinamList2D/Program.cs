using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace DynamList2D
{
    class Program : IComparer<string>
    {
        static void Main(string[] args)
        {
            const int n = 3;
            List2D<string> matrix = new List2D<string>(n);

            matrix.AddRow("a00", "a01", "a02");
            matrix.AddRow("b00", "b01", "b02");
            matrix.AddRow("c00", "c01", "c02");
            matrix.AddRow("d00", "d01", "d02");

            Console.WriteLine("\n---Исходная динамическая матрица---------------");
            List2dPrint(matrix);

            Console.WriteLine("\n---Удаляем вторую строку-----------------------");
            matrix.RemoveRow(1);
            List2dPrint(matrix);


            Console.WriteLine("\n---Вставляем строку на вторую позицию ---------");
            Console.WriteLine("---Изменяем элемент [1,0]----------------------");
            matrix.InsertRow(1, "b00", "b01", "b02" );
            matrix[1, 0] = "***";
            List2dPrint(matrix);

           
            Console.WriteLine("\n---Объединяем матрицы--------------------------");
            List2D<string> matrix2 = new List2D<string>(n);

            matrix2.AddRow("e00", "e01", "e02");
            matrix2.AddRow("f00", "f01", "f02");
            matrix2.AddRow("g00", "g01", "g02");

            matrix = matrix + matrix2;
            List2dPrint(matrix);

            Console.WriteLine("\n---Копируем в обычный массив-------------------");
            string[,] strArray = matrix.CopyToArray();
            ArrayPrint(strArray);


                       
            Console.WriteLine("\n---Сортируем матрицу-------------------");
            matrix.AddRow("aaa", "bbb", "ccc");
            Program srt = new Program();
            matrix.Sort(srt);
            List2dPrint(matrix);

        }

        // Реализуем интерфейс IComparer<T>.
        //------------------------------------------------
        public int Compare(string obj1, string obj2)
        {
            return obj1.CompareTo(obj2);
        }


        //------------------------------------------------
        static void List2dPrint(List2D<string> matrix)
        {

            for (int i = 0; i < matrix.CountRow; i++, Console.WriteLine())
                for (int j = 0; j < matrix.CountColumn; j++)
                    Console.Write(matrix[i, j] + "\t");
        }

        //------------------------------------------------
        static void ArrayPrint(object[,] strArray)
        {

            for (int i = 0; i < strArray.GetLength(0); i++, Console.WriteLine())
                for (int j = 0; j < strArray.GetLength(1); j++)
                    Console.Write(strArray[i, j] + "\t");
        }

     }
}
