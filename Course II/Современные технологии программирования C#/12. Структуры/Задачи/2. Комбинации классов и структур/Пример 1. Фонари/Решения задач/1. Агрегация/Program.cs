using System;
using System.Collections.Generic;
using System.Text;

namespace Агрегация
{
    class Корпус
    {
        private string тип;
        private double цена;

        public string Тип
        {
            set { тип = value; }
            get { return тип; }
        }
        public double Цена
        {
            set { цена = value; }
            get { return цена; }
        }
    }

    class Лампочка
    {
        private double мощность;
        private double цена;

        public double Мощность
        {
            set { мощность = value; }
            get { return мощность; }
        }
        public double Цена
        {
            set { цена = value; }
            get { return цена; }
        }
    }
    class Фонарь
    { 
        private Корпус кор;
        private Лампочка лам;
        private string состояние;

        public Фонарь(Корпус кор, Лампочка лам, string состояние)
        {
            this.кор = кор; this.лам = лам; this.состояние = состояние;
        }
        public string Состояние
        {
            set { состояние = value; }
        }
        public void Показать()
        {
            Console.WriteLine("{0,-10}{1,-10}{2,10:f2}{3,10:f2}{4,10:f2}",
                     состояние,кор.Тип,кор.Цена,лам.Цена, лам.Мощность);
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
