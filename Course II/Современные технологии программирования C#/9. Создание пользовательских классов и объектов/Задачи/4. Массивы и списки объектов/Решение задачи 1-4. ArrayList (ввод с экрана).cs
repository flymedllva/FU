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


    //-------------------------------------------------------------------
    public string Show()
    {
        return "Студент " + this.fam + "  курс " + curs + "   возраст " + age + " лет";
    }

    //-------------------------------------------------------------------
    public float Aver()
    {
        return (o1 + o2 + o3) / 3.0f;
    }

}
//=================================================================
class Program
{
    static void Main(string[] args)
    {
        string str;
        float aver;

        string fam;
        int age;
        int curs;
        int o1, o2, o3;


        ArrayList list = new ArrayList(); 
        //Student[] list = new Student[50];

        int n=0;
        while (n<50)
        {
            Console.Write("Введите фамилию: ");
            fam = Console.ReadLine();
            if (fam == "" || fam == " ") break;

            Console.Write("Введите возраст: ");
            age = int.Parse(Console.ReadLine());

            Console.Write("Введите курс: ");
            curs = int.Parse(Console.ReadLine());

            Console.Write("Введите оценка 1: ");
            o1 = int.Parse(Console.ReadLine());

            Console.Write("Введите оценка 2: ");
            o2 = int.Parse(Console.ReadLine());

            Console.Write("Введите оценка 3: ");
            o3 = int.Parse(Console.ReadLine());
            Console.WriteLine("------------------------------------");
            list.Add(new Student(fam, age, curs, o1, o2, o3));
            //list[n++] = new Student(fam, age, curs, o1, o2, o3);
        }

        n = list.Count;
        Console.WriteLine("-------------------------------------");


        for (int i=0; i<n; i++)
            Console.WriteLine(((Student)list[i]).Show());

        Console.WriteLine("-------------------------------------");

        for (int i = 0; i < n; i++)
        {
            if (((Student)list[i]).Age > 17)
                    Console.WriteLine(((Student)list[i]).Show());
        }

        Console.WriteLine("-------------------------------------");

        float sr = 0f;
        for (int i = 0; i < n; i++)
        {
           sr = sr + ((Student)list[i]).Aver();
        }
        sr = sr / n;
        Console.WriteLine("средняя оценка группы = " + sr);
    }
}
