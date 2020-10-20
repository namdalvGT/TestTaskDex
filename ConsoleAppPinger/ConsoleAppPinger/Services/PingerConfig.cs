using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;
using Nancy.Json;
using Newtonsoft.Json;

namespace ConsoleAppPinger.Services
{
    class PingerConfig:IPingerConfig
    {
        public List<Address> GetAddresses(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    return ser.Deserialize<List<Address>>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"error:{e.Message}");
                return null;;
            }
        }
        public int GetInterval(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    var settings = ser.Deserialize<Setting>(json);
                    return settings.Interval;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"error:{e.Message}");
                return 0;
            }
        }
        public void GenerateAddresses(string filePath)
        {
            string directory = filePath.Split(new char[] { '/' }).FirstOrDefault();
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (File.Exists(filePath))
            {
                throw new Exception($"File by path:{filePath} exists ");
            }
            
            using (StreamWriter file = File.CreateText(filePath))
            {
                var adresses = new List<Address>();
                adresses.Add(new Address() { HostName = "google.com", Prefix = "http", Port = 80, Timeout = 1000 });
                adresses.Add(new Address() { HostName = "ya.ru", Prefix = "http", Port = 80, Timeout = 1000 });
                adresses.Add(new Address() { HostName = "yandax.com", Prefix = "http", Port = 80, Timeout = 1000 });
                adresses.Add(new Address() { HostName = "habr.com", Prefix = "http", Port = 80, Timeout = 1000 });
                adresses.Add(new Address() { HostName = "youtube.com", Prefix = "http", Port = 80, Timeout = 1000 });
                adresses.Add(new Address() { HostName = "wikipedia.org", Prefix = "http", Port = 80, Timeout = 1000 });
                adresses.Add(new Address() { HostName = "amazon.com", Prefix = "http", Port = 80, Timeout = 1000 });
                adresses.Add(new Address() { HostName = "amazonul.ru", Prefix = "http", Port = 80, Timeout = 1000 });
                JsonSerializer ser = new JsonSerializer();
                ser.Serialize(file,adresses);
            }
        }
        public void GenerateSettings(string filePath)
        {
            string directory = filePath.Split(new char[] { '/' }).FirstOrDefault();
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (File.Exists(filePath))
            {
                throw new Exception($"File by path:{filePath} exists ");
            }

            using (StreamWriter file = File.CreateText(filePath))
            {
                var setting = new Setting(){Interval = 100};
                JsonSerializer ser = new JsonSerializer();
                ser.Serialize(file, setting);
            }
        }
    }
}
