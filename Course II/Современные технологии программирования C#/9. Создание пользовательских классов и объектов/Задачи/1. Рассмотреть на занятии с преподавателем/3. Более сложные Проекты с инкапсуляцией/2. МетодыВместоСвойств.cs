using System;

namespace ИнтерфейсныеМетоды
{
    class Студент
    {
        private string фамилия;
        private uint рейтинг;
               
        public Студент(string фам, uint рт)
        {
            фамилия = фам;
            рейтинг = рт;
        }

        public string ВыдатьФамилию()
        {
            return фамилия;
        }

        public void НазначитьФамилию(string фам)
        {
            фамилия = фам;
        }

        public uint ВыдатьРейтинг()
        {
            return рейтинг;
        }

        public void НазначитьРейтинг(uint рт)
        {
            рейтинг = рт;
        }
    }

    class МетодыДоступа
    {
        static void Main(string[] args)
        {
            Студент ст = new Студент("Иванов", 85);
            //Console.WriteLine(ст.фамилия + "  " + ст.рейтинг);
            Console.WriteLine(ст.ВыдатьФамилию() + " " + ст.ВыдатьРейтинг());

            //ст.фамилия = "Козлов";    ст.рейтинг = 15;
            ст.НазначитьФамилию("Козлов");
            ст.НазначитьРейтинг(15);
            Console.WriteLine(ст.ВыдатьФамилию() + " " + ст.ВыдатьРейтинг());
        }
    }
}
