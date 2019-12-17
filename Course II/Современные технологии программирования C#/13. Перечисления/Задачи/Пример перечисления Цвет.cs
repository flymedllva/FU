using System;
using System.Collections.Generic;
using System.Text;

namespace Перечисление1
{
    //enum Цвет { Красный, Желтый, Зеленый }
    //enum Цвет { Красный=1, Желтый, Зеленый }
    enum Цвет { Красный = 1, Желтый, Зеленый=5 }
    class Светофор
    {
        public Цвет цвет;

        public Светофор(Цвет цвет) 
        {this.цвет = цвет;}
       
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            int ном;
            Светофор св = new Светофор(Цвет.Красный);
            ном = (int)св.цвет;
            Console.WriteLine(ном);

            св.цвет = Цвет.Желтый;
            ном = (int)св.цвет;
            Console.WriteLine(ном);

            св.цвет = Цвет.Зеленый;
            ном = (int)св.цвет;
            Console.WriteLine(ном);

            //св.цвет = Цвет.Синий;
            //св.цвет = 100;
            св.цвет = (Цвет)100;
            ном = (int)св.цвет;
            Console.WriteLine(ном);
        }
    }
}
