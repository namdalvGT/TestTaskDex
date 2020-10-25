using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Interfaces
{
    public interface IProtocol
    {
        void Start(Address address);
    }
}
