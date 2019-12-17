using System;
using System.Collections.Generic;

namespace Индексаторы
{
    class Student
    {
        public string   Name    { get; set; }
        public float    Mat     { get; set; }
        public float    Progr   { get; set; }
        public float    Inostr  { get; set; }
        public float    Econ    { get; set; }
        public float    Istor   { get; set; }

        public Student(string _Name, float _Mat, float _Progr, float _Inostr,
                       float _Econ, float _Istor)
        {
            Name    = _Name;
            Mat     = _Mat;
            Progr   = _Progr;
            Inostr  = _Inostr;
            Econ    = _Econ;
            Istor   = _Istor;
        }
    }


    //==========================================================================
    class Program
    {
        static void Main(string[] args)
        {
            float srPit;
            float srBob;
            float srMet;
            float srAll;

            Student Pit = new Student("Pit", 8, 9, 6, 9, 7);
            Student Bob = new Student("Bob", 5, 4, 6, 7, 6);
            Student Met = new Student("Met", 7, 9, 8, 9, 5);

            srPit = (Pit.Mat + Pit.Progr + Pit.Inostr + Pit.Istor + Pit.Econ) / 5.0f;
            srBob = (Bob.Mat + Bob.Progr + Bob.Inostr + Bob.Istor + Bob.Econ) / 5.0f;
            srMet = (Met.Mat + Met.Progr + Met.Inostr + Met.Istor + Met.Econ) / 5.0f;

            srAll = (srPit + srBob + srMet) / 3;

            Console.WriteLine("Средняя оценка за группу = " + srAll);
        }
    }
}
