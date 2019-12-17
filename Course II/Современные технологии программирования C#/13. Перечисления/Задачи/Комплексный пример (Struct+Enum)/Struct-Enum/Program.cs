using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct_Enum
{

    class Program
    {
        [Flags]
        enum drinks { не_пьет = 0, вода = 1, чай=2, кофе=4, мартини=8, рассол=16 }

        enum marks { нет_оценки, неудовлетв = 2, удовлетв, хорошо, отлично }
        
        struct Student
        {
            public string name;
            public int kurs;
            public marks o1, o2, o3, o4;
            public drinks питьё;
        }



        static void Main(string[] args)
        {
            Student Иванов;

            Иванов.name = "Иванов";
            Иванов.kurs = 1;
            Иванов.o1 = marks.хорошо;
            Иванов.o2 = marks.отлично;
            Иванов.o3 = marks.удовлетв;
            Иванов.o4 = marks.отлично;
            Иванов.питьё = drinks.кофе | drinks.мартини | drinks.рассол;

            string std1 = Avg(Иванов);
            Console.WriteLine(std1);

            if ((Иванов.питьё & drinks.мартини) == drinks.мартини)
                Console.WriteLine("Аристократ");

            if ((Иванов.питьё & drinks.рассол) == drinks.рассол)
                Console.WriteLine("Пьяница");

        }

        static string Avg(Student std)
        {
            float a = ((int)(std.o1) + (int)(std.o2) + (int)(std.o3) + (int)(std.o4)) / 4.0f;
            return "Студент " + std.name + " курс " + std.kurs + " Средний балл=" + a + " Пьет " + std.питьё + 
                string.Format(" Оценки: {0}, {1}, {2}, {3}", std.o1, std.o2, std.o3, std.o4);
        }
    }
}
