using System.Threading;
using ConsoleAppPinger;
using ConsoleAppPinger.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace PingerTests.Services
{
    [TestClass]
    public class PingerTests
    {
        private StandardKernel _kernel;

        private IPinger _pinger;

        public PingerTests()
        {
            var registrations = new NinjectRegistrations();
            _kernel = new StandardKernel(registrations);
            _pinger = _kernel.Get<IPinger>();
        }

        [TestMethod]
        public void StartAndStop()
        {
            _pinger.Start();
            Thread.Sleep(5000);
            _pinger.Stop();
        }
    }
}
