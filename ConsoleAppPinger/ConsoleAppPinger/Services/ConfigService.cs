using System;
using System.Collections.Generic;
using System.IO;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;
using Nancy.Json;

namespace ConsoleAppPinger.Services
{
    public class ConfigService:IConfig
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
    }
}
