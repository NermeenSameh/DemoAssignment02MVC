using Microsoft.AspNetCore.Mvc;

namespace DemoAssignment02MVC.Controllers
{
    public class AccontController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
