using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Контроль
{
    class Студент
    {
        private string фамилия;
        private uint рейтинг;

        public string Фамилия
        {
            get { return фамилия; }
            set { фамилия = value; }
        }

        public uint Рейтинг
        {
            get { return рейтинг; }
            set {
                     if (value >= 0 && value <= 100)
                         рейтинг = value;
                     else
                         Console.WriteLine("Недопустимое значение рейтинга");
                  }
        }

        public Студент(string фамилия, uint рейтинг)
        {
            this.фамилия = фамилия;
            this.рейтинг = рейтинг;
        }

        public string ВыдатьДанные()
        {
            return фамилия + "  " + рейтинг;
        }
    }


    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    class Проверка
    {
        static void Main(string[] args)
        {
            Студент ст = new Студент("Иванов", 85);
            ст.Рейтинг = ст.Рейтинг + 30;
            Console.WriteLine(ст.ВыдатьДанные());
        }
    }
}
