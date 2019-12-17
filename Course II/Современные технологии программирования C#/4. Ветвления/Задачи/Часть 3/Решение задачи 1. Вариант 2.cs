/*
  ПРАКТИЧЕСКОЕ ЗАНЯТИЕ 4. ЗАДАЧА 2.2
  Функциональный аналог задачи 2.1.
  Для работы с символами используются методы объектов типа char
 */
using System;
class Operator
{
 public static void Main()
  {  
	 char   cifra,      //Первый символ (цифра)
	        bukva,      //Второй символ (прописная буква)
	        newbuk;     //Новая буква   
	 int    delta;      //Величина сдвига в алфавите
	 char   rep;        //Признак повторного выполнения  // лучше string
	 string str;      //Строка для приема данных и вывода данных
	
	 REPEAT:
	 Console.Write("Введите первый символ (цифра):  "); 
	 str = Console.ReadLine();
	 cifra= char.Parse(str); 	
	 Console.Write("Введите второй символ (буква):  "); 
	 str = Console.ReadLine();
	 bukva= char.Parse(str); 	
	 
	 newbuk = bukva;
	 delta = (int)char.GetNumericValue(cifra);
	 if(delta >0)
		 if(char.IsUpper(bukva))
		   {
			 newbuk = (char)(bukva + delta);
			 if(newbuk > 'Z')
				 newbuk = (char)('A' + (newbuk - 'Z' - 1));
		   }

	 if(newbuk == bukva)
		str = "Преобразования не было";
	 else
	    str = string.Format("{0} ---> {1}",bukva,newbuk);
	 Console.WriteLine(str);
	 
	 Console.Write("Для повтора вычислений намите клавишу Y: ");
	 rep = char.Parse(Console.ReadLine());  // если string, то без Parse
	 Console.WriteLine();
	 if(rep == 'Y' || rep == 'y') goto REPEAT;	// "Y" , "y"
  } //Конец определения метода
} //Конец объявления класса

