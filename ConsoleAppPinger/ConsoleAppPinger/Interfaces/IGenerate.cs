using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPinger.Interfaces
{
    public interface IGenerate
    {
        void GenerateAddresses(string filePath);
        void GenerateSettings(string filePath);
    }
}
