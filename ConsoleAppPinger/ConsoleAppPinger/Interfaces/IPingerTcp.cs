using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Interfaces
{
    public interface IPingerTcp
    {
        void Start(Address address);
        void SaveLog(Logger log);
    }
}
