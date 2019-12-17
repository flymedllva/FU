using System;

namespace ЛокализацияИзменений
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

        public Студент(string фам, uint рт)
        {
            фамилия = ШифроватьСтроку(фам);
            рейтинг = ШифроватьЧисло(рт); 
        }

        public string ВыдатьФамилию()
        {
            return РасшифроватьСтроку(фамилия);
        }

        public void НазначитьФамилию(string фам)
        {
            фамилия = ШифроватьСтроку(фам);
        }

        public uint ВыдатьРейтинг()
        {
            return РасшифроватьЧисло(рейтинг);
        }

        public void НазначитьРейтинг(uint рт)
        {
            рейтинг = ШифроватьЧисло(рт);
        }
    }

    class Локализация
    {
        static void Main(string[] args)
        {
            Студент ст = new Студент("Иванов", 85);
            //Console.WriteLine(ст.фамилия + "  " + ст.рейтинг);
            Console.WriteLine(ст.ВыдатьФамилию() + " " + ст.ВыдатьРейтинг());

            //ст.фамилия = "Козлов"; 
            //ст.рейтинг = 15;
            ст.НазначитьФамилию("Козлов");
            ст.НазначитьРейтинг(15);
            Console.WriteLine(ст.ВыдатьФамилию() + " " + ст.ВыдатьРейтинг());
        }
    }
}
