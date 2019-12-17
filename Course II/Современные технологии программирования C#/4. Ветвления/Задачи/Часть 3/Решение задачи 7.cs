/*
  Задана стоимость трех типов товаров в копейках (в виде именованных констант). 
  Покупатель выбирает товар (вводит номер 1,2 или 3), количество приобретаемых экземпляров
  и сумму, представленную в качестве оплаты. Сумма указывается в рублях и копейках. 
  Вычислить и выдать на экран сдачу в рублях и копейках.
*/

using System;
class Operator
{
    public static void Main()
    {
        const int T1 = 1200,    //Стоимость первого  товара (копейки)
                  T2 = 2551,    //Стоимость второго  товара (копейки)
                  T3 = 1985;    //Стоимость третьего товара (копейки)
        int    itog,       //Сумма к оплате за приобретенный товар (копейки)
               sumr,       //Сумма, внесенная покупателем (рубли)
               sumk,       //Сумма, внесенная покупателем (копейки)
               ostk,       //Сдача (копейки)
               ostr,       //Сдача (рубли)
               tip,        //Тип выбранного товара
               n;          //Количество экземпляров товара
        string str;        //Строка для приема данных и вывода данных

        // Ввод исходных данных
        Console.Write("Выберите покупку:\n1.Тетрадь\n2.Карандаш\n");
        Console.Write("3.Ручка\n4.Ничего покупать не буду\n");
        tip = int.Parse(Console.ReadLine());

        if (tip < 1 || tip >= 4) return;

        Console.Write("Сколько штук: ");
        n = int.Parse(Console.ReadLine());

        Console.Write("Внесенная сумма==> рубли:   ");
        sumr = int.Parse(Console.ReadLine());

        Console.Write("             ==> копейки:   ");
        sumk = int.Parse(Console.ReadLine());



        // Вычисление сдачи
        sumk += 100 * sumr;
        itog = 0;
        switch (tip)
        {
            case 1: itog = T1 * n; break;
            case 2: itog = T2 * n; break;
            case 3: itog = T3 * n; break;
        }

        ostk = sumk - itog;

        if (ostk < 0)
            str = "Маловато будет!";
        else
        {
            ostr = ostk / 100;
            ostk = ostk % 100;
            str = string.Format("Сдача: {0}руб. {1:d2}коп.", ostr, ostk);
        }
        Console.Write(str);



        Console.WriteLine("\nДля завершения программы нажмите клавишу ENTER");
        Console.ReadLine();
    } 
} 

