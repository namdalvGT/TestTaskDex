using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppThreadNewAsync.Class
{
    class ControlPanel
    {
        public void ReaderKeys(JobExecutor js, Action action,int numberJob)
        {
           while (true)
           {
               var keys = Console.ReadLine();
               if (keys == "1" || keys == "2" || keys == "3")
               {
                   switch (keys)
                   {
                       case "1":
                           AddName(js, action,numberJob);
                           break;
                       case "2":
                           ClearQueue(js, action);
                           break;
                       case "3":
                           StopJob(js, action);
                           break;
                   }
               }
               else
               {
                   Console.WriteLine("Не верный символ попробуйте еще раз.");
               }
           }
        }

        private void AddName(JobExecutor je, Action action,int numberJob)
        {
            for (int i = 0; i < numberJob; i++)
            {
                je.Add(action);
            }
        }


        private void ClearQueue(JobExecutor je, Action action)
        {
            je.Clear();
        }


        private void StopJob(JobExecutor je, Action action)
        {
            je.Stop();
        }
    }
}
