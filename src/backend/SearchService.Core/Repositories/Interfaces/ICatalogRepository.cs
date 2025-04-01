using SearchService.Core.Models;

namespace SearchService.Core.Repositories.Interfaces;

public interface ICatalogRepository
{
    Task<IEnumerable<ProductModel>> GetProducts();
    Task<IEnumerable<CategoryModel>> GetCategories();
    Task<ProductModel> GetProduct(int id);
    Task<CategoryModel> GetCategory(int id);
    Task<IEnumerable<ProductModel>> SearchProducts(string argument);
    Task<IEnumerable<CategoryModel>> SearchCategories(string argument);
}
