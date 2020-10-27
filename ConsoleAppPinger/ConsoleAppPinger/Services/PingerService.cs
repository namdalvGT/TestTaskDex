using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Services
{
    public class PingerService: IPinger
    {
        private readonly IProtocol[] _protocols;
        public PingerService(IProtocol[] protocols)
        {
            _protocols = protocols;
        }
        public  void Start(CancellationToken token,List<Address> addresses)
        {
            try
            {
                Task.Run(() =>
                {
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
                                    Thread.Sleep(itemAddress.Timeout);
                                }
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

        public void Stop(CancellationTokenSource cancellationTokenSource)
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
