using IoC_Example.Services.Interfaces;

namespace IoC_Example.Services
{
    public class TextLogger : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine("Dosyaya yazıldı: " + message);
        }
    }
}
