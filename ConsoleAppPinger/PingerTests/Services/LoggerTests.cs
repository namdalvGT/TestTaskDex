using System;
using ConsoleAppPinger;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;
using ConsoleAppPinger.Services;
using Moq;
using Ninject;
using NUnit.Framework;

namespace PingerTests.Services
{
    public class LoggerTests
    {
        [Test]
        public void Write()
        {
            var itemLogger = new Logger()
            {
                HostName = "google.com",
                Status = "OK",
                StatusCode = 200
            };
            var loggerService = new LoggerService();
            loggerService.Write(itemLogger);

        }
    }
}
