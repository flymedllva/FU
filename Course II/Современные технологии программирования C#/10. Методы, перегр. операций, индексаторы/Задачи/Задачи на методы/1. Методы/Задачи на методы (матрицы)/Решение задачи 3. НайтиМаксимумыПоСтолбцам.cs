using System;
class Operator
{
    public static void Main()
    {
        int n,              //Количество строк
               nd;          //Номер диагонали (совпадает с номером строки)
        int[,] a;           //Ссылка на формируемую матрицу
        int[] max;            //Ссылка на массив сумм
        int i,              //Номер строки
               j;	        //Номер столбца
        string rep;         //Признак повторного выполнения
        string str;         //Строка для вывода и ввода данных
        ConsoleColor color;

        //Random ran = new Random(); //Объект - генератор чисел

        do
        {
            Console.Write("Число строк:  ");
            n = int.Parse(Console.ReadLine());

            a = new int[n, n];
            max = new int[n];

            СоздатьМатрицаДСЧ(a, 10, 20);

            // Вывод матрицы
            for (i = 0; i < n; i++, Console.WriteLine())
                for (j = 0; j < n; j++)
                    Console.Write("{0,4}", a[i, j]);



            //Вычисление сумм подстрок от диагонали вправо
            for (j = 0; j < n; j++)
                for (max[j] = a[0, j], i = 0; i < n; i++)
                    if (max[j] < a[i, j])
                        max[j] = a[i, j];




            // Вывод результата
            Console.WriteLine("\n\n---Найденные максимумы столбцов---");
            for (i = 0; i < n; i++)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0,4}", max[i]);
            }

            Console.Write("\nДля повтора вычислений намите клавишу Y: ");
            rep = Console.ReadLine();
            Console.WriteLine();
        } while (rep == "Y" || rep == "y");
    } //Конец определения метода

    //--------------------------------------------------------
    // Инициализация матрицы
    private static void СоздатьМатрицаДСЧ(int[,] a)
    {
        Random ran = new Random(); //Объект - генератор чисел
        for (int i = 0; i < a.GetLength(0); i++)
            for (int j = 0; j < a.GetLength(1); j++)
                a[i, j] = ran.Next(0, 10 + 1);
    }


    //--------------------------------------------------------
    // Инициализация матрицы
    private static void СоздатьМатрицаДСЧ(int[,] a, int d1, int d2)
    {
        Random ran = new Random(); //Объект - генератор чисел
        for (int i = 0; i < a.GetLength(0); i++)
            for (int j = 0; j < a.GetLength(1); j++)
                a[i, j] = ran.Next(d1, d2 + 1);
    }
} //Конец объявления класса


