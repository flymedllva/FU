using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace СтатическоеПолеТолькоЧтение
{
    class Студент
    {
        public string фамилия;
        public uint рейтинг;
        public static readonly string группа="1ПИ1";

        public Студент(string фамилия, uint рейтинг)
        {
            this.фамилия = фамилия;
            this.рейтинг = рейтинг;
        }

        public string ВыдатьДанные()
        {
            return фамилия + "  " + рейтинг + "  " + группа;
        }
    }
    class СтатическоеЧтение
    {
        static void Main(string[] args)
        {
            Студент ст = new Студент("Иванов", 85);
            Console.WriteLine(ст.ВыдатьДанные());
            Console.WriteLine(ст.фамилия + "  " + ст.рейтинг + "  " + Студент.группа);

            ст.фамилия = "Козлов";
            ст.рейтинг = 15;
            //Студент.группа = "2МЭ1";
            Console.WriteLine(ст.ВыдатьДанные());
        }
    }
}
