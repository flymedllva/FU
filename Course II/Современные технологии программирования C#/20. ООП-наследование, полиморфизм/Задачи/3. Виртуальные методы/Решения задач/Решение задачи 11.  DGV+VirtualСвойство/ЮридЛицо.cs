using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DGV_VirtualMethod
{
    class ЮридЛицо : Клиент
    {
        public string названиеОрганизации;

        public ЮридЛицо(string _названиеОрганизации, string _условия, int _размерКредита, int _срокКредита) :
            base(_условия, _размерКредита, _срокКредита)
        {
            названиеОрганизации = _названиеОрганизации;
        }

        public ЮридЛицо() :
            base()
        {
        }


        public override string Атрибуты
        {
            get { return названиеОрганизации; }
            set { названиеОрганизации = value; }
        }

        public string НазваниеОрганизации
        {
            get { return названиеОрганизации; }
            set { названиеОрганизации = value; }
        }

    }
}
