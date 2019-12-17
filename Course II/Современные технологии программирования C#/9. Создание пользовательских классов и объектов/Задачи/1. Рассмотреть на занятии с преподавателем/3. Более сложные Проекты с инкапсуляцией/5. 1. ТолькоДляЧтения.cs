using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ПолеТолькоЧтение
{
    class Студент
    {
        public string фамилия;
        public uint рейтинг;
        public readonly string группа;
        
        public Студент(string фамилия, uint рейтинг, string группа)
        {
            this.фамилия = фамилия;
            this.рейтинг = рейтинг;
            this.группа = группа;
        }
        public string ВыдатьДанные()
        {
            return фамилия + "  " + рейтинг + "  " + группа;
        }
    }
    class Чтение
    {
        static void Main(string[] args)
        {
            Студент ст = new Студент("Иванов", 85, "1ПИ1");
            Console.WriteLine(ст.ВыдатьДанные());
            Console.WriteLine(ст.фамилия + "  " + ст.рейтинг+ "  " +ст.группа );

            ст.фамилия = "Козлов";
            ст.рейтинг = 15;
            //ст.группа = "2МЭ1";
            Console.WriteLine(ст.ВыдатьДанные());
        }
    }
}
