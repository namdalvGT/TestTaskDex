using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEvents_11
{
    class Task2
    {
        public Task2()
        {
            Console.WriteLine("********Задание 2************");
            Number number = new Number(100);
            number.hendler += OnHendler;
            var summas = (number.Number_ - number.limit);
            for (int i =0 ; i < number.Number_; i++)
            {
                var procent = 100*i / 100;
                
                if (procent > summas)
                {
                    number.InvokeMethod($"Отличаеться от суммы на {number.limit}% ,Сумма:{summas}");
                    break;
                }
                
            }
            
        }
        public virtual void OnHendler(string message)
        {
            Console.WriteLine(message);

        }
        public class Number
        {
            public  int Number_ { get; set; }

            public int limit = 5;
            public delegate void EventHandler(string message);

            public event EventHandler hendler;


            public Number(int number)
            {
                Number_ = number;
            }

            public void InvokeMethod(string message)
            {
                hendler?.Invoke(message);
            }


          
        }

    }

    
}
