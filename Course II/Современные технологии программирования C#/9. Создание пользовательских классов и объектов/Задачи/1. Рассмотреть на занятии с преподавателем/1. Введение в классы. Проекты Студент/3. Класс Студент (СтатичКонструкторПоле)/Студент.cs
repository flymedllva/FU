using System;
using System.Collections.Generic;
using System.Text;

namespace Учет
{
    class Студент
    {
        private string фамилия;
        private uint рейтинг;

        private static string группа;   // !!!!!!!!




        //------- Статический конструктор --------
        static Студент()
        {
            группа = "1ПИ1";
        }


        //------- Статический метод --------------
        public static string ВыдатьГруппу()
        {
            return группа;
        }


        //------- Конструктор 1 --------------------
        public Студент(string фамилия, uint рейтинг)
        {
            this.фамилия = фамилия;
            this.рейтинг = рейтинг;
        }


        //------- Конструктор 2 --------------------
        public Студент(string фамилия)
        {
            this.фамилия = фамилия;
            рейтинг = 50;
        }


        //------------------------------------------
        public string ВыдатьДанные()
        {
            return фамилия + " " + рейтинг + " " + группа;
        }
    }
}
