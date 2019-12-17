using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace СкрытиеРеализации
{
    class Студент
    {
        private string фамилия;
        private uint рейтинг;

        private static string ШифроватьСтроку(string s)
        {
            string kod = "";
            for (int i = 0; i < s.Length; i++)
                kod = kod + (char)(s[i] + 1);
            return kod;
        }

        private static string РасшифроватьСтроку(string s)
        {
            string kod = "";
            for (int i = 0; i < s.Length; i++)
                kod = kod + (char)(s[i] - 1);
            return kod;
        }

        private static uint ШифроватьЧисло(uint a)
        {
            return a + 50;
        }

        private static uint РасшифроватьЧисло(uint a)
        {
            return a - 50;
        }

        public Студент(string фамилия, uint рейтинг)
        {
            this.фамилия = ШифроватьСтроку(фамилия);
            this.рейтинг = ШифроватьЧисло(рейтинг);
        }

        public string Фамилия
        {
            get { return РасшифроватьСтроку(фамилия); }
            set { фамилия = ШифроватьСтроку(value); }
        }

        public uint Рейтинг
        {
            get { return РасшифроватьЧисло(рейтинг); }
            set { рейтинг = ШифроватьЧисло(value); }
        }

        public string ВыдатьДанные()
        {
            return РасшифроватьСтроку(фамилия) + "  " + РасшифроватьЧисло(рейтинг);
        }
    }
    class Скрытие
    {
        static void Main(string[] args)
        {
            Студент ст = new Студент("Иванов", 85);
            Console.WriteLine(ст.Фамилия + "  " + ст.Рейтинг);
            Console.WriteLine(ст.ВыдатьДанные());

            ст.Фамилия = "Козлов";
            ст.Рейтинг = 15;
            Console.WriteLine(ст.ВыдатьДанные());
        }
    }
}
