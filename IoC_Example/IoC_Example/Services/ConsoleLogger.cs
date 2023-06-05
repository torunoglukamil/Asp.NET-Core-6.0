using IoC_Example.Services.Interfaces;

namespace IoC_Example.Services
{
    public class ConsoleLogger : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine("Konsola yazıldı: " + message);
        }
    }
}
