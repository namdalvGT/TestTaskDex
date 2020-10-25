namespace ConsoleAppPinger.Models
{
    public class Address
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }
        public string Prefix { get; set; }
        public string Type { get; set; }
    }
}
