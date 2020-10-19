using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Interfaces
{
    public interface IPingerIcmp
    {
        void Start(Address address);
        void SaveLog(Logger log);
    }
}
