using IoC_Example.Services;
using IoC_Example.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IoC_Example.Controllers
{
    public class HomeController : Controller
    {
        //ConsoleLogger _consoleLogger;

        //public HomeController(ConsoleLogger consoleLogger)
        //{
        //    _consoleLogger = consoleLogger;
        //}

        ILog _log;

        public HomeController(ILog log)
        {
            _log = log;
        }

        public string Index()
        {
            //ConsoleLogger consoleLogger = new ConsoleLogger();
            //consoleLogger.Log("Yeni bir istek geldi.");

            //_consoleLogger.Log("Yeni bir istek geldi.");

            _log.Log("Log kayıt edildi.");
            return "Service Running";
        }
    }
}
