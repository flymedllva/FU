using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Прямоугольник
    {
        public int w;		// ширина
        public int h;		//высота
        public static int c = 0;	//количество объектов


        public Прямоугольник(int w1, int h1)  //констр.
        {
            w = w1;
            h = h1;
            c = c + 1;
        }


        public int Square()
        {
            int s;
            s = w * h;
            return s;
        }


        public int Периметр()
        {
            int p;
            p = 2 * (w + h);
            return p;
        }
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    class Program
    {
        static void Main(string[] args)
        {
            Прямоугольник прямоугольник1;
            прямоугольник1 = new Прямоугольник(10, 5);

            Прямоугольник квадрат1 = new Прямоугольник(15, 15);

            int sПр, sКв, p;
            sПр = прямоугольник1.Square();
            Console.WriteLine("Площадь прямоугольника = " + sПр);

            sКв = квадрат1.Square();
            Console.WriteLine(sКв);

            p = квадрат1.Периметр();
            Console.WriteLine(p);

            прямоугольник1.w = 30;
            прямоугольник1.h = 20;
            int count1;
            count1 = Прямоугольник.c;
            Console.WriteLine(count1);

        }
    }
}
