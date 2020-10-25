using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;
using ConsoleAppPinger.Services;
using Moq;
using NUnit.Framework;

namespace PingerTests.Services
{
    class ProtocolTest
    {
        [Test]
        public void HttpTest()
        {
            var address = new Address()
                { HostName = "google.com",
                  Port = 80,
                  Prefix = "http",
                  Timeout = 1000,
                  Type = "Http"};
            var mockLogger = new Mock<ILogger>();
            var http = new  HttpService(mockLogger.Object);
            Assert.DoesNotThrow(() => { http.Start(address); });
        }

        [Test]
        public void TcpTests()
        {
            var address = new Address()
            {
                HostName = "google.com",
                Port = 80,
                Prefix = "http",
                Timeout = 1000,
                Type = "Tcp"
            };
            var mockLogger = new Mock<ILogger>();
            var tcpService = new TcpService(mockLogger.Object);
            Assert.DoesNotThrow(() => { tcpService.Start(address); });
        }

        [Test]
        public void IcmpTest()
        {
            var address = new Address()
            {
                HostName = "google.com",
                Port = 80,
                Prefix = "http",
                Timeout = 1000,
                Type = "Icmp"
            };
            var mockLogger = new Mock<ILogger>();
            var icmpService = new IcmpService(mockLogger.Object);
            Assert.DoesNotThrow(() => { icmpService.Start(address); });
        }
    }
}
