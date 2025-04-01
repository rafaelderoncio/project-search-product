using Microsoft.Extensions.Caching.Memory;
using SearchService.Core.Models;
using SearchService.Core.Repositories.Interfaces;

namespace SearchService.Core.Repositories;

public class CatalogCacheRepository(IMemoryCache _cache, ICatalogRepository _repository, ILogger<ICatalogCacheRepository> _logger) : ICatalogCacheRepository
{

    private readonly TimeSpan _expires = TimeSpan.FromMinutes(30);
    private readonly string _productCacheKey = "product_cache";
    private readonly string _categoryCacheKey = "category_cache";

    public async Task<IEnumerable<CategoryModel>> SearchCategories(string argument)
    {
        if (!_cache.TryGetValue(_productCacheKey, out IEnumerable<CategoryModel> categories))
        {
            categories = await _repository.GetCategories();
            _cache.Set(_productCacheKey, categories, _expires);
        }
        
        return categories.Where(category =>
                category.Name.Contains(argument, StringComparison.OrdinalIgnoreCase)
            ).OrderByDescending(product => product.Name.StartsWith(argument, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<IEnumerable<ProductModel>> SearchProducts(string argument)
    {
        if (!_cache.TryGetValue(_productCacheKey, out IEnumerable<ProductModel> products))
        {
            products = await _repository.GetProducts();
            _cache.Set(_productCacheKey, products, _expires);
        }

        return products.Where(product =>
                product.Name.Contains(argument, StringComparison.OrdinalIgnoreCase) ||
                product.Category.Name.Contains(argument, StringComparison.OrdinalIgnoreCase) ||
                product.Brand.StartsWith(argument, StringComparison.OrdinalIgnoreCase)
            ).OrderByDescending(product => product.Name.StartsWith(argument, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<CategoryModel> GetCategory(int id)
    {
        if (!_cache.TryGetValue(_productCacheKey, out IEnumerable<CategoryModel> categories))
        {
            categories = await _repository.GetCategories();
            _cache.Set(_productCacheKey, categories, _expires);
        }
        
        return categories.FirstOrDefault(x => x.Id == id);
    }

    public async Task<ProductModel> GetProduct(int id)
    {
        if (!_cache.TryGetValue(_productCacheKey, out IEnumerable<ProductModel> products))
        {
            products = await _repository.GetProducts();
            _cache.Set(_productCacheKey, products, _expires);
        }

        return products.FirstOrDefault(x => x.Id == id);
    }

    public async Task InitializeCache()
    {
        IEnumerable<ProductModel> products = await _repository.GetProducts();
        _cache.Set(_productCacheKey, products, _expires);
        _logger.LogInformation($"Products cached. Total: {products.Count()}");

        IEnumerable<CategoryModel> categories = await _repository.GetCategories();
        _cache.Set(_categoryCacheKey, categories, _expires);
        _logger.LogInformation($"Categories cached. Total: {categories.Count()}");
    }
}
