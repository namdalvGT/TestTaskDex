using System;
using System.Threading;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;
using ConsoleAppPinger.Services;
using Ninject;
using Ninject.Modules;

namespace ConsoleAppPinger
{
    class Program
    {
        static void Main(string[] args)
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            if (args.Length>0)
            {
                var pinger = kernel.Get<IPinger>();
                var pathAddresses = args[0];
                var addresses = kernel.Get<IConfig>().GetAddresses(pathAddresses);
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                CancellationToken token;
                token = cancellationTokenSource.Token;
                pinger.Start(token, addresses);
                Console.ReadKey();
                pinger.Stop(cancellationTokenSource);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Вы не указали параметры. Файлы конфигураций.");
                ConsoleKey response;
                do
                {
                    Console.Write("Хотите сгенерировать? [y/n] ");
                    response = Console.ReadKey(false).Key; // true is intercept key (dont show), false is show
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();
                } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                bool confirmed = response == ConsoleKey.Y;
                if (confirmed)
                {
                    kernel.Get<IGenerate>().GenerateAddresses(null);
                }
                Console.ReadKey();
                Console.ReadKey();
            }
        }
    }
}
