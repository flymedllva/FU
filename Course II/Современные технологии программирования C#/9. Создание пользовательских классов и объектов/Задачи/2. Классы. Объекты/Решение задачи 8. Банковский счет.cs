
using System;
// Класс Account определяет банковский счет.
public class Account
{
   //закрытые поля класса
   int debit  = 0, 
        credit = 0;

   // Зачисление на счет с проверкой

   public void putMoney (int sum)
   {
      int res =1;
      if (sum >0)credit += sum;
      else res = -1;
      Mes(res,sum);
   }


   // Снятие со счета с проверкой
   public void getMoney (int sum)
   {
      int res=2;
      if(sum <= balance())debit += sum;
      else res = -2;
      balance();
      Mes(res, sum);
   }


   // вычисление баланса
   int balance()
   {
      return(credit - debit);	
   }

   // Уведомление о выполнении операции
   void Mes (int result, int sum)
   {
      switch (result)
      {
         case 1:
            Console.WriteLine("Операция зачисления денег прошла успешно!");
            Console.WriteLine("Cумма={0}, 
               Ваш текущий баланс={1}", sum,balance());
            break;
         case 2:
            Console.WriteLine("Операция снятия денег 
               прошла успешно!");
            Console.WriteLine("Cумма={0}, 
               Ваш текущий баланс={1}", sum,balance());
            break;
         case -1:
            Console.WriteLine("Операция зачисления денег 
               не выполнена!");
            Console.WriteLine("Сумма должна быть больше нуля!");
            Console.WriteLine("Cумма={0}, 
               Ваш текущий баланс={1}", sum,balance());
            break;
         case -2:
            Console.WriteLine("Операция снятия денег не выполнена!");
            Console.WriteLine("Сумма должна быть 
               не больше баланса!");
            Console.WriteLine("Cумма={0}, 
               Ваш текущий баланс={1}", sum,balance());
            break;
         default:
            Console.WriteLine("Неизвестная операция!");
            break;
      }
   }
}//Account


public class Test1
{
   public void Main()
   {
      Account1 myAccount = new Account1();
      myAccount.putMoney(6000);
      myAccount.getMoney(2500);
      myAccount.putMoney(1000);
      myAccount.getMoney(4000);
      myAccount.getMoney(1000);
   }
}
