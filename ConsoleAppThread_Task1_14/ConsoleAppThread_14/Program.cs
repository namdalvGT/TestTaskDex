using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppThread_14
{
    class Program
    {
        static void Main(string[] args)
        {
            TreadMethod();
            Method();


        }

        public static void Method()
        {
            CounterFirst();
            CounterSecond();
            Console.ReadKey();
        }

        public static void TreadMethod()
        {
            var loker1 = new object();
            var loker2 = new object();

            var completed = 0;
            Console.WriteLine("Идет загрузка...");
            ThreadPool.QueueUserWorkItem(_ =>
            {
                lock (loker1)
                {
                    CounterFirst();
                    completed++;
                }

                Interlocked.Increment(ref completed);
            });



            ThreadPool.QueueUserWorkItem(_ =>
            {
                lock (loker2)
                {
                    CounterSecond();
                    completed ++;
                }

                Interlocked.Increment(ref completed);
            });

            while (completed < 2)
            {
                Thread.Sleep(25);
            }

            
        }

        public static int CounterFirst()
        {
            
            ulong[] ara = new ulong[156250];//10M
            decimal avg = 0;
            for (int i = 0; i < ara.Length; i++)
            {
               avg += i;
            }
            avg /= ara.Length;
            Console.WriteLine($"Первый: {avg}");
            
            return 0;
        }



        public static int CounterSecond()
        {
            char[] ara = new char[1562500];//100M
            decimal avg = 0;
            for (int i = 0; i < ara.Length; i++)
            {
                avg += i;
            }
            avg /= ara.Length;
            Console.WriteLine($"Второй: {avg}");
            
            return 0;
        }
    }
}
