using System;
using System.Collections.Generic;
using System.Text;

namespace Учет
{
    class Студент
    {
        public string фамилия;
        public uint рейтинг;
        public static string группа;
    
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
