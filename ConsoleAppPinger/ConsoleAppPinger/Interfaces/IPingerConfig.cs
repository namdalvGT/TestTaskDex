using System;
using System.Collections.Generic;
using System.Globalization;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Interfaces
{
    public interface IPingerConfig
    {
        List<Address> GetAddresses(string filePath);

        int GetInterval(string filePath);

        void GenerateAddresses(string filePath);

        void GenerateSettings(string filePath);
    }
}
