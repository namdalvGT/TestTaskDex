using System.Collections.Generic;
using System.Threading;
using ConsoleAppPinger;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;
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
            var addresses = new List<Address>();
            addresses.Add(new Address() { HostName = "google.com", Prefix = "http", Port = 80, Timeout = 1000, Type = "Http" });
            addresses.Add(new Address() { HostName = "ya.ru", Prefix = "http", Port = 80, Timeout = 1000, Type = "Http" });
            CancellationTokenSource  cancellationToken = new CancellationTokenSource();
            var mockProtocols = new Mock<IProtocol>();
            var pingerService = new PingerService(new[] {mockProtocols.Object});
            Assert.DoesNotThrow(() => { pingerService.Start(cancellationToken.Token, addresses); });
            Thread.Sleep(5000);
            Assert.DoesNotThrow(() => { pingerService.Stop(cancellationToken);});
        }
    }
}
