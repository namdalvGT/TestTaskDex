using System.Threading;
using ConsoleAppPinger;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Services;
using Moq;
using Ninject;
using NUnit.Framework;

namespace PingerTests.Services
{
    public class PingerTests
    {
        [Test]
        public void StartAndStop()
        {
            var pathAddresses = "ConfigTest/addressesTest.json";
            var pathSettings = "ConfigTest/settingsTest.json";
            CancellationTokenSource  cancellationToken = new CancellationTokenSource();
            var mockConfig = new Mock<IConfig>();
            var mockProtocols = new Mock<IProtocol>();
            var pingerService = new PingerService(mockConfig.Object, new[] {mockProtocols.Object});
            Assert.DoesNotThrow(() => { pingerService.Start(cancellationToken.Token, pathAddresses, pathSettings); });
            Thread.Sleep(5000);
            Assert.DoesNotThrow(() => { pingerService.Stop(cancellationToken);});
        }
    }
}
