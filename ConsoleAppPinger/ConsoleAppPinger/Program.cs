using System;
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
           var pinger = kernel.Get<IPinger>();
           pinger.Start();
           Console.ReadKey();
           pinger.Stop();
           Console.ReadKey();
        }
    }
}
