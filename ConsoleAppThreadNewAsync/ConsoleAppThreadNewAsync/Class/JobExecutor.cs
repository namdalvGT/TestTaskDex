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
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken _token;

        public int Amount { get; set; }

        public void Start(int maxConcurrent)
        {
            try
            {
                _token = _cancellationTokenSource.Token;
                Task.Run(async () =>
                {
                    lock (_locked)
                    {
                        Amount = _queueActions.Count;
                    }

                    _run = true;
                    _eventWait = new AutoResetEvent(false);

                    using (var semaphore = new Semaphore(maxConcurrent, maxConcurrent))
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
                                await Processing(action, semaphore);
                            }
                            else
                            {
                                _eventWait.WaitOne();
                            }
                        }
                        Console.WriteLine($"Задачи обработаны. Количество обработанных {Amount}");
                    }
                }, _token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
            Console.WriteLine("Программа остановлена");
        }

        public void Add(Action action)
        {
            try
            {
                _token.ThrowIfCancellationRequested();
                lock (_locked)
                {
                    _queueActions.Enqueue(action);
                }
                _eventWait.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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

        private async Task Processing(Action action, Semaphore semaphore)
        {
            semaphore.WaitOne();
            try
            {
                await Task.Run(action, _token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _eventWait.Set();
                semaphore.Release();
            }
        }
    }
}
