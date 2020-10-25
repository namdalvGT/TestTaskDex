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
            Bind<IPinger>().To<PingerService>();
            Bind<IConfig>().To<ConfigService>();
            Bind<IGenerate>().To<GenerateService>();
            Bind<ILogger>().To<LoggerService>();
            Bind<IProtocol>().To<HttpService>();
            Bind<IProtocol>().To<TcpService>();
            Bind<IProtocol>().To<IcmpService>();
        }
    }
}
