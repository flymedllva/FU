/*
 * Каким минимальным количеством купюр достоинством 500, 100 и 10 рублей, 
 * а также монетами 2 руб. можно разменять сумму R рублей 
 * и возможен ли такой размен? 
 * Вывести количество купюр разного достоинства и количество монет по 2 руб.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        int rub, tys, sto, desyat, dva, n;

        Console.WriteLine();
        rub = Convert.ToInt32(Console.ReadLine());

        if (rub % 2 == 1)
        {
            Console.WriteLine("Разменять данную сумму невозможно!");
            return;
        }

        tys = rub / 1000; 			    // кол-во по 1000
        rub = rub - tys * 1000; 		// остаток
        sto = rub / 100; 				// кол-во по 100
        rub = rub - sto * 100; 			// остаток
        desyat = rub / 10; 			    //кол-во по 10
        dva = rub % 10 / 2;

        n = tys + sto + desyat + dva;

        Console.WriteLine("Минимальное количество купюр = " + n);
        Console.WriteLine(tys + " тысяч " + sto + " сотен "
            + desyat + " десяток " + dva + " монет по 2 руб");

        Console.ReadKey();
    }
}
