using MarketPanel.Models.ViewModels;
using MarketPanel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketPanel.Controllers
{
    public class SaleDocumentController : Controller
    {
        private readonly ISaleDocumentService _saleDocumentService;

        public SaleDocumentController(ISaleDocumentService saleDocumentService)
        {
            _saleDocumentService = saleDocumentService;
        }

        public async Task<IActionResult> MySaleDocuments()
        {
            var model = await _saleDocumentService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new SaleDocumentAddViewModel
            {
                SaleItemIds = new List<long>() // null olmamasi icin bos liste 
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaleDocumentAddViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var result = await _saleDocumentService.CreateAsync(model);
                if (result) return RedirectToAction("MySaleDocuments");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Satış evrağı oluşturulurken bir hata oluştu.");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var model = await _saleDocumentService.GetByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaleDocumentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var result = await _saleDocumentService.UpdateAsync(model);
                if (result) return RedirectToAction("MySaleDocuments");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Satış evrağı güncellenirken bir hata oluştu.");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _saleDocumentService.DeleteAsync(id);
                if (result) return RedirectToAction("MySaleDocuments");
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Satış evrağı silinirken bir hata oluştu.");
            }

            return RedirectToAction("MySaleDocuments");
        }

    }
}
