using System;

namespace Инкапсуляция
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

        public Студент(string фамилия,uint рейтинг)
        {
            this.фамилия = фамилия;
            this.рейтинг = рейтинг;
        }
       
        public string ВыдатьДанные()
        {
            return фамилия + "  " + рейтинг;
        }
    }
    class Свойства
    {
        static void Main(string[] args)
        {
            Студент ст = new Студент("Иванов",85);
            Console.WriteLine(ст.ВыдатьДанные());
            //ст.фамилия = "Козлов";
            //ст.рейтинг = ст.рейтинг + 10;
            ст.Фамилия = "Козлов";
            ст.Рейтинг = ст.Рейтинг + 10;
            Console.WriteLine(ст.ВыдатьДанные());
        }
    }
}
