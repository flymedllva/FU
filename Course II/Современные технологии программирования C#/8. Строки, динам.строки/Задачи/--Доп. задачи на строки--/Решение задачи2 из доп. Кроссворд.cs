/*
 * Задача 2. 	В двух введенных с клавиатуры словах найти первые два одинаковых символа (начать с первой строки) и вывести на экран фрагмент кроссворда: первое слово по горизонтали, а второе  по вертикали с пересечением на найденном общем символе. Например, пусть введены слова: 
    экономика        бизнес 

	Результат:	б	
				и
				з
			 экономика
				е
				с

 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Кдз_з2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string      a,  //первое слово
                        b;  //второе слово

            int         i,
                        j,
                        index1,
                        index2;

            ConsoleKeyInfo repeat;

            do
            {
                Console.Write("Введите первое слово: ");
                a = Console.ReadLine();

                Console.Write("Введите второе слово: ");
                b = Console.ReadLine();

                index1 = -10;
                index2 = -10;

                //поиск общего символа и запоминание 
                //его индекса в первом и втором слове

                for (i = 0; i < a.Length; i++)
                {
                    for (j = 0; j < b.Length; j++)
                        if (a[i] == b[j])
                        {
                            index1 = i;
                            index2 = j;
                            break;
                        }
                    if (index1 > 0)
                        break;
                }

                char [,] s=new char [b.Length, a.Length];       //создание массива из символов

                if (index1 < 0)
                {
                    Console.WriteLine("Общих букв нет");
                }
                else
                {
                    //заполнение массива

                    for (i = 0; i < b.Length; i++)
                        for (j = 0; j < a.Length; j++)
                        {
                            if (j == index1)
                                s[i, j] = b[i];
                            else
                                s[i, j] = ' ';

                            if (i == index2)
                                s[i, j] = a[j];
                        }

                    //вывод фрагмента кроссворда

                    for (i = 0; i < b.Length; i++, Console.WriteLine())
                        for (j = 0; j < a.Length; j++)
                            Console.Write(s[i, j]);
                }

                Console.WriteLine("Для продолжения нажмите Enter");
                repeat = Console.ReadKey(true);

            }while (repeat.Key == ConsoleKey.Enter);
        }
    }
}
