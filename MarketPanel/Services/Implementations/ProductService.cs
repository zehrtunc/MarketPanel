using AutoMapper;
using MarketPanel.Data;
using MarketPanel.Mapper;
using MarketPanel.Models.Entities;
using MarketPanel.Models.ViewModels;
using MarketPanel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPanel.Services.Implementations;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProductService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task<Product> GetByIdAsync(long id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
        return product;
    }

    public async Task<bool> CreateAsync(Product product)
    {
        try 
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<bool> UpdateAsync(ProductViewModel model)
    {
        var product = await _context.Products.FindAsync(model.Id);

        if (product == null) return false;

        _mapper.Map(model, product); // from model to product (product.Name = model.Name)

        await _context.SaveChangesAsync();

        return true;

    }

    public async Task<bool> DeleteAsync(long id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}
