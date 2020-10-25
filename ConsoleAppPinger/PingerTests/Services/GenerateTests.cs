using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConsoleAppPinger.Services;
using NUnit.Framework;

namespace PingerTests.Services
{
    public class GenerateTests
    {
        [Test]
        public void GenerateAddresses()
        {
            var filePath = "ConfigTest/addressesTest.json";
            var generateService = new GenerateService();
            Assert.DoesNotThrow(() => { generateService.GenerateAddresses(filePath); });
        }

        [Test]
        public void GenerateSettings()
        {
            var filePath = "ConfigTest/settingsTest.json";
            var generateService = new GenerateService();
            Assert.DoesNotThrow(() => { generateService.GenerateSettings(filePath); });
        }
    }
}
