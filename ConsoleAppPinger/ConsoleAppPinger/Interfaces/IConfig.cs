using System.Collections.Generic;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Interfaces
{
    public interface IConfig
    {
        List<Address> GetAddresses(string filePath);

        int GetInterval(string filePath);
    }
}
