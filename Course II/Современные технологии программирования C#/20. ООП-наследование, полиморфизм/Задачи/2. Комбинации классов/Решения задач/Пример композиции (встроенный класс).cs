// Рассматривается встоенный класс Строка. 
// Для его использования необходимо указывать класс-оболочку.
// В остальном работа с внутренним классом строится так же, 
// как будто этот класс является самостоятельным.

using System;
using System.Collections.Generic;
using System.Text;

namespace Композиция_Класс
{
    class Таблица
    {
        private string ИмяСтолбца1   {get; set;}
        private string ИмяСтолбца2   { get; set; }
        private string ИмяСтолбца3   { get; set; }
        private string ЦветЗаголовка { get; set; }


        public Таблица(string c1, string c2, string c3, string c)
        {
            ИмяСтолбца1 = c1;
            ИмяСтолбца2 = c2;
            ИмяСтолбца3 = c3;
            ЦветЗаголовка = c;

        }

        public Строка GetRow(int v1, int v2, int v3)
        {
            Таблица.Строка row = new Таблица.Строка();
            row.ЗначениеСтолбца1 = v1;
            row.ЗначениеСтолбца2 = v2;
            row.ЗначениеСтолбца3 = v3;
            return row;
        }

        public class Строка
        {
            public int ЗначениеСтолбца1 { get; set; }
            public int ЗначениеСтолбца2 { get; set; }
            public int ЗначениеСтолбца3 { get; set; }

            public Строка()
            {    }

            public Строка(int v1, int v2, int v3)
            {
                ЗначениеСтолбца1 = v1;
                ЗначениеСтолбца2 = v2;
                ЗначениеСтолбца3 = v3;
            }
        }
 }

  

   
    class Program
    {
        static void Main(string[] args)
        {
            Таблица tabl = new Таблица("Заголовок1", "Заголовок2", "Заголовок3", "Белый");
            Таблица.Строка row1 = new Таблица.Строка(1, 2, 3);
            Таблица.Строка row2 = tabl.GetRow(4, 5, 6);
        }
    }
}
