using System;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Services
{
    public class HttpService:IProtocol
    {
        private readonly ILogger _logger;
        public HttpService(ILogger logger)
        {
            _logger = logger;
        }

        public void Start(Address address)
        {
            var log = new Logger() { HostName = address.HostName };
            try
            {
                HttpClient client = new HttpClient {Timeout = TimeSpan.FromSeconds(address.Timeout)};
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

        private void CheckConnection(Task<HttpResponseMessage> responseTask,Logger log,HttpClient client)
        {
            HttpResponseMessage result ;
            try
            {
                result = responseTask.Result;
                var statusCode = (int)result.StatusCode;
                if (statusCode == 200)
                {
                    log.Status = result.ReasonPhrase;
                    log.StatusCode = (int)result.StatusCode;
                }
                else
                {
                    log.Status = "FAILED";
                }
            }
            catch
            {
                log.Status = "FAILED";
            }
            finally
            {
                client.Dispose();
                responseTask.Dispose();
                SaveLog(log);
            }
        }

        private void SaveLog(Logger log)
        {
            _logger.Write(log);
        }
    }
}
