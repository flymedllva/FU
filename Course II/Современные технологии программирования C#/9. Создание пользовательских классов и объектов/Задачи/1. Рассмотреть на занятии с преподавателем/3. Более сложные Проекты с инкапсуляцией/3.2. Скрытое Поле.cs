using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ВиртуальноеПоле
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
            set { рейтинг = value; }
        }

        public double Рейтинг10
        {
            get { return Math.Round((double)рейтинг/10.0, 1); }
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
    class Поле
    {
        static void Main(string[] args)
        {
            Студент ст = new Студент("Иванов", 85);
            Console.Write(ст.ВыдатьДанные());
            Console.WriteLine("  "  + ст.Рейтинг10);
        }
    }
}
