using System.IO;
using System.Security.Cryptography.X509Certificates;
using ConsoleAppPinger;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Services;
using Moq;
using Ninject;
using NUnit.Framework;

namespace PingerTests.Services
{
    public class ConfigTests
    {
        [Test]
        public void GetAddresses()
        {
            var filePath = "ConfigTest/addressesTest.json";
            var configService = new ConfigService();
            Assert.IsNotNull(configService.GetAddresses(filePath));
        }
    }
}
