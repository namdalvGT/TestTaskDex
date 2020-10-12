using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConsoleAppThreadNewAsync.Interface;

namespace ConsoleAppThreadNewAsync.Class
{
    public class JobExecutor : IJobExecutor
    {
        private readonly Queue<Action> _queueActions = new Queue<Action>();
        private EventWaitHandle _eventWait = new AutoResetEvent(false);
        private CancellationTokenSource _cancellationTokenSource = null;
        private CancellationToken _token;
        private bool _run = false;

        public int Amount { get; set; }

        public void Start(int maxConcurrent)
        {
            try
            {
                if (_run)
                {
                    Console.WriteLine("Обработка уже запущена");
                    return;
                }
                _cancellationTokenSource = new CancellationTokenSource();
                _token = _cancellationTokenSource.Token;
               
                Task.Run(async () =>
                {
                    Console.WriteLine("Запущена обработка очереди");
                    Amount = _queueActions.Count;
                     _run = true;
                    _eventWait = new AutoResetEvent(false);

                    using (var semaphore = new Semaphore(maxConcurrent, maxConcurrent))
                    {
                        while (!_cancellationTokenSource.IsCancellationRequested)
                        {
                            Action action = null;
                            if (_queueActions.Any())
                            {
                                action = _queueActions.Dequeue();
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
                        _run = false;
                        Console.WriteLine($"Обработка остановлена");
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
            _run = false;
            _cancellationTokenSource.Cancel();
            Console.WriteLine("Программа остановлена");
        }

        public void Add(Action action)
        {
            try
            {
                _queueActions.Enqueue(action);
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
            _queueActions.Clear();
            Console.WriteLine($"Очистка очереди. Количество задач: {numberOfCleared}");
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
