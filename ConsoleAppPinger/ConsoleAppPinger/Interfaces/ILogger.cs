using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Interfaces
{
    public interface ILogger
    {
        void Write(Logger itemLogger);

        void Save(string data);
    }
}
