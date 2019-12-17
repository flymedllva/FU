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
            Студент ст1 = new Студент("Иванов",87, "3МЭ4"); 
            Студент ст2 = new Студент("Козлов"); 
            Console.WriteLine(ст1.ВыдатьДанные());
            Console.WriteLine(ст2.ВыдатьДанные());
        }
    }
}
