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
            var mockGenerate = new Mock<IGenerate>();
            var configService = new ConfigService(mockGenerate.Object);
            Assert.IsNotNull(configService.GetAddresses(filePath));
        }

        [Test]
        public void GetInterval()
        {
            var filePath = "ConfigTest/settingsTest.json";
            var mockGenerate = new Mock<IGenerate>();
            var configService = new ConfigService(mockGenerate.Object);
            var interval = configService.GetInterval(filePath);
            Assert.IsTrue(interval > 0);
        }
    }
}
