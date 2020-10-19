using System;
using System.Threading;
using System.Threading.Tasks;
using ConsoleAppPinger.Interfaces;

namespace ConsoleAppPinger.Services
{
    public class Pinger: IPinger
    {
        private IPingerConfig _config;
        private IPingerHttp _pingerHttp;
        private IPingerTcp _pingerTcp;
        private IPingerIcmp _pingerIcmp;

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _token;
        public Pinger(IPingerConfig config,
                      IPingerHttp pingerHttp,
                      IPingerTcp pingerTcp,
                      IPingerIcmp pingerIcmp)
        {
            _config = config;
            _pingerHttp = pingerHttp;
            _pingerTcp = pingerTcp;
            _pingerIcmp = pingerIcmp;
        }
        public void Start()
        {
            try
            {
                var pathAddresses = "Config/addresses.json";
                var pathSetting = "Config/settings.json";
                _cancellationTokenSource = new CancellationTokenSource();
                _token = _cancellationTokenSource.Token;
                var addresses = _config.GetAddresses(pathAddresses);
                Task.Run(() =>
                {
                    while (!_token.IsCancellationRequested)
                    {
                        foreach (var itemAddress in addresses)
                        {
                            if (_token.IsCancellationRequested)
                            {
                                Console.WriteLine("Pinger остановлен");
                                break;
                            }
                            _pingerHttp.Start(itemAddress);
                            _pingerTcp.Start(itemAddress);
                            _pingerIcmp.Start(itemAddress);
                            Thread.Sleep(_config.GetInterval(pathSetting));
                        }
                    }
                }, _token);
            }
            catch (Exception e)
            {
               Console.WriteLine($"error:{e.Message}");
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
