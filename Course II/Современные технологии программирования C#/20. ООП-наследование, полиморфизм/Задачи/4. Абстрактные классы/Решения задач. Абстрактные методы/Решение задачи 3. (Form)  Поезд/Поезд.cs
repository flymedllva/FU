using System;
using System.Collections.Generic;
using System.Text;

namespace Поезда
{
    public class Поезд
    {
        private int     номер;
        private string  назначение;
        private Вагон[] вагоны;

        public Поезд(int номер, string назначение, Вагон[] вагоны)
        {
            this.номер = номер;
            this.назначение = назначение;
            this.вагоны = вагоны;
        }

        public int Номер
        {   get { return номер; }      set { номер = value; } }

        public string Назначение
        {   get { return назначение; } set { назначение = value; } }

        public Вагон[] Вагоны
        {   get { return вагоны; }     set { вагоны = value; } }


    }
    public abstract class Вагон
    {
        public abstract string ПараметрыВагона();
    }

    public class ГрузовойПоезд : Поезд
    {
        
        public ГрузовойПоезд(int номер, string назначение, ГрузовойВагон[] вагоны)
            : base(номер, назначение, вагоны)
        {  }
    }

    public class ПассажирскийПоезд : Поезд
    {
        public ПассажирскийПоезд(int номер, string назначение, ПассажирскийВагон[] вагоны)
            : base(номер, назначение, вагоны)
        {  }
    }

    public class ГрузовойВагон : Вагон
    {
        
        double МаксимальнаяНагрузка;
        double Загружено;
        public ГрузовойВагон(double Макс, double Загружено)
        {
            МаксимальнаяНагрузка = Макс;
            this.Загружено = Загружено;
        }
        public override string ПараметрыВагона()
        {
            return String.Format("Грузовой вагон, загрузка {0:F2}т из {1:F2}т", Загружено, МаксимальнаяНагрузка);
        }
    }

    public class ПассажирскийВагон : Вагон
    {
        public static int МаксимумМест = 180;
        int СвободноМест;
        public ПассажирскийВагон(int Свободно)
        {
            СвободноМест = Свободно;
        }
        public override string ПараметрыВагона()
        {
            return String.Format("Пассажирский вагон, занято {0} из {1} мест", СвободноМест, МаксимумМест);
        }
    }

}
