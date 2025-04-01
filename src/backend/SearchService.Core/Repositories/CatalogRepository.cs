using Microsoft.EntityFrameworkCore;
using SearchService.Core.Models;
using SearchService.Core.Repositories.Interfaces;

namespace SearchService.Core.Repositories;

public class CatalogRepository(CatalogContext _context) : ICatalogRepository
{
    public async Task<IEnumerable<ProductModel>> GetProducts()
        => await _context.Products.Include(x => x.Category).AsNoTracking().ToListAsync();

    public async Task<IEnumerable<CategoryModel>> GetCategories() 
        => await _context.Categories.AsNoTracking().ToListAsync();

    public async Task<ProductModel> GetProduct(int id)
        => await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<CategoryModel> GetCategory(int id) 
        => await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<ProductModel>> SearchProducts(string argument) 
        => await Task.FromResult(_context.Products.Where(product =>
                product.Name.Contains(argument, StringComparison.OrdinalIgnoreCase) ||
                product.Category.Name.Contains(argument, StringComparison.OrdinalIgnoreCase) ||
                product.Brand.StartsWith(argument, StringComparison.OrdinalIgnoreCase)
            ).OrderByDescending(product => product.Name.StartsWith(argument, StringComparison.OrdinalIgnoreCase)));

    public async Task<IEnumerable<CategoryModel>> SearchCategories(string argument) 
        => await Task.FromResult(_context.Categories.Where(category =>
                category.Name.Contains(argument, StringComparison.OrdinalIgnoreCase)
            ).OrderByDescending(product => product.Name.StartsWith(argument, StringComparison.OrdinalIgnoreCase)));
}
