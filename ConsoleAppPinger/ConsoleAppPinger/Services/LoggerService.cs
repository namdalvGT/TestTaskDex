using System;
using System.IO;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Services
{
    public class LoggerService:ILogger
    {
        public void Write(Logger itemLogger)
        {
            var statusCode = "";
            if (itemLogger.StatusCode != 0)
            {
                statusCode = itemLogger.StatusCode.ToString();
            }
            string data =$"{itemLogger.CreatedDate:dd/MM/yyyy hh:mm:ss} {itemLogger.HostName} {itemLogger.Status} {statusCode}\n";
            Save(data);
            Console.Write(data);
        }

        private void Save(string data)
        {
            try
            {
                string directory = "Logs";
                DateTime dateTime = DateTime.Now;
                string fileName = $"log_{dateTime:ddMMyyyy}";
                Directory.CreateDirectory(directory);
                string path = $"{directory}/{fileName}.txt";
                using (StreamWriter w = File.AppendText(path))
                {
                    w.WriteLine(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"error:{e.Message}");
            }
        }
    }
}
