/*
     Ввести с клавиатуры два вещественных положительных числа.
   Вычислить и вывести на экран:
    1. Сумму дробных частей этих чисел
    2. Среднее значение целых частей
   Например, для 2.25 и 3.75 сумма дробных частей 1.0,
   а среднее значение целых частей 2.5
*/

using System;
class Chislo
{
 public static void Main()
  {
	float  x1,x2,    // Исходные числа
		   s,        // Сумма дробных частей
		   sr;       // Среднее значение целых частей
	int    cx1,cx2;  // Целые части чисел
   	string str;      // Строка для приема данных и вывода данных
	
	Console.Write("Введите первое число:  "); 
	str = Console.ReadLine(); 
	x1 = float.Parse(str); 
	Console.Write("Введите второе число:  "); 
	str = Console.ReadLine(); 
	x2 = float.Parse(str); 
	   
	s = (x1 - (int)x1) + (x2 - (int)x2);
	cx1 = (int)x1;
	cx2 = (int)x2;
	sr = (float)(cx1 + cx2) / 2;

	str = s.ToString();
      str = "Сумма дробных частей=" + str;
	Console.WriteLine(str);
	str = sr.ToString();
	str = "Среднее значение целых частей=" + str;
	Console.WriteLine(str);

	Console.ReadLine();  
  } //Конец определения метода
} //Конец объявления класса
