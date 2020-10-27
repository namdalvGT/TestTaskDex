using System;
using System.Collections.Generic;
using System.Globalization;
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

            if (string.IsNullOrEmpty(filePath))
            {
                filePath = "Config/addresses.json";
            }
            string directory = filePath.Split(new char[] { '/' }).FirstOrDefault();
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(filePath))
            {
                using (StreamWriter file = File.CreateText(filePath))
                {
                    var addresses = new List<Address>();
                    addresses.Add(new Address() { HostName = "google.com", Prefix = "http", Port = 80, Timeout = 1000, Type = "Http" });
                    addresses.Add(new Address() { HostName = "ya.ru", Prefix = "http", Port = 80, Timeout = 1000, Type = "Http" });
                    addresses.Add(new Address() { HostName = "yandax.com", Prefix = "http", Port = 80, Timeout = 1000, Type = "Tcp" });
                    addresses.Add(new Address() { HostName = "habr.com", Prefix = "http", Port = 80, Timeout = 1000, Type = "Tcp" });
                    addresses.Add(new Address() { HostName = "youtube.com", Prefix = "http", Port = 80, Timeout = 1000, Type = "Tcp" });
                    addresses.Add(new Address() { HostName = "wikipedia.org", Prefix = "http", Port = 80, Timeout = 1000, Type = "Icmp" });
                    addresses.Add(new Address() { HostName = "amazon.com", Prefix = "http", Port = 80, Timeout = 1000, Type = "Icmp" });
                    addresses.Add(new Address() { HostName = "amazonul.ru", Prefix = "http", Port = 80, Timeout = 1000, Type = "Icmp" });
                    JsonSerializer ser = new JsonSerializer();
                    ser.Serialize(file, addresses);
                }
                Console.WriteLine("Файл addresses.json сгенерирован");
            }
            else
            {
                Console.WriteLine("Файл addresses.json уже существует");
            }
        }
    }
}
