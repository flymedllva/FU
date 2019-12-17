using System;
using System.Collections.Generic;
using System.Text;

namespace Склады
{
    public class Склад
    {
        private string фирма;
        private int лицензия;
        private Товар[] товары;

        public Склад(string фирма, int лицензия, Товар[] товары)
        {
            this.фирма = фирма;
            this.лицензия = лицензия;
            this.товары = товары;
        }

        public int Лицензия
        { get { return лицензия; } set { лицензия = value; } }

        public string Фирма
        { get { return фирма; } set { фирма = value; } }

        public Товар[] Товары
        { get { return товары; } set { товары = value; } }


    }
    public abstract class Товар
    {
        public abstract string ПараметрыТовара();
    }

    public class УниверСклад : Склад
    {

        public УниверСклад(int номер, string назначение, ТоварУниСклада[] вагоны)
            : base(номер, назначение, вагоны)
        { }
    }

    public class СпецСклад : Склад
    {
        public СпецСклад(int номер, string назначение, ТоварСпецСклада[] вагоны)
            : base(номер, назначение, вагоны)
        { }
    }

    public class ТоварУниСклада : Товар
    {

        double МаксимальнаяНагрузка;
        double Загружено;
        public ТоварУниСклада(double Макс, double Загружено)
        {
            МаксимальнаяНагрузка = Макс;
            this.Загружено = Загружено;
        }
        public override string ПараметрыТовара()
        {
            return String.Format("Грузовой вагон, загрузка {0:F2}т из {1:F2}т", Загружено, МаксимальнаяНагрузка);
        }
    }

    public class ТоварСпецСклада : Товар
    {
        public static int МаксимумМест = 180;
        int СвободноМест;
        public ТоварСпецСклада(int Свободно)
        {
            СвободноМест = Свободно;
        }
        public override string ПараметрыТовара()
        {
            return String.Format("Пассажирский вагон, занято {0} из {1} мест", СвободноМест, МаксимумМест);
        }
    }
}
