using System;
using System.Collections.Generic;
using System.Text;

namespace Композиция_Класс
{
    class Фонарь
    {
        private Корпус кор;
        private Лампочка лам;
        private string состояние;

        
        public Фонарь(string тип, double ценаК, double мощность, double ценаЛ, string состояние)
        {             
            кор = new Корпус(тип, ценаК); 
            лам = new Лампочка(мощность, ценаЛ);
            this.состояние = состояние;
        }

        public string Состояние
        {
            set { состояние = value; }
        }

        ///////////////////////////////////////////////////////
        public class Корпус
        {
            private string тип;
            private double цена;

            public Корпус(string тип, double цена)
            {
                this.тип = тип;
                this.цена = цена;
            }


            public  string Тип
            {
                //set { тип = value; }
                get { return тип; }
            }
            public double Цена
            {
                //set { цена = value; }
                get { return цена; }
            }
        }
        ///////////////////////////////////////////////////////
        public class Лампочка
        {
            private double мощность;
            private double цена;


            public Лампочка(double мощность, double цена)
            {
                this.мощность = мощность;
                this.цена = цена;
            }
            public double Мощность
            {
                //set { мощность = value; }
                get { return мощность; }
            }
            public double Цена
            {
                //set { цена = value; }
                get { return цена; }
            }
        }



        public void Показать()
        {
            Console.WriteLine("{0,-10}{1,-10}{2,10:f2}{3,10:f2}{4,10:f2}",
                     состояние, кор.Тип, кор.Цена, лам.Цена, лам.Мощность);
        }
    }

   //-----------------------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            Фонарь ф = new Фонарь("Тюльпан", 800.0, 60.0, 30.0, "Выключено");

            ф.Показать();
            ф.Состояние = "Включено";
            ф.Показать();


            Фонарь.Корпус корп = new Фонарь.Корпус("Гидра", 1000.0);
            Console.WriteLine("Цена корпуса=" + корп.Цена);

            Фонарь.Лампочка лампа = new Фонарь.Лампочка(20.0, 150.0);
            Console.WriteLine("Мощьность лампочки=" + лампа.Мощность);

        }
    }
}
