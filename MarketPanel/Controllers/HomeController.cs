using MarketPanel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketPanel.Controllers;

public class HomeController : Controller
{
    private readonly IHomeService _homeService;

    public HomeController(IHomeService homeService)
    {
        _homeService = homeService;
    }
    public async Task<IActionResult> Index()
    {
        var model = await _homeService.GetDatasAsync();
        return View(model);
    }
}
