using System;
using System.Net.Sockets;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Services
{
    class PingerTcp:IPingerTcp
    {
        private IPingerLogger _pingerLogger;
        public PingerTcp(IPingerLogger pingerLogger)
        {
            _pingerLogger = pingerLogger;
        }

        public void Start(Address address)
        {
            var log = new Logger() { CreatedDate = DateTime.Now, HostName = address.HostName };
            TcpClient client = new TcpClient();
            try
            {
                var result = client.BeginConnect(address.HostName, address.Port,null,null);
                var success = result.AsyncWaitHandle.WaitOne(address.Timeout);
                log.Status = success ? "OK" : "FAILED";
                SaveLog(log);
                client.EndConnect(result);
            }
            catch
            {
                log.Status = "FAILED";
                SaveLog(log);
            }
            finally
            {
                client.Close();
            }
        }
       
        public void SaveLog(Logger log)
        {
           _pingerLogger.Write(log);
        }
    }
}
