using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Задачка
{
    class Компьютер
    {
        private string номер;
        private string тип;
        private string процессор;

        public Компьютер(string x, string y, string z)
        {
            номер = x;
            тип = y;
            процессор = z;
        }

        public string Номер { get { return номер; } }
        public string Тип { get { return тип; } }
        public string Процессор { get { return процессор; } }
    }

    class Владелец
    {
        private string фамилия;
        private string имя;

        public Владелец(string x, string y)
        {
            фамилия = x;
            имя = y;
        }

        public string Фамилия { get { return фамилия; } }
        public string Имя { get { return имя; } }
    }

    class Описание
    {
        private string место;
        private Компьютер ком;
        private Владелец влад;

        public Описание(string x, Компьютер y, Владелец z)
        {
            место = x;
            ком = y;
            влад = z;
        }

        public string Место { get { return место; } }
        public Компьютер Сер_Номер { get { return ком; } }
        public Владелец Хозяин { get { return влад; } }
    }

    class Запрос
    {
        public static void Таблица(ArrayList таб)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < таб.Count; i++)
                Console.WriteLine("{0,-5}{1,-15}{2,-15}{3,-10}{4,8}{5,15}",
                                   ((Описание)таб[i]).Место,
                                   ((Описание)таб[i]).Хозяин.Фамилия,
                                   ((Описание)таб[i]).Хозяин.Имя,
                                   ((Описание)таб[i]).Сер_Номер.Тип,
                                   ((Описание)таб[i]).Сер_Номер.Номер,
                                   ((Описание)таб[i]).Сер_Номер.Процессор);

            Console.WriteLine();
        }

        public static void Владельцы(ArrayList таб)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < таб.Count; i++)
                Console.WriteLine("{0,-15}{1, -5}", ((Описание)таб[i]).Хозяин.Фамилия, ((Описание)таб[i]).Хозяин.Имя);

            Console.WriteLine();
        }

        public static void Номера(ArrayList таб)
        {
            for (int i = 0; i < таб.Count; i++)
                Console.WriteLine("{0,-5}", ((Описание)таб[i]).Сер_Номер.Номер);

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList таб = new ArrayList();
            Описание оп;
            Компьютер ком;
            Владелец влад;

            ком = new Компьютер("JF234V", "Ноутбук", "Pentium 4");
            влад = new Владелец("Бердников", "Антон");
            оп = new Описание((таб.Count + 1).ToString(), ком, влад);
            таб.Add(оп);

            ком = new Компьютер("93NFN3", "Настольный", "Pentium 3");
            влад = new Владелец("Хвостов", "Илья");
            оп = new Описание((таб.Count + 1).ToString(), ком, влад);
            таб.Add(оп);

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n", "F1 - Добавить новый компьютер",
                                                          "F2 - Вывести информацию по всем компьютерам",
                                                          "F3 - Вывести всех владельцев компьютеров",
                                                          "F4 - Вывести серийные номера компьютеров",
                                                          "F5 - Поиск по заданному параметру");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.F1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        ком = new Компьютер(Характеристика(1), Характеристика(2), Характеристика(3));
                        влад = new Владелец(Владельцы(1), Владельцы(2));
                        оп = new Описание((таб.Count + 1).ToString(), ком, влад);
                        таб.Add(оп);
                        break;
                    case ConsoleKey.F2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Запрос.Таблица(таб);
                        break;
                    case ConsoleKey.F3:
                        Console.WriteLine("Владельцы компьютеров:");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Запрос.Владельцы(таб);
                        break;
                    case ConsoleKey.F4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Серийные номера компьютеров:");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Запрос.Номера(таб);
                        break;
                    case ConsoleKey.F5:
                        Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}", "1 - Поиск по порядковому номеру",
                                                                     "2 - Поиск по данным владельца",
                                                                     "3 - Поиск по типу компьютера",
                                                                     "4 - Поиск по серийному номеру компьютера",
                                                                     "5 - Поиск по характеристике компьютера");

                        Console.WriteLine();

                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                                string q = "";
                                bool f = false;

                                Console.Write("Введите порядковый номер: ");
                                q = Console.ReadLine();

                                for (int i = 0; i < таб.Count; i++)
                                {
                                    if (q == ((Описание)таб[i]).Место)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n{0,-5}{1,-15}{2,-15}{3,-10}{4,8}{5,15}", ((Описание)таб[i]).Место,
                                                                                                    ((Описание)таб[i]).Хозяин.Фамилия,
                                                                                                    ((Описание)таб[i]).Хозяин.Имя,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Тип,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Номер,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Процессор);
                                        f = true;
                                        break;
                                    }
                                }

                                if (!f)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nПоиск не дал результатов!");
                                }
                                break;
                            case ConsoleKey.D2:
                                f = false;
                                string str;

                                Console.Write("Введите данные владельца: ");
                                str = Console.ReadLine();

                                for (int i = 0; i < таб.Count; i++)
                                {
                                    string raz = " ,";
                                    string[] str1 = null;
                                    char[] razd = raz.ToCharArray();

                                    str1 = str.Split(razd);

                                    foreach (string s in str1)
                                    {
                                        if (s == ((Описание)таб[i]).Хозяин.Фамилия || s == ((Описание)таб[i]).Хозяин.Имя)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("\n{0,-5}{1,-15}{2,-15}{3,-10}{4,8}{5,15}", ((Описание)таб[i]).Место,
                                                                                                    ((Описание)таб[i]).Хозяин.Фамилия,
                                                                                                    ((Описание)таб[i]).Хозяин.Имя,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Тип,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Номер,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Процессор);
                                            f = true;
                                        }
                                    }
                                }

                                if (!f)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nПоиск не дал результатов!");
                                }
                                break;

                            case ConsoleKey.D3:
                                f = false;

                                Console.Write("Введите тип компьютера: ");
                                str = Console.ReadLine();

                                for (int i = 0; i < таб.Count; i++)
                                {
                                    if (str == ((Описание)таб[i]).Сер_Номер.Тип)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n{0,-5}{1,-15}{2,-15}{3,-10}{4,8}{5,15}", ((Описание)таб[i]).Место,
                                                                                                    ((Описание)таб[i]).Хозяин.Фамилия,
                                                                                                    ((Описание)таб[i]).Хозяин.Имя,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Тип,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Номер,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Процессор);
                                        f = true;
                                    }
                                }

                                if (!f)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nПоиск не дал результатов!");
                                }
                                break;

                            case ConsoleKey.D4:
                                f = false;

                                Console.Write("Введите тип компьютера: ");
                                str = Console.ReadLine();

                                for (int i = 0; i < таб.Count; i++)
                                {
                                    if (str == ((Описание)таб[i]).Сер_Номер.Номер)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n{0,-5}{1,-15}{2,-15}{3,-10}{4,8}{5,15}", ((Описание)таб[i]).Место,
                                                                                                    ((Описание)таб[i]).Хозяин.Фамилия,
                                                                                                    ((Описание)таб[i]).Хозяин.Имя,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Тип,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Номер,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Процессор);
                                        f = true;
                                    }
                                }

                                if (!f)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nПоиск не дал результатов!");
                                }
                                break;

                            case ConsoleKey.D5:
                                f = false;

                                Console.Write("Введите характеристику компьютера: ");
                                str = Console.ReadLine();

                                for (int i = 0; i < таб.Count; i++)
                                {
                                    if (str == ((Описание)таб[i]).Сер_Номер.Процессор)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n{0,-5}{1,-15}{2,-15}{3,-10}{4,8}{5,15}", ((Описание)таб[i]).Место,
                                                                                                    ((Описание)таб[i]).Хозяин.Фамилия,
                                                                                                    ((Описание)таб[i]).Хозяин.Имя,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Тип,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Номер,
                                                                                                    ((Описание)таб[i]).Сер_Номер.Процессор);
                                        f = true;
                                    }
                                }

                                if (!f)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nПоиск не дал результатов!");
                                }
                                break;
                        }
                        break;
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Для выхода нажмите ESC...\nДля продолжения нажмите любую клавишу...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static string Характеристика(int x)
        {
            string s = "";

            switch (x)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Введите серийный номер компьютера: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    s = Console.ReadLine();
                    s.ToUpper();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Введите тип компьютера: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    s = Console.ReadLine();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Введите процессор: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    s = Console.ReadLine();
                    break;
            }

            return s;
        }

        static string Владельцы(int x)
        {
            string s = "";

            switch (x)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Введите фамилию владельца: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    s = Console.ReadLine();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Введите имя владельца: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    s = Console.ReadLine();
                    break;
            }

            return s;
        }
    }
}
