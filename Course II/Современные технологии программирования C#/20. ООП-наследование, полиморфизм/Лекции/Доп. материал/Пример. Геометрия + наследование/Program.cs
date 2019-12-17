using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Геометрия
{
    class Фигура
    {
        protected double x;
        protected double y;
        public Фигура(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void Положение()
        {
            Console.WriteLine("X={0:F2} Y={1:F2}",x,y);
        }
    }

    class Круг:Фигура
    {
        public double r;
        public Круг(double x, double y, double r): base(x,y)
        {
            this.r = r;
        }
        public void Площадь()
        {
            Console.WriteLine("Площадь круга={0:F2}",Math.PI*r*r );
        }
    }

    class Прямоугольник : Фигура
    {
        public double a;
        public double b;
        public Прямоугольник(double x, double y, double a, double b): base(x, y)
        {
            this.a = a;
            this.b = b;
        }
        public void Площадь()
        {
            Console.WriteLine("Площадь прямоугольника={0:F2}", a*b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Круг k = new Круг(0,0,1);
            Прямоугольник p = new Прямоугольник(1, 1, 4, 5);
            k.Положение();
            k.Площадь();
            p.Положение();
            p.Площадь();
        }
    }
}
