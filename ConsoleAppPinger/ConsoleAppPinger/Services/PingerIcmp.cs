using System;
using System.Net;
using System.Net.Sockets;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Services
{
    class PingerIcmp: IPingerIcmp
    {
        private IPingerLogger _pingerLogger;

        public PingerIcmp(IPingerLogger pingerLogger)
        {
            _pingerLogger = pingerLogger;
        }

        public void Start(Address address)
        {
            var log = new Logger() { CreatedDate = DateTime.Now, HostName = address.HostName };
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

        public void SaveLog(Logger log)
        {
            _pingerLogger.Write(log);
        }
    }
}
