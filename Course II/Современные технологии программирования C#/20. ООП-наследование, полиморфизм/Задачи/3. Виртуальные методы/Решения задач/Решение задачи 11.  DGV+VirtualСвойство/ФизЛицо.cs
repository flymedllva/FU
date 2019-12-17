using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DGV_VirtualMethod
{
    class ФизЛицо : Клиент
    {
        public string фамилия;

        public ФизЛицо(string _фамилия, string _условия, int _размерКредита, int _срокКредита) :
            base(_условия, _размерКредита, _срокКредита)
        {
            фамилия = _фамилия;
        }

        public ФизЛицо() :
            base()
        {
        }



        public override string Атрибуты
        {
            get { return фамилия; }
            set { фамилия = value; }
        }

        public string Фамилия
        {
            get { return фамилия; }
            set { фамилия = value; }
        }


    }
}
