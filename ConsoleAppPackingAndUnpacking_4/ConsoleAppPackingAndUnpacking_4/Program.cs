using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPackingAndUnpacking_4
{
    class Program
    {
        static void Main(string[] args)
        {

            #region [1] Упаковка

            int i = 123;

            var packingWhatch = System.Diagnostics.Stopwatch.StartNew();
            object o = i; // упаковка
            packingWhatch.Stop();
            var elapsedMsP = packingWhatch.ElapsedMilliseconds;
            TimeSpan tp = TimeSpan.FromMilliseconds(elapsedMsP);
            string answerP = string.Format("{0:D2}:{1:D2}:{2:D2}",
                tp.Hours,
                tp.Minutes,
                tp.Seconds);

            Console.WriteLine($"Время упаковки {answerP}");


            #endregion


            #region [2] Распаковка
            
            try
            {
                var unpackingWhatch = System.Diagnostics.Stopwatch.StartNew();
                int j = (int)o; // попытка распаковки

                var elapsedU = unpackingWhatch.ElapsedMilliseconds;
                TimeSpan tu  = TimeSpan.FromMilliseconds(elapsedU);
                string answerU = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    tu.Hours,
                    tu.Minutes,
                    tu.Seconds);

                System.Console.WriteLine("Unboxing OK.");
                Console.WriteLine($"Время распаковки {answerU}");
            }
            catch (System.InvalidCastException e)
            {
                System.Console.WriteLine("{0} Error: Incorrect unboxing.", e.Message);
            }

            #endregion

            Console.ReadKey();
        }

        private void unpacking() { }
    }
}
