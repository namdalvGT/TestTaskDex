using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleAppThreadNewAsync.Interface;

namespace ConsoleAppThreadNewAsync.Class
{
    public class JobExecutor : IJobExecutor
    {
        private Queue<Action> _queueActions = new Queue<Action>();
        private EventWaitHandle _eventWait = new AutoResetEvent(false);
        private bool _run = false;
        private object _locked = new object();
        private Task _currentTask = null;
        private Semaphore _semaphore;

        public int Amount { get; set; }

        public  void  Start(int maxConcurrent)
        {
            _currentTask =Task.Run(() =>
            {
                lock (_locked)
                {
                    Amount = _queueActions.Count;
                }

                _run = true;
                _eventWait = new AutoResetEvent(false);

                using (_semaphore = new Semaphore(maxConcurrent, maxConcurrent))
                {
                    while (_run)
                    {
                        Action action = null;
                        lock (_locked)
                        {
                            if (_queueActions.Any())
                            {
                                action = _queueActions.Dequeue();
                            }
                        }

                        if (action != null)
                        {
                            Processing(action);
                        }
                        else
                        {
                            _eventWait.WaitOne();
                        }
                    }
                    Console.WriteLine($"Задачи обработаны. Количество обработанных {Amount}");
                }
            });
        }

        public void Stop()
        {
            lock (_locked)
            {
                if (_run)
                {
                    Console.WriteLine("Выполняется остановка...");
                }
            }
            _currentTask.Wait(5000);
            _run = false;
            _eventWait.Set();
            Console.WriteLine("Остановка выполнена");
        }

        public void Add(Action action)
        {
            lock (_locked)
            {
                _queueActions.Enqueue(action);
            }
            _eventWait.Set();
        }

        public void Clear()
        {
            int numberOfCleared = _queueActions.Count;
            lock (_locked)
            {
                _queueActions.Clear();
                Console.WriteLine($"Очистка очереди. Количество задач: {numberOfCleared}");
            }
            _eventWait.Set();
            Console.WriteLine("Очистка выполнена");
        }

        private async void Processing(Action action)
        {
            _semaphore.WaitOne();
            try
            {
                await Task.Run(action);
                Console.WriteLine($" ID Потока -  { Thread.CurrentThread.ManagedThreadId}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _eventWait.Set();
                _semaphore.Release();
            }
        }

    }
}
