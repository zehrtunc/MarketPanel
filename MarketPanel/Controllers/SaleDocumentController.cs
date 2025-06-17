using Microsoft.AspNetCore.Mvc;

namespace MarketPanel.Controllers
{
    public class SaleDocumentController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            return RedirectToAction("MySaleDocuments");
        }

    }
}
