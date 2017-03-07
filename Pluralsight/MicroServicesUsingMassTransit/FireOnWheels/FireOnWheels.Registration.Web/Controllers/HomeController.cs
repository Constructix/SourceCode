using FireOnWheels.Registration.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FireOnWheels.Registration.Web.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegisterOrder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterOrder(OverViewModel model)
        {
            return View("Thanks");
        }

    }
}