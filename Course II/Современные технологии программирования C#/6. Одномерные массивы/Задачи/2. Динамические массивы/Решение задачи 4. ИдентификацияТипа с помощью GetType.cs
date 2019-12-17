using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;  //!!!!!!!!
namespace ИдентификацияТипа
{
    /// <summary>
    /// Занести в массив данные о сотрудниках учреждения:
    /// - фамилия (строка)
    /// - возраст   (целое)
    /// - оклад     (вещественное)
    /// Порядок занесения данных - произволный
    /// Пример1:  Иванов   35    25.8
    ///           Петров    40    28.3
    /// Пример2:  Иванов   Петров
    ///           35          40
    ///           25.8       28.3
    /// По данным, хранящимся в массиве:
    /// 1. Выдать все фамилии
    /// 2. Вычислить минимальный возраст
    /// 3. Вычислить средний оклад
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo rep;
            ArrayList a;
            int возраст; 
            int количествоОклад; 
            double среднийОклад;

            do
            {
                a = new ArrayList();
                
                Заполнить(a);
                
                ВывестиФамилии(a);

                возраст = ОпределитьВозраст(a);
                if (возраст == int.MaxValue)
                      Console.WriteLine("Данных о возрасте нет");
                else
                      Console.WriteLine("Минимальный возраст={0}", возраст);

                количествоОклад = ОпределитьОклад(a, out среднийОклад);
                if (количествоОклад == 0)
                    Console.WriteLine("Данных об окладе нет");
                else
                    Console.WriteLine("Средний оклад={0:f2}", среднийОклад);

                Console.WriteLine("\nДля выхода нажмите ESC ");
                rep = Console.ReadKey(true);
            } while (rep.Key != ConsoleKey.Escape);

        }

        /// <summary>
        /// Заполнение массива данными о сотрудниках
        /// </summary>
        /// <param name="a">Исходный массив</param>
        static void Заполнить(ArrayList a)
        {
            char     var;   //Вид данных
            string   фамилия;
            int       возраст;
            double оклад;


            while (true)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("ВЫБЕРИТЕ ВИД ДАННЫХ");
                    Console.WriteLine("1. Фамилия");
                    Console.WriteLine("2. Возраст");
                    Console.WriteLine("3. Оклад");
                    Console.WriteLine("4. Завершение ввода данных");
                    var = Console.ReadKey(true).KeyChar;
                } while (var < '1' || var > '4');

                switch (var)
                {
                    case '1':
                        Console.Write("Фамилия: ");
                        фамилия = Console.ReadLine();
                        a.Add(фамилия);
                        break;
                    case '2':
                        Console.Write("Возраст: ");
                        возраст = int.Parse(Console.ReadLine());
                        a.Add(возраст);
                        break;
                    case '3':
                        Console.Write("Оклад: ");
                        оклад = double.Parse(Console.ReadLine());
                        a.Add(оклад);
                        break;
                    case '4': return;
                }
            }
        }

        /// <summary>
        /// Вывод всех фамилий
        /// </summary>
        /// <param name="a">Исходный массив</param>
        static void ВывестиФамилии(ArrayList a)
        {
            for (int i = 0; i < a.Count; i++)
                if (a[i].GetType().Name == "String")
                    Console.WriteLine(a[i]);
        }

        /// <summary>
        /// Вычисление минимального возраста
        /// </summary>
        /// <param name="a">Исходный массив</param>
        /// <returns>минимальный возраст</returns>
        static int ОпределитьВозраст(ArrayList a)
        {
            int min = int.MaxValue;
            int возраст=0;
            for (int i = 0; i < a.Count; i++)
                if (a[i].GetType().Name == "Int32")
                {
                    возраст = (int)a[i];
                    if (возраст < min) min = возраст;
                }
            return min;
        }

        
        /// <summary>
        /// Вычисление среднего оклада
        /// </summary>
        /// <param name="a">Исходный массив</param>
        /// <param name="среднийОклад">Средний оклад</param>
        /// <returns>Количество данных по окладу</returns>
        static int ОпределитьОклад(ArrayList a, out double среднийОклад)
        {
            int k = 0; //Количество данных по окладу
            double оклад = 0;
            среднийОклад = 0;
            for (int i = 0; i < a.Count; i++)
                if (a[i].GetType().Name == "Double")
                {
                    оклад = (double)a[i];
                    среднийОклад += оклад;
                    k++;
                }
            if(k>0) среднийОклад /= k;
            return k;
        }
    }
}
