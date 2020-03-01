using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEvents_11
{
    class Task1
    {
        public Task1()
        {
            Console.WriteLine("********Задание 1************");
            Money money = new Money(10);
            money.Notify += DisplayMessage;

            while (money.dollar > 0)
            {
                money.Cut();
                if (money.dollar == 0)
                {
                    break;
                }
            }
           
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Money
    {
        public int dollar;
        public int limit = 5;
        public delegate void MoneyHandler(string message);
        public event MoneyHandler Notify;

        public Money(int countDollars)
        {
            dollar = countDollars;
        }

        public void Cut()
        {
            if (dollar <= 0)
            {
                Notify?.Invoke($"Деньги закончились ");
            }
            else
            {
                dollar -= 1;
                if (dollar < limit && dollar != 0)
                {
                    Notify?.Invoke($"Превышен лимит. Осталось {dollar} ");
                }
                else if (dollar == 0)
                {
                    Notify?.Invoke($"Денег нет, но вы держитесь");
                }
                else
                {
                    Notify?.Invoke($"Осталось {dollar} ");
                }
            }
        }




    }
}
