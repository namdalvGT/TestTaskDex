using System;
using System.Net;
using System.Net.Sockets;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Services
{
    public class IcmpService: IProtocol
    {
        private readonly ILogger _logger;

        public IcmpService(ILogger logger)
        {
            _logger = logger;
        }

        public void Start(Address address)
        {
            var log = new Logger() { HostName = address.HostName };
            try
            {
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
                var remoteEndPoint = new IPEndPoint(IPAddress.Parse(address.HostName), address.Port);
                client.ConnectAsync(remoteEndPoint).Wait(address.Timeout);
                log.Status = client.Connected ? "OK" : "FAILED";
                SaveLog(log);
            }
            catch
            {
                log.Status = "FAILED";
                SaveLog(log);
            }
        }

        private void SaveLog(Logger log)
        {
            _logger.Write(log);
        }
    }
}
