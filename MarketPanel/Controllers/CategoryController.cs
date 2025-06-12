using AutoMapper;
using MarketPanel.Models.Entities;
using MarketPanel.Models.ViewModels;
using MarketPanel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketPanel.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    private readonly IMapper _mapper;

    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ICategoryService categoryService, IMapper mapper, ILogger<CategoryController> logger)
    {
        _categoryService = categoryService;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<IActionResult> MyCategories()
    {
        var categories = await _categoryService.GetAllAsync();
        return View(categories);
    }

    [HttpGet] // DB den veri cekmedigim icin async gerek yok
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost] // DB ye veri yollandigi icin async calismak faydali
    public async Task<IActionResult> Add(CategoryViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        try
        {
            var category = _mapper.Map<Category>(model);

            var result = await _categoryService.CreateAsync(category);

            if (result) return RedirectToAction("MyCategories");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Kategori eklenirken bir hata oluştu.");
        }

        return View(model); // Islemin basarisiz oldugu herhangi bir durumda 
    }

    [HttpGet] // Veri tabanindan veri cektiginde async calismak daha faydali
    public async Task<IActionResult> Edit(long id)
    {
        var category = await _categoryService.GetByIdAsync(id);

        if (category == null) return NotFound();

        var model = _mapper.Map<CategoryViewModel>(category);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        try
        {
            var result = await _categoryService.UpdateAsync(model);
            if (result) return RedirectToAction("MyCategories");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Kategori güncellenirken bir sorun oldu.");
            ModelState.AddModelError("", "Kategori güncellenirken bir sorun oldu.");
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var result = await _categoryService.DeleteAsync(id);
            return RedirectToAction("MyCategories");
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Kategori silinirken bir sorun oldu!!");
            ModelState.AddModelError("", "\"Kategori silinirken bir sorun oldu!!");
        }

        return RedirectToAction("MyCategories");

    }
}
