using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Interfaces
{
    public interface IPingerLogger
    {
        void Write(Logger itemLogger);

        void Save(string data);
    }
}
