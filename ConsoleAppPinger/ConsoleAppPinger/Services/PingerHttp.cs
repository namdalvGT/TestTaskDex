using System;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Services
{
    class PingerHttp:IPingerHttp
    {
        private IPingerLogger _pingerLogger;
        public PingerHttp(IPingerLogger pingerLogger)
        {
            _pingerLogger = pingerLogger;
        }

        public void Start(Address address)
        {
            var log = new Logger() { CreatedDate = DateTime.Now, HostName = address.HostName };
            try
            {
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(address.Timeout);
                string urlSite = $"{address.Prefix}://{address.HostName}/";
                client.GetAsync(urlSite).ContinueWith(responseTask =>
                {
                    CheckConnection(responseTask, log, client);
                });
            }
            catch 
            {
                log.Status = "FAILED";
                SaveLog(log);
            }
        }

        public void CheckConnection(Task<HttpResponseMessage> responseTask,Logger log,HttpClient client)
        {
            try
            {
                var result = responseTask.Result;
                log.Status = result.ReasonPhrase;
                log.StatusCode = (int)result.StatusCode;
                client.Dispose();
                responseTask.Dispose();
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
