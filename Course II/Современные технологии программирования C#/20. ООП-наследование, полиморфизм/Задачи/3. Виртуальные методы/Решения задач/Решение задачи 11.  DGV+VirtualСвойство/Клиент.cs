using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DGV_VirtualMethod
{
    class Клиент
    {
        public string условия;
        public int размерКредита;
        public int срокКредита;

        public Клиент(string _условия, int _размерКредита, int _срокКредита)
        {
            условия = _условия;
            размерКредита = _размерКредита;
            срокКредита = _срокКредита;
        }
        public Клиент()
        {
            размерКредита = 999;
            срокКредита = 2020;
        }

        public virtual string Атрибуты
        {
            get { return "Нет имени"; }
            set {  }
        }

        public string Условия
        {
            get { return условия; }
            set { условия = value; }
        }

        public int РазмерКредита
        {
            get { return размерКредита; }
            //get { return 111; }
            set { размерКредита = value; }
        }

        public int СрокКредита
        {
            get { return срокКредита; }
            set { срокКредита = value; }
        }

    }
}
