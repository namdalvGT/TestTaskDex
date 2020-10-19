using System.Net.Http;
using System.Threading.Tasks;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Interfaces
{
    public interface IPingerHttp
    {
        void Start(Address address);

        void CheckConnection(Task<HttpResponseMessage> responseTask, Logger log, HttpClient client);

        void SaveLog(Logger log);
    }
}
