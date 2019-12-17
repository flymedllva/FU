using System;
using System.Collections.Generic;
using System.Text;

namespace Композиция_Класс
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

        // Конструктор копирования
        public Фонарь(Корпус кор, Лампочка лам, string состояние)
        {
            this.кор = new Корпус(); 
            this.кор.Тип = кор.Тип;
            this.кор.Цена = кор.Цена;
            this.лам = new Лампочка();
            this.лам.Мощность = лам.Мощность;
            this.лам.Цена = лам.Цена;
            this.состояние = состояние;
        }
        public Фонарь()
        {
            this.кор = new Корпус();
            this.кор.Тип = "Ракета";
            this.кор.Цена = 777.0;
            this.лам = new Лампочка();
            this.лам.Мощность = 250.0;
            this.лам.Цена = 80.0;
        }

        public string Состояние
        {
            set { состояние = value; }
        }
        public void Показать()
        {
            Console.WriteLine("{0,-10}{1,-10}{2,10:f2}{3,10:f2}{4,10:f2}",
                     состояние, кор.Тип, кор.Цена, лам.Цена, лам.Мощность);
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            Корпус к;
            Лампочка л;
            Фонарь ф;

            к = new Корпус();
            к.Тип = "Тюльпан"; к.Цена = 800.0;

            л = new Лампочка();
            л.Мощность = 60.0; л.Цена = 30.0;

            ф = new Фонарь(к, л,"Выключено");
            ф.Состояние = "Включено";
            ф.Показать();
            ф.Состояние = "Выключено";

            л.Мощность = 100.0; л.Цена = 40.0;

            ф.Показать();

            ф = new Фонарь(к, л,"Выключено");
            ф.Состояние = "Включено";
            ф.Показать();
            ф = new Фонарь();
            ф.Состояние = "Включено";
            ф.Показать();
        }
    }
}
