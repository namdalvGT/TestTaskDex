using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleAppThreadNew.Interface;

namespace ConsoleAppThreadNew.Class
{
    class JobExecutor:IJobExecutor
    {
        private Queue<Action> _queueActions = new Queue<Action>();

        private Thread[] _threads;
        public int Amount { get; set; }

        public JobExecutor()
        {
            Amount = 0;
        }
        
        public void Start(int maxConcurrent)
        {
            var tempMaxConcurrent = 0;
           
            ThreadPool.SetMaxThreads(maxConcurrent, maxConcurrent);
            ThreadPool.GetMaxThreads(out tempMaxConcurrent, out tempMaxConcurrent);
            Console.WriteLine($"Установлено максимальное количество потоков: {tempMaxConcurrent}");

            if (_queueActions.Any())
            {
                Amount = _queueActions.Count;
                _threads = new Thread[_queueActions.Count];

                for (int i = 0; i < _threads.Length; i++)
                {
                    var action = _queueActions.Dequeue();
                    _threads[i] = new Thread(new ThreadStart(action)) { Name = $"Поток: {i}" };
                    _threads[i].Start();
                    Console.WriteLine($"Поток \"{ _threads[i].Name}\" обработан");
                }
            }
            else
            {
                Console.WriteLine("Очередь задач пуста!");
            }
        }

        public void Stop()
        {
            int numberOfStopped = _threads.Length;

            foreach (var thread in _threads)
            {
                thread.Abort();
            }

            Console.WriteLine($"Обработка остановлена.Количество остановленных потоков: {numberOfStopped}");
        }

        public void Add(Action action)
        {
           _queueActions.Enqueue(action);
        }

        public void Clear()
        {
            int numberOfCleared = _queueActions.Count;
            _queueActions.Clear();
            Console.WriteLine($"Очистка очереди. Количество задач: {numberOfCleared}");

        }


        //ожидание завершения потоков

        public bool AwaitingFlow()
        {
            Console.WriteLine($"Ожидание завершения всех потоков...");
            for (int i = 0; i < _threads.Length; i++)
            {
                _threads[i].Join();
            }

            return true;
        }

    }
}
