using System;
using System.Collections.Generic;
using System.Text;

namespace Учет
{
    class Студент
    {
        private string фамилия;
        private uint рейтинг;
        private static string группа;

        public Студент(string фам, uint рейт, string гр)
        {
            фамилия = фам;
            рейтинг = рейт;
            группа = гр;
        }

        public Студент(string фам)
        {
            фамилия = фам;
            рейтинг = 50;
            группа = "1ПИ1";

        }
      
        public string ВыдатьДанные()
        {
            return фамилия + " " + рейтинг + " " + группа;
        }

        public static string ВыдатьГруппу()
        {
            return группа;
        }
    }
}
