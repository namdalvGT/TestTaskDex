using System.Threading;

namespace ConsoleAppPinger.Interfaces
{
    public interface IPinger
    {
        void Start(CancellationToken token, string pathAddresses, string pathSetting);
        void Stop(CancellationTokenSource cancellationTokenSource);
    }
}
