using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppThread_Task2_14
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 50;
            Main main = new Main();
            main.Add(new Action(main.Generate));
            Console.ReadKey();
            main.Start(count);
            Console.ReadKey();
            main.Add(new Action(main.Generate));
            main.Start(count);
            Console.ReadKey();



        }
    }


    class Main:IJobExecutor,INotifyPropertyChanged
    {

        public ConcurrentDictionary<int,string> Tasks = new ConcurrentDictionary<int, string>();
        public ConcurrentDictionary<int, string> tasks
        {
            get { return Tasks; }
            set
            {
                Tasks = value;
                OnPropertyChanged("tasks");


            }
        }

        
      


        public CancellationTokenSource cts = new CancellationTokenSource();

        public int Amount => tasks.Count;

        public void Start(int maxConcurrent)
        {
            cts = new CancellationTokenSource();
            try
            {
                while (true)
                {
                    //-----------------------------------------
                    var options = new ParallelOptions() { MaxDegreeOfParallelism = maxConcurrent, CancellationToken = cts.Token };

                    ParallelLoopResult result = Parallel.ForEach(tasks.ToList(), options, item =>
                    {
                        Console.WriteLine($"Обработка записи:{item.Key}-{item.Value}");
                        Thread.Sleep(TimeSpan.FromSeconds(10).Milliseconds);
                        
                        options.CancellationToken.ThrowIfCancellationRequested();

                    });

                    if (result.IsCompleted)
                    {
                        Clear();
                        Stop();
                        Console.WriteLine($"Все записи обработаны");
                    }
                    

                    Thread.Sleep(TimeSpan.FromSeconds(2).Milliseconds);
                }
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
                
            }
            finally
            {
                cts.Dispose();
            }
            
        }


        public void Stop()
        {
            cts.Cancel();
            
            Console.WriteLine($"Отправлена команда остановки");
        }


        public void Add(Action action)
        {
            Task.Run(action);
            Console.WriteLine($"Сгенерирован новый массив");

        }


        public void  Generate()
        {
                for (int i = 0; i < 10; i++)
                {
                    tasks.TryAdd(i + 2, $"Значение {i}");
                }

        }


        public void Clear()
        {
            tasks.Clear();
            Console.WriteLine("Задачи очищены");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public interface IJobExecutor
    {
        /// Кол-во задач в очереди на обработку
        int Amount { get; }
        /// <summary>
        /// Запустить обработку очереди и установить максимальное кол-во
        //параллельных задач
        /// </summary>
        /// <param name="maxConcurrent">максимальное кол-во одновременно
       // выполняемых задач</param>
        void Start(int maxConcurrent);
        /// <summary>
        /// Остановить обработку очереди и выполнять задачи
        /// </summary>
        void Stop();
        /// <summary>
        /// Добавить задачу в очередь
        /// </summary>
        /// <param name="action"></param>
        void Add(Action action);
        /// <summary>
        /// Очистить очередь задач
        /// </summary>
        void Clear();
    }

}
