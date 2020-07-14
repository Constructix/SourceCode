using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileDemo.Models;
using MobileDemo.Services;

namespace MobileDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMobileService _mobileService;
        public HomeController(ILogger<HomeController> logger, IMobileService mobileService)
        {
            _logger = logger;
            _mobileService = mobileService;
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                Models.Mobile newMobile = _mobileService.Add(mobile);
            }

            return View();
        }

        public IActionResult Index()
        {
            return View();
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
}
