using System;
using System.Threading;
using System.Threading.Tasks;
using ConsoleAppThreadNewAsync.Class;

namespace ConsoleAppThreadNewAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            JobExecutor je = new JobExecutor();
            ControlPanel controlPanel = new ControlPanel();
            Action action = new Action(Displayed);
            Console.WriteLine("Для выполнения старта, нажмите любую клавишу...");
            Console.ReadKey();
            Console.WriteLine($"1-Добавить имена\n2-Очистить список\n3-Остановить работу");
            je.Start(4);
            controlPanel.ReaderKeys(je,action,10);

        }

        private static void Displayed()
        {
            PersonSource ps = new PersonSource();
            Console.WriteLine($"Имя: {ps.GetPerson().Name}");
            Thread.Sleep(1000);
        }
    }
}
