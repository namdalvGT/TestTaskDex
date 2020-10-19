using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPinger.Models
{
    public class Address
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }
        public string Prefix { get; set; }
    }
}
