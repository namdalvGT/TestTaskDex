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
            Console.WriteLine($"1-Добавить имена\n2-Запустить работу\n3-Очистить список\n4-Остановить работу");
            Console.WriteLine("Для запуска действия, введите цифру и нажмите ENTER...");
            controlPanel.ReaderKeys(je, action, 10);
        }

        private static void Displayed()
        {
            PersonSource ps = new PersonSource();
            Console.WriteLine($"Имя: {ps.GetPerson().Name}");
            Thread.Sleep(1000);
        }
    }
}
