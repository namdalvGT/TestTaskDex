using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppThreadNew.Class;

namespace ConsoleAppThreadNew
{
    class Program
    {
        static void Main(string[] args)
        {
            JobExecutor je = new JobExecutor();
            PersonSource ps = new PersonSource();
            je.Add(ps.GetPerson);
            je.Add(ps.GetPerson);
            je.Add(ps.GetPerson);
            je.Add(ps.GetPerson);
            je.Start(4);
            je.Add(ps.GetPerson);
            je.Add(ps.GetPerson);
            je.Stop();
            je.Start(5);
            je.Add(ps.GetPerson);
            je.Add(ps.GetPerson);
            je.AwaitingFlow();
            je.Clear();
            je.Stop();
            
            Console.ReadKey();
        }
        
    }
}
