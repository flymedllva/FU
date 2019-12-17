using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace СортировкаМассиваОбъектов
{
    class Аудитория:IComparable
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

        public int CompareTo(object объект)
        {
            Аудитория аудитория = (Аудитория)объект;
            int результатСравнения = 0;
            if (this.номер  <  аудитория.номер)  результатСравнения = -1;
            if (this.номер  >  аудитория.номер)  результатСравнения =  1;
            return результатСравнения;
        }
    }
}
