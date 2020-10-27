using System;

namespace ConsoleAppPinger.Models
{
    public class Logger
    {
        public DateTime CreatedDate => DateTime.Now;
        public string HostName { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
    }
}
