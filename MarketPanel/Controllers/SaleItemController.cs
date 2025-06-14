
using MarketPanel.Models.ViewModels;
using MarketPanel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MarketPanel.Controllers;

public class SaleItemController : Controller
{
    private readonly ISaleItemService _saleItemService;


    public SaleItemController(ISaleItemService saleItemService)
    {
        _saleItemService = saleItemService;
    }
    public async Task<IActionResult> MySaleItems()
    {
        var model = await _saleItemService.GetAllAsync();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        //Yeni bir model olustur ve modelin Products listesine veritabanindan Product nesnesinden cektigin listesini ata.
        var model = new SaleItemViewModel()
        {
            Products = await _saleItemService.GetProductsAsync()
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(SaleItemViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Products = await _saleItemService.GetProductsAsync();
            return View(model);
        }
        try
        {
            var result = await _saleItemService.CreateAsync(model);
            if(result) return RedirectToAction("MySaleItems");
        }
        catch(Exception)
        {
            ModelState.AddModelError("", "Satış eklenirken bir hata oluştu.");
        }

        model.Products = await _saleItemService.GetProductsAsync();
        return View(model);

    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var model = await _saleItemService.GetByIdAsync(id);

        model.Products = await _saleItemService.GetProductsAsync();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SaleItemViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Products = await _saleItemService.GetProductsAsync();
            return View(model);
        }

        try
        {
            var result = await _saleItemService.UpdateAsync(model);
            if (result) return RedirectToAction("MySaleItems");
        }
        catch (Exception)
        {
            ModelState.AddModelError("", "Satış güncellenirken bir hata oluştu.");
        }

        //Update sirasinda islem hata verirse ya da basarisiz olursa
        //Update keraninda Productlarin listelenerek gelebilmesi icin:

        model.Products = await _saleItemService.GetProductsAsync();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var result = await _saleItemService.DeleteAsync(id);
            if (result) return RedirectToAction("MySaleItems");
        }
        catch(Exception)
        {
            ModelState.AddModelError("", "Satış silinirken bir hata oluştu.");
        }

        return RedirectToAction("MySaleItems");
    }
}
