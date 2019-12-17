/*
Переменная А должна последовательно изменяться от 0 до 5 с шагом 1. 
Составить выражение, которое автоматически обеспечит «перескоки» 
значения от 5 к 0. 
*/

using System;

class Счастье
{
    static void Main(string[] args)
    {
        int A;

        A = 0;              // A=0
        Console.WriteLine("число = " + A);

        A = ++A % 6;        				// A=1
        Console.WriteLine("число = " + A);

        A = ++A % 6;        				// A=2
        Console.WriteLine("число = " + A);

        A = ++A % 6;        				// A=3
        Console.WriteLine("число = " + A);

        A = ++A % 6;        				// A=4
        Console.WriteLine("число = " + A);

        A = ++A % 6;        				// A=5
        Console.WriteLine("число = " + A);

        A = ++A % 6;        				// A=0
        Console.WriteLine("число = " + A);

        A = ++A % 6;        				// A=1
        Console.WriteLine("число = " + A);

        A = ++A % 6;        				// A=2
        Console.WriteLine("число = " + A);
        // ...  и т.д. ...

        Console.ReadLine();
    }
}
