using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Учет
{
    class Program
    {
        static void Main(string[] args)
        {
            Студент.группа = "1ПИ1";
            Console.WriteLine(Студент.ВыдатьГруппу());
            Студент ст1 = new Студент(); 
            ст1.фамилия = "Иванов"; 
            ст1.рейтинг = 87;
            Console.WriteLine(ст1.ВыдатьДанные());
            Студент ст2 = new Студент(); 
            ст2.фамилия = "Козлов";
            ст2.рейтинг = 15;
            Console.WriteLine(ст2.ВыдатьДанные());
        }
    }
}
