using System;
using ConsoleAppThreadNewAsync.Class;

namespace ConsoleAppThreadNewAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            JobExecutor je = new JobExecutor();

            Action action = new Action(Displayed);
            je.Add(action);
            je.Add(action);
            je.Add(action);
            je.Add(action);
            je.Start(4);
            je.Add(action);
            je.Add(action);
            je.Stop();
            je.Start(5);
            je.Add(action);
            je.Add(action);
            je.Clear();
            je.Stop();

            Console.ReadKey();
        }


        public static void Displayed()
        {
            PersonSource ps = new PersonSource();
            Console.WriteLine($"Имя: {ps.GetPerson().Name}");

        }

    }
}
