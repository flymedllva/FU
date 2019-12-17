/*
 Вычислить значение функции G=F(X,Y)

	     |  X+sin(Y), если X<Y и X>0;
    G = <
	     |  Y-cos(X), если X>Y и X<0;
	     |  0.5*X*Y   - во всех остальных случаях
 
*/
using System;

class Operator
{
 public static void Main()
  {
	 double         x,y,       //Координаты точки
	                g;         //Значение функции
	 string         str;       //Строка для приема данных и вывода данных
		           
	 Console.Write("Введите X:  "); 
	 str = Console.ReadLine();
	 x = double.Parse(str); 	

	 Console.Write("Введите Y:  "); 
	 str = Console.ReadLine();
	 y = double.Parse(str); 	
	 
	 if(x<y && x>0)
		 g = x + Math.Sin(y);
	 else
		 if(x>y && x<0)
		    g = y - Math.Cos(x);
	 else
		    g = 0.5 * x * y;

	 str = string.Format("G({0:f3}, {1:f3}) = {2:f3}",x,y,g); 
	 Console.WriteLine(str);

	 Console.Write("Для завершения программы намите клавишу Enter: ");
	 Console.ReadLine();  
	 
  } //Конец определения метода
} //Конец объявления класса
