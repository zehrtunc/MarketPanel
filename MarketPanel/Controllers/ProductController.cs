using AutoMapper;
using MarketPanel.Data;
using MarketPanel.Models.Entities;
using MarketPanel.Models.ViewModels;
using MarketPanel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MarketPanel.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public ProductController(IProductService productService, IMapper mapper, ApplicationDbContext context)
    {
        _productService = productService;
        _mapper = mapper;
        _context = context;
    }

    public async Task<IActionResult> MyProducts()
    {
        var products = await _productService.GetAllAsync();

        return View(products);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var model = new ProductViewModel()
        {
            Categories = _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductViewModel model)
    {
        if(!ModelState.IsValid)
        {
            // Model gecersizse form kullaicinin onune getirilir mevcut kategorileri dropdownda dolu sekilde getirmesi icin:
            model.Categories = _context.Categories.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            return View(model);
        }

        try
        {
            var product = _mapper.Map<Product>(model);

            var result = await _productService.CreateAsync(product); // buradan boolean bir deger gelecek(servis metodu bool deger donecek)
            if (result) return RedirectToAction("MyProducts");
        }
        catch(Exception)
        {
            ModelState.AddModelError("", "Ürün eklenirken bir hata oluştu");
        }

        // Kayit sirasinda hata veya kayit basarisizsa form tekrar kullaniciya gosterilir,
        // formda dropdown dolu olmasi icin:
        model.Categories = _context.Categories.Select(c => new SelectListItem()
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null) return NotFound();

        var model = _mapper.Map<ProductViewModel>(product);

        model.Categories = _context.Categories.Select(c => new SelectListItem()
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = _context.Categories.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            return View(model);
        }

        try
        {
            var result = await _productService.UpdateAsync(model);

            if (result) return RedirectToAction("MyProducts");
        }
        catch(Exception)
        {
            ModelState.AddModelError("", "Ürün güncellenirken bir hata oluştu.");
        }
        

        //Update sirasinda islem hata verirse ya da basarisiz olursa
        //Update keraninda Categorylerin listelenerek gelebilmesi icin:

        model.Categories = _context.Categories.Select(c => new SelectListItem()
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();

        return View(model);

    }

    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var result = await _productService.DeleteAsync(id);

            return RedirectToAction("MyProducts");
        }
        catch(Exception)
        {
            ModelState.AddModelError("", "Ürün silinirken bir hata oluştu.");
        }

        return RedirectToAction("MyProducts");
    }
}
