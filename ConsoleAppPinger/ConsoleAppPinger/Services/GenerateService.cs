using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;
using Newtonsoft.Json;

namespace ConsoleAppPinger.Services
{
    public class GenerateService:IGenerate
    {
        public void GenerateAddresses(string filePath)
        {
            string directory = filePath.Split(new char[] { '/' }).FirstOrDefault();
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (StreamWriter file = File.CreateText(filePath))
            {
                var adresses = new List<Address>();
                adresses.Add(new Address() { HostName = "google.com", Prefix = "http", Port = 80, Timeout = 1000, Type = "Http" });
                adresses.Add(new Address() { HostName = "ya.ru", Prefix = "http", Port = 80, Timeout = 1000, Type = "Http" });
                adresses.Add(new Address() { HostName = "yandax.com", Prefix = "http", Port = 80, Timeout = 1000, Type = "Tcp" });
                adresses.Add(new Address() { HostName = "habr.com", Prefix = "http", Port = 80, Timeout = 1000, Type = "Tcp" });
                adresses.Add(new Address() { HostName = "youtube.com", Prefix = "http", Port = 80, Timeout = 1000, Type = "Tcp" });
                adresses.Add(new Address() { HostName = "wikipedia.org", Prefix = "http", Port = 80, Timeout = 1000, Type = "Icmp" });
                adresses.Add(new Address() { HostName = "amazon.com", Prefix = "http", Port = 80, Timeout = 1000, Type = "Icmp" });
                adresses.Add(new Address() { HostName = "amazonul.ru", Prefix = "http", Port = 80, Timeout = 1000, Type = "Icmp" });
                JsonSerializer ser = new JsonSerializer();
                ser.Serialize(file, adresses);
            }
        }

        public void GenerateSettings(string filePath)
        {
            string directory = filePath.Split(new char[] { '/' }).FirstOrDefault();
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (StreamWriter file = File.CreateText(filePath))
            {
                var setting = new Setting() { Interval = 100 };
                JsonSerializer ser = new JsonSerializer();
                ser.Serialize(file, setting);
            }
        }
    }
}
