using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Расписание_занятий
{
    enum Дисциплины {Программирование, Математика, Физкультура}
    [Flags]
    enum Дни {НЕТ=0, понедельник=1, вторник=2, среда=4, четверг=8, пятница=16, суббота=32 }
   
    class Расписание
    {
        public string     group;
        public Дисциплины предмет;
        public Дни        дниЗанятий;

        public Расписание(string g, Дисциплины п, Дни д)
        {
            group      = g;
            предмет    = п;
            дниЗанятий = д;
        }
    }
}
