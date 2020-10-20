using ConsoleAppPinger;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace PingerTests.Services
{
    [TestClass]
    public class PingerHttpTests
    {
        private StandardKernel _kernel;

        private IPingerHttp _pingerHttp;

        public PingerHttpTests()
        {
            var registrations = new NinjectRegistrations();
            _kernel = new StandardKernel(registrations);
            _pingerHttp = _kernel.Get<IPingerHttp>();
        }

        [TestMethod]
        public void Start()
        {
            var address = new Address()
            { HostName = "google.com",
              Port = 80,
              Prefix = "http",
              Timeout = 1000};
            _pingerHttp.Start(address);
        }
    }
}
