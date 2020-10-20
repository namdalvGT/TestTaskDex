using System;

namespace ConsoleAppPinger.Models
{
    public class Logger
    {
        public DateTime CreatedDate { get; set; }
        public string HostName { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
    }
}
