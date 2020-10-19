using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Interfaces
{
    interface IPingerLogger
    {
        void Write(Logger itemLogger);

        void Save(string data);
    }
}
