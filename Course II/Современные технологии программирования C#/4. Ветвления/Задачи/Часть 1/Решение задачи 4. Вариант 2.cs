/*
 Вычислить значение функции G=F(X,Y)
       | true, если точка с координатами (X,Y) попадает в фигуру
  G = <
       | false, если точка с координатами (X,Y) не попадает в фигуру
  Фигура - сектор круга радиусом R=2 в диапазоне углов 180<= fi <=45
  Задача решается методом от обратного: предполагаем, что точка не
  принадлежит фигуре, а по результатам проверки корректируем
  это предположение
*/

using System;

class Operator
{
 public static void Main()
  {
	 const double   R = 2.0;   //Радиус
	
	 double         x,y;       //Координаты точки
	 bool           g;         //Значение функции
	 string           rep;       //Признак повторного выполнения
	 string         str;       //Строка для приема данных и вывода данных
		           
	 REPEAT:
	 Console.Write("Введите X:  "); 
	 str = Console.ReadLine();
	 x = double.Parse(str); 	
	 Console.Write("Введите Y:  "); 
	 str = Console.ReadLine();
	 y = double.Parse(str); 	
	
	 g = false;     //предварительное решение о промахе
	 if(x*x + y*y <= R*R)    //в круге
		 if(x >= 0)             //справа от оси Y
			 if(y <= x)            //и ниже прямой y = x
				 g = true;             //корректируем решение      
	 
	 str = string.Format("G({0:f3},{1:f3}) = {2}",x,y,g);
	 Console.WriteLine(str);

	 Console.Write("Для повтора вычислений намите клавишу Y: ");
	 rep = Console.ReadLine();  
	 Console.WriteLine();
	 if(rep == "Y" || rep == "y") goto REPEAT;
  } //Конец определения метода
} //Конец объявления класса
