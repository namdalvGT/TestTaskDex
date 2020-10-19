using Ninject;

namespace ConsoleAppPinger.Interfaces
{
    public interface IPinger
    {
        void Start();

        void Stop();
    }
}
