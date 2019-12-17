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
            
            Console.WriteLine(Студент.ВыдатьГруппу());
            Студент ст1 = new Студент("Иванов",87); 
            Console.WriteLine(ст1.ВыдатьДанные());
            Студент ст2 = new Студент("Козлов"); 
            Console.WriteLine(ст2.ВыдатьДанные());
        }
    }
}
