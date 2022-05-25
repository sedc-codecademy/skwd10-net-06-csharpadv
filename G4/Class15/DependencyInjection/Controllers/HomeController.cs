using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    using Services;

    public class HomeController : Controller
    {
        private IWelcomeService _welcomeService;

        // all of the controllers in an MVC application are by default added to
        // the dependency injection container. This means if you add
        // a parameter in the controller constructor of type that's already
        // registered in Startup.cs/ConfigureServices (e.g. IWelcomeService
        // having a WelcomeService1 instance type registered), on controller
        // creation, an instance of the registered implementation will be
        // "injected" automatically. This allows you to capture the injected
        // instance to a private field (see _welcomeService) and use it in
        // your controller methods.
        // You can't really mess this up since the application startup will
        // fail if there's no proper instance registered for the given (interface)
        // dependency
        public HomeController(IWelcomeService welcomeService)
        {
            _welcomeService = welcomeService;
        }

        public IActionResult Index()
        {
            WelcomeContent model = new WelcomeContent();

            model.WelcomeMessage = _welcomeService.GetWelcomeMessage();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class WelcomeContent
    {
        public string WelcomeMessage { get; set; }
    }
}
