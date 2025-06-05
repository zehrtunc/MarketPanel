using Microsoft.AspNetCore.Mvc;

namespace MarketPanel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
