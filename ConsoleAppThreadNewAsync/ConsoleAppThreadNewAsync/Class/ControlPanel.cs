using System;

namespace ConsoleAppThreadNewAsync.Class
{
    class ControlPanel
    {
        public void ReaderKeys(JobExecutor je, Action action,int numberJob)
        {
           while (true)
           {
               var keys = Console.ReadLine();
               if (keys == "1" || keys == "2" || keys == "3" || keys == "4")
               {
                   switch (keys)
                   {
                       case "1":
                           AddName(je, action,numberJob);
                           break;
                       case "2":
                           je.Start(4);
                            break;
                        case "3":
                           ClearQueue(je, action);
                           break;
                       case "4":
                           StopJob(je, action);
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
            Console.WriteLine($"В очередь добавлено {numberJob} записей");
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
