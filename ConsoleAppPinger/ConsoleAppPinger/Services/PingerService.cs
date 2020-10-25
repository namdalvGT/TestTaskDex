using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConsoleAppPinger.Interfaces;

namespace ConsoleAppPinger.Services
{
    public class PingerService: IPinger
    {
        private readonly IConfig _config;
        private readonly IProtocol[] _protocols;
        public PingerService(IConfig config,
                             IProtocol[] protocols)
        {
            _config = config;
            _protocols = protocols;
        }
        public  void Start(CancellationToken token,string pathAddresses,string pathSetting)
        {
            try
            {
                Task.Run(() =>
                {
                    var addresses = _config.GetAddresses(pathAddresses);
                    var interval = _config.GetInterval(pathSetting);
                    while (!token.IsCancellationRequested)
                    {
                        foreach (var protocol in _protocols)
                        {
                            var  typeProtocol = GetTypeProtocol(protocol.GetType().Name);
                            if (typeProtocol != null)
                            {
                                foreach (var itemAddress in addresses.Where(x => x.Type == typeProtocol))
                                {
                                    if (token.IsCancellationRequested)
                                    {
                                        Console.WriteLine("Pinger остановлен");
                                        break;
                                    }
                                    protocol.Start(itemAddress);
                                    Thread.Sleep(interval);
                                }
                            }
                            else
                            {
                                throw new Exception("typeProtocol not exists");
                            }
                        }
                    }
                }, token);
            }
            catch (Exception e)
            {
               Console.WriteLine($"error:{e.Message}");
            }
        }

        public  void Stop(CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.Cancel();
        }

        private string GetTypeProtocol(string nameClass)
        {
            switch (nameClass)
            {
                case "HttpService":
                    return "Http";
                case "TcpService":
                    return "Tcp";
                case "IcmpService":
                    return "Icmp";
            }

            return null;
        }
    }
}
