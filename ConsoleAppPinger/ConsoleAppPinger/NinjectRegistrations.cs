using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Services;
using Ninject.Modules;

namespace ConsoleAppPinger
{
    public class NinjectRegistrations: NinjectModule
    {
        public override void Load()
        {
            Bind<IPinger>().To<Pinger>();
            Bind<IPingerConfig>().To<PingerConfig>();
            Bind<IPingerLogger>().To<PingerLogger>();
            Bind<IPingerHttp>().To<PingerHttp>();
            Bind<IPingerIcmp>().To<PingerIcmp>();
            Bind<IPingerTcp>().To<PingerTcp>();
        }
    }
}
