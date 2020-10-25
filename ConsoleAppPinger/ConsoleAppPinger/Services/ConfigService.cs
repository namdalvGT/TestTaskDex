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
    public class ConfigService:IConfig
    {
        private readonly IGenerate _generate;

        public ConfigService(IGenerate generate)
        {
            _generate = generate;
        }

        public List<Address> GetAddresses(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    _generate.GenerateAddresses(filePath);
                }
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
                if (!File.Exists(filePath))
                {
                    _generate.GenerateSettings(filePath);
                }
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
    }
}
