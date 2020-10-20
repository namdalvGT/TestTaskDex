using ConsoleAppPinger;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace PingerTests.Services
{
    [TestClass]
    public class PingerTcpTests
    {
        private StandardKernel _kernel;

        private IPingerTcp _pingerTcp;

        public PingerTcpTests()
        {
            var registrations = new NinjectRegistrations();
            _kernel = new StandardKernel(registrations);
            _pingerTcp = _kernel.Get<IPingerTcp>();
        }

        [TestMethod]
        public void Start()
        {
            var address = new Address()
            {
                HostName = "google.com",
                Port = 80,
                Prefix = "http",
                Timeout = 1000
            };
            _pingerTcp.Start(address);
        }
    }
}
