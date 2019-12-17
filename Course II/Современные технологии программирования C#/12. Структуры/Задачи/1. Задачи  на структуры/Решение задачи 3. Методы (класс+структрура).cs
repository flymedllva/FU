using System;

class Class1        // Треугольник
{
    public int x1, y1, x2, y2, x3, y3;
    public Class1(int _x1, int _y1, int _x2, int _y2, int _x3, int _y3)
    {
        x1 = _x1;   y1 = _y1;
        x2 = _x2;   y2 = _y2;
        x3 = _x3;   y3 = _y3;
    }
}

struct Struct1       // Треугольник
{
    public int x1, y1, x2, y2, x3, y3;

    public Struct1(int _x1, int _y1, int _x2, int _y2, int _x3, int _y3)
    {
        x1 = _x1;   y1 = _y1;
        x2 = _x2;   y2 = _y2;
        x3 = _x3;   y3 = _y3;
    }
}

class Program
{
    // --1--  Перемещение треугольника по диагонали. Вариант с множеством параметров.
    // Треугольник определяется координатами своих углов.
    static void Shape(ref int x1, ref int y1, ref int x2, ref int y2, ref int x3, ref int y3, int c)
    {
        x1 += c;   y1 += c;
        x2 += c;   y2 += c;
        x3 += c;   y3 += c;
    }


    // --2--  Перемещение треугольника по диагонали. Вариант с экземпляром класса.
    static void ShapeClass(Class1 objClass, int c)
    {
        objClass.x1 += c;   objClass.y1 += c;
        objClass.x2 += c;   objClass.y2 += c;
        objClass.x3 += c;   objClass.y3 += c;
    }


    // --3--  Перемещение треугольника по диагонали. Вариант с экземпляром структуры.
    static Struct1 ShapeStruct(Struct1 objStruct, int c)
    {
        objStruct.x1 += c;   objStruct.y1 += c;
        objStruct.x2 += c;   objStruct.y2 += c;
        objStruct.x3 += c;   objStruct.y3 += c;

        return objStruct;
    }

    // --3--  Перемещение треугольника по диагонали. Вариант со ссылкой на экземпляр структуры.
    static void ShapeStruct(ref Struct1 objStruct, int c)
    {
        objStruct.x1 += c;   objStruct.y1 += c;
        objStruct.x2 += c;   objStruct.y2 += c;
        objStruct.x3 += c;   objStruct.y3 += c;

        return objStruct;
    }

    static void Main(string[] args)
    {
        int x1 = 40, y1 = 10, x2 = 10, y2 = 70, x3 = 60, y3 = 70;
        int c = 10;
        Console.WriteLine("Исходные координаты (x,y):      ({0}, {1})    ({2}, {3})    ({4}, {5})\n", x1, y1, x2, y2, x3, y3);

        // --1--   Чтобы возвратить много папраметров, приходится передавать их по ссылке.
        Shape(ref x1, ref  y1, ref  x2, ref  y2, ref  x3, ref  y3, c);
        Console.WriteLine("Передается много параметров:    ({0}, {1})    ({2}, {3})    ({4}, {5})", x1, y1, x2, y2, x3, y3);

        
        // --2--  Вариант с классом.  Экземпляр класса передается по ссылке, поэтому ничего возвращать не надо.
        // Восстанавливаем координаты.
        x1 = 40; y1 = 5; x2 = 10; y2 = 70; x3 = 60; y3 = 70;

        Class1 objClass = new Class1(x1, y1, x2, y2, x3, y3);
        ShapeClass(objClass, c);
        Console.WriteLine("Параметр - экземпляр класса:    ({0}, {1})    ({2}, {3})    ({4}, {5})", objClass.x1, objClass.y1, objClass.x2, objClass.y2, objClass.x3, objClass.y3);


        // --3--   Вариант со структурой.  Экземпляр структуры передается как значение, поэтому надо возвращать структуру.
        Struct1 objStruct = new Struct1(x1, y1, x2, y2, x3, y3);
        Struct1 newStruct = ShapeStruct(objStruct, c);
        Console.WriteLine("Параметр - экземпляр структуры: ({0}, {1})    ({2}, {3})    ({4}, {5})\n", newStruct.x1, newStruct.y1, newStruct.x2, newStruct.y2, newStruct.x3, newStruct.y3);



        // --4--   Вариант со структурой.  Экземпляр структуры передается по ссылке, поэтому ничего возвращать не надо
        Struct1 objStruct2 = new Struct1(x1, y1, x2, y2, x3, y3);
        ShapeStruct(ref objStruct2, c);
        Console.WriteLine("Параметр - ссылка на экземпляр структуры: ({0}, {1})    ({2}, {3})    ({4}, {5})\n", 
                         objStruct2.x1,objStruct2.y1, objStruct2.x2, objStruct2.y2,objStruct2.x3, objStruct2.y3);

        Console.ReadKey(true);
    }
}