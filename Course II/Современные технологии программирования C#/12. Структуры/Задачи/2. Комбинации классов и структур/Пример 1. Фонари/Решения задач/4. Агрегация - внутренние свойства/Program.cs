using System;
using System.Collections.Generic;
using System.Text;

namespace Агрегация
{
    class Корпус
    {
        public string Тип { set; get; }
        public double Цена { set; get; }
    }

    class Лампочка
    {
        public double Мощность { set; get; }
        public double Цена     { set; get; }
    }

    class Фонарь
    { 
        private Корпус кор;
        private Лампочка лам;
        public string Состояние  { set; get; }

        public Фонарь(Корпус корп, Лампочка ламп, string сост)
        {
            кор = корп; лам = ламп; Состояние = сост;
        }
  
   
        public void Показать()
        {
            Console.WriteLine("{0,-10}{1,-10}{2,10:f2}{3,10:f2}{4,10:f2}",
                     Состояние, кор.Тип, кор.Цена, лам.Цена, лам.Мощность);
        }
    }
    
   

    class Program
    {
        static void Main(string[] args)
        {
            Корпус к = new Корпус();
            к.Тип = "Тюльпан";  к.Цена = 800.0;
            
            Лампочка л = new Лампочка();
            л.Мощность = 60.0;  л.Цена = 30.0;


            Фонарь ф = new Фонарь(к, л, "Выключено");
            ф.Состояние = "Включено";
            ф.Показать();

            ф.Состояние = "Выключено";

            л.Мощность = 100.0; л.Цена = 40.0;
            ф.Показать();
        }
    }
}
