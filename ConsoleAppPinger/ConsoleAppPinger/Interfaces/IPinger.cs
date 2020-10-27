using System.Collections.Generic;
using System.Threading;
using ConsoleAppPinger.Models;

namespace ConsoleAppPinger.Interfaces
{
    public interface IPinger
    {
        void Start(CancellationToken token,List<Address> addresses);
        void Stop(CancellationTokenSource cancellationTokenSource);
    }
}
