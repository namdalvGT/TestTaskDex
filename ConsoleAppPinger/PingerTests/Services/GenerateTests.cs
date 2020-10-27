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
        public void GenerateConfig()
        {
            var generateService = new GenerateService();
            Assert.DoesNotThrow(() => { generateService.GenerateAddresses(null); });
        }
    }
}
