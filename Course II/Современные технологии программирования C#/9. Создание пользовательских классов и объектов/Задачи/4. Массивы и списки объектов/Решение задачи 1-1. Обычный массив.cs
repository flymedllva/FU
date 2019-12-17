using System;
using System.Collections.Generic;
using System.Collections;


class Student
{
    private string fam;
    private int age;
    private int curs;
    private int o1, o2, o3;


    public int Age
    {
        get { return age; }             // d=Age;
        set
        {
            if (value - curs >= 16 && value - curs <= 19)
                age = value;
            else
                Console.WriteLine("Неверно задан возрст");
        }            // Age=18
    }

    public string Fam
    {
        get { return fam; }
        set { fam = value; }
    }


    public Student(string _fam, int age1, int curs,
                   int o1, int o2, int o3)
    {
        fam = _fam;
        age = age1;
        this.curs = curs;
        this.o1 = o1;
        this.o2 = o2;
        this.o3 = o3;
    }



    public string Show()
    {
        return "Студент " + this.fam + "  курс " + curs + "   возраст " + age + " лет";
    }

    public float Aver()
    {
        return (o1 + o2 + o3) / 3.0f;
    }

}

class Program
{
    static void Main(string[] args)
    {
        string str;
        float aver;
        //List<Student> list = new List<Student>(); 
        Student[] list = new Student[50];


        Student тюленева = new Student("Тюленева", 17, 1, 10, 5, 7);
        list[0] = тюленева;

        aver = list[0].Aver();
        str = тюленева.Show();
        Console.WriteLine(str + "  средняя оценка=" + aver);

        тюленева.Age = 18;
        Console.WriteLine(тюленева.Age);

        list[1] = new Student("aaaaaaa", 17, 1, 10, 5, 7);
        list[2] = new Student("ddddddd", 17, 1, 10, 5, 7);
        list[3] = new Student("fffffff", 18, 2, 10, 5, 7);
        list[4] = new Student("eeeeeee", 17, 1, 10, 5, 7);
        list[5] = new Student("yyyyyyy", 17, 1, 10, 5, 7);
        list[6] = new Student("kkkkkkk", 19, 3, 10, 5, 7);
        int n = 7;

        Console.WriteLine("-------------------------------------");


        for (int i=0; i<n; i++)
            Console.WriteLine(list[i].Show());

        Console.WriteLine("-------------------------------------");

        for (int i = 0; i < n; i++)
        {
            if (list[i].Age > 17)
                    Console.WriteLine(list[i].Show());
        }

        Console.WriteLine("-------------------------------------");

        float sr = 0f;
        for (int i = 0; i < n; i++)
        {
           sr+=list[i].Aver();
        }
        sr = sr / n;
        Console.WriteLine("средняя оценка группы = " + sr);
    }
}
