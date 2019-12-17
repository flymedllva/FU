using System;
using System.Collections.Generic;

    /// <summary>
    /// Создать массив целых чисел из N элементов. Заполнить массив
    /// путем чтения данных с клавиатуры.
    /// Вывести исходный массив на экран.
    /// 1. Выполнить копирование из исходного массива в выходной массив
    ///     всех элементов, значение которых находится в заданном
    ///     диапазоне [A,B].
    /// 2. Вывести выходной массив на экран.
    /// 3. Вычислить сумму элементов в выходном массиве
    /// Пример: Исходный массив ->  5   10    7     13
    ///               A = 10
    ///               B = 15 
    ///	           Выходной массив ->   10  13
    ///               Сумма = 23 
    /// Вариант решения: Используем типизированный динамический массив
    /// List<T> в качестве выходного массива.
    /// </summary>
class Program
{
    static void Main(string[] args)
    {
        ConsoleKeyInfo rep;
        int[] a;                              //Исходный массив
        int n;                                 //Количество элементов в исходном массиве
        List<int> b;                       //Выходной массив
        int s = 0;                           //Сумма скопированных элементов
        bool flag;                           //Признак корректного ввода данных  
        const int A = 10, B = 15;     //Границы диапазона
        int buf;                              //Прочитанное значение


        do
        {
            Console.Clear();
            do
            {
                Console.Write("Сколько элементов: ");
                flag = int.TryParse(Console.ReadLine(), out n);
            } while (flag == false || n < 1);

            a = new int[n];
            b = new List<int>();     //////////////////////////

            //Заполнить(a);
            for (int i = 0; i < a.Length; i++)
            {
                do
                {
                    Console.Write("Элемент номер {0}: ", i);
                    flag = int.TryParse(Console.ReadLine(), out buf);
                } while (flag == false);

                a[i] = buf;
            }



            Console.WriteLine("Исходный массив");
            // Вывести(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0,5}", a[i]);
                if ((i + 1) % 10 == 0) Console.WriteLine();
            }




            // КопироватьВList(a, b, A, B);
            for (int i = 0; i < a.Length; i++)
                if (a[i] >= A && a[i] <= B)
                    b.Add(a[i]);


            if (b.Count == 0)
                Console.WriteLine("\nВыходной массив пуст");
            else
            {
                Console.WriteLine("\nВыходной массив");
                //Вывести(b);
                for (int i = 0; i < b.Count; i++)
                {
                    Console.Write("{0,5}", b[i]);
                    if ((i + 1) % 10 == 0) Console.WriteLine();
                }

                //s = ВычислитьСумму(b);
                //ВНИМАНИЕ! При обработке элемента типизированного 
                //                   динамического массива явное преобразование
                //                   элемента массива к нужному типу не требуется 
                for (int i = 0; i < b.Count; i++)
                    s += b[i];


                Console.WriteLine("\nСумма скопированных элементов={0}", s);
            }

            Console.WriteLine("\nДля выхода нажмите ESC ");
            rep = Console.ReadKey(true);
        } while (rep.Key != ConsoleKey.Escape);
    }

}