using System;
using System.Collections.Generic;

namespace Индексаторы
{
    class Student
    {
        public string Name  { get; set; }
        public float  Mat   { get; set; }
        public float  Progr { get; set; }
        public float  Inostr { get; set; }
        public float  Econ  { get; set; }
        public float  Istor { get; set; }

        public Student(string _Name, float _Mat, float _Progr, float _Inostr,
                       float _Econ, float _Istor)
        {
            Name = _Name;
            Mat = _Mat;
            Progr = _Progr;
            Inostr = _Inostr;
            Econ = _Econ;
            Istor = _Istor;
        }


        public static readonly int Count = 5;

        public float this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return Mat;
                    case 1: return Progr;
                    case 2: return Inostr;
                    case 3: return Econ;
                    case 4: return Istor;
                    default:
                        Console.WriteLine("Не правильный номер предмета (0-4)!");
                        return 0;
                }
            }


            set
            {
                switch (i)
                {
                    case 0: Mat = value; break;
                    case 1: Progr = value; break;
                    case 2: Inostr = value; break;
                    case 3: Econ = value; break;
                    case 4: Istor = value; break;
                    default:
                        Console.WriteLine("Не правильный номер предмета (0-4)!");
                        break;
                }
            }
        }
    }


    //----------------------------------------------------------------------
    class Program2
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            float sr;
            //float srBob ;
            //float srMet;
            float s = 0;

            Student Nik = new Student("Nik", 9, 10, 6, 9, 7);
            for (int i = 0; i < Student.Count; i++)
                s += Nik[i];
            sr = s / Student.Count;
            Console.WriteLine("Средняя оценка Nik = " + sr);




            list.Add(new Student("Pit", 8, 9, 6, 9, 7));
            list.Add(new Student("Bob", 5, 4, 6, 7, 6));
            list.Add(new Student("Met", 7, 9, 8, 9, 5));

            //srPit = (Pit.Mat + Pit.Progr + Pit.Inostr + Pit.Istor + Pit.Econ) / 5.0f;
            //srBob = (Bob.Mat + Bob.Progr + Bob.Inostr + Bob.Istor + Bob.Econ) / 5.0f;
            //srMet = (Met.Mat + Met.Progr + Met.Inostr + Met.Istor + Met.Econ) / 5.0f;

            //srAll = (srPit + srBob + srMet) / 3;

            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < Student.Count; j++)
                    s += list[i][j];

            sr = s / list.Count / Student.Count;

            Console.WriteLine("Средняя оценка за группу = " + sr);

        }
    }
}
