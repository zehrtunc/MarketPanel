using AutoMapper;
using AutoMapper.QueryableExtensions;
using MarketPanel.Data;
using MarketPanel.Models.Entities;
using MarketPanel.Models.ViewModels;
using MarketPanel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPanel.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CategoryService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CategoryViewModel>> GetAllAsync()
    {
        var categories = await _context.Categories
            .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return categories;
    }

    public async Task<Category> GetByIdAsync(long id)
    {
        var category = await _context.Categories.FindAsync(id);

        return category;
    }

    public async Task<bool> CreateAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(CategoryViewModel model)
    {

        var category = await _context.Categories.FindAsync(model.Id);
        if (category == null) throw new Exception("Güncellenmek istenilen kategori bulunamadı.");

        _mapper.Map(model, category);

        await _context.SaveChangesAsync();

        return true;

    }

    public async Task<bool> DeleteAsync(long id)
    {

        var category = await _context.Categories.FindAsync(id);

        if (category == null) throw new Exception("Silmek istenilen kategori bulunamadı.");

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return true;

    }
}
