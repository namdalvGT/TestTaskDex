using System;
using ConsoleAppPinger;
using ConsoleAppPinger.Interfaces;
using ConsoleAppPinger.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace PingerTests.Services
{
    [TestClass]
    public class PingerLoggerTests
    {
        private StandardKernel _kernel;

        private IPingerLogger _pingerLogger;

        public PingerLoggerTests()
        {
            var registrations = new NinjectRegistrations();
            _kernel = new StandardKernel(registrations);
            _pingerLogger = _kernel.Get<IPingerLogger>();
        }

        [TestMethod]
        public void Write()
        {
            var itemLogger = new Logger()
            {
                CreatedDate = DateTime.Now,
                HostName = "google.com",
                Status = "OK",
                StatusCode = 200
            };
            _pingerLogger.Write(itemLogger);

        }
    }
}
