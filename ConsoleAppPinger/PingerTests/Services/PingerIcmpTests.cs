using ConsoleAppPinger;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace PingerTests.Services
{
    [TestClass]
    public class PingerIcmpTests
    {
        private StandardKernel _kernel;

        private IPingerIcmp _pingerIcmp;

        public PingerIcmpTests()
        {
            var registrations = new NinjectRegistrations();
            _kernel = new StandardKernel(registrations);
            _pingerIcmp = _kernel.Get<IPingerIcmp>();
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
            _pingerIcmp.Start(address);
        }
    }
}
