using SearchService.Core.Models;
using SearchService.Core.Repositories.Interfaces;
using SearchService.Core.Services.Interfaces;
using SearchService.Domain.Responses;

namespace SearchService.Core.Services;

public class CatalogService(ICatalogCacheRepository _cache, ICatalogRepository _repository) : ICatalogService
{
    public async Task<IEnumerable<ProductSearchResponse>> SearchProduct(string like)
    {
        string argument = like.Trim();

        if (string.IsNullOrWhiteSpace(argument))
            return null;

        // search first in cache
        IEnumerable<ProductModel> products =
            await _cache.SearchProducts(argument) ??
            await _repository.SearchProducts(argument);

        if (products.Any())
            return products.Select(product => new ProductSearchResponse
            {
                Id = product.Id,
                Name = product.Name,
            }
        );

        return [];
    }

    public async Task<IEnumerable<CategorySearchResponse>> SearchCategory(string like)
    {
        string argument = like.Trim();

        if (string.IsNullOrWhiteSpace(argument))
            return null;

        // search first in cache
        IEnumerable<CategoryModel> categories = 
            await _cache.SearchCategories(argument) ?? 
            await _repository.SearchCategories(argument);

        if (categories.Any())
            return categories.Select(category => new CategorySearchResponse
            {
                Id = category.Id,
                Name = category.Name,
            }
        );

        return [];
    }

    public async Task<ProductResponse> GetProduct(int id) 
    {
        // search first in cache
        ProductModel product = await _cache.GetProduct(id) ?? await _repository.GetProduct(id);

        if (product != null)
            return new() {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Model = product.Model,
                Price = product.Price,
                Stock = product.Stock,
                Category = new() {
                    Id = product.Category.Id,
                    Name = product.Category.Name,
                    Description = product.Category.Description
                }
            };

        return null;
    }

    public async Task<CategoryResponse> GetCategory(int id) 
    {
        CategoryModel category = await _cache.GetCategory(id) ?? await _repository.GetCategory(id);

        if (category != null)
            return new() {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };
        
        return null;
    }
}
