using System;
using System.Collections.Generic;
using System.Text;

namespace СортировкаМассиваОбъектов
{
    class Аудитория
    {
        private int номер;
        private int места;

        public Аудитория(int номер, int места)
        {
            this.номер = номер;
            this.места = места; 
        }

         public string Сообщить()
         {
             string сообщение =  string.Format("{0,-10}","Аудитория"); 
             сообщение = сообщение + string.Format("{0,8}", номер);
             сообщение = сообщение + string.Format("{0,4}", места);
             return сообщение;
         }

        public int СравнитьСАудиторией(Аудитория аудитория)
        {
            int результатСравнения = 0;
            if (this.номер < аудитория.номер) результатСравнения = -1;
            if (this.номер > аудитория.номер) результатСравнения =  1;
            return результатСравнения;
        }
    }
}
