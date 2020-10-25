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
            if (args.Length > 1)
            {
                NinjectModule registrations = new NinjectRegistrations();
                var kernel = new StandardKernel(registrations);
                var pinger = kernel.Get<IPinger>();
                var pathAddresses = args[1];
                var pathSetting = args[2];
                //var pathAddresses = "Config/addresses.json";
                //var pathSetting = "Config/settings.json";
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                CancellationToken token;
                token = cancellationTokenSource.Token;
                pinger.Start(token, pathAddresses, pathSetting);
                Console.ReadKey();
                pinger.Stop(cancellationTokenSource);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Вы не указали параметры");
                Console.ReadKey();
            }

        }
    }
}
