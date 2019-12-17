using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibrarySort; 


namespace СортировкаМассиваСтудентов
{
    //-----------------------------------------------------------------
    public class Студент
    {
        public string Фамилия { get; set; }
        public decimal Рейтинг { get; set; }

        public Студент(string name, decimal rat)
        {
            Фамилия = name;
            Рейтинг = rat;
        }
        //------------------------------------------------------------------
        public override string ToString()
        {
            return string.Format(Фамилия + "  " + Рейтинг);
        }

    }



    public class Program
    {
        static void Main(string[] args)
        {
            Студент[] студенты = {  new Студент ("Иванов", 80), 
                                    new Студент ("Петров", 75), 
                                    new Студент ("Костин", 95), 
                                    new Студент ("Маркин", 68), 
                                    new Студент ("Митина", 78), 
                                };

            Console.WriteLine("Исходный список студентов:");
            foreach (Студент std in студенты)
                 Console.WriteLine(std);


            Console.WriteLine("\n----Сортируем по возрастанию фамилий:");

            SortFam srtF = new SortFam();

            Sort.BubbleSort(студенты, srtF);

            Console.WriteLine();
            foreach (Студент std in студенты)
                Console.WriteLine(std);



           Console.WriteLine("\n----Сортируем по убыванию рейтингов:");

            SortRating srtR = new SortRating();

            Sort.BubbleSort(студенты, srtR);

            foreach (Студент std in студенты)
                Console.WriteLine(std);


        }
    }
}
