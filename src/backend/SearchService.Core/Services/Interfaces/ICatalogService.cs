using SearchService.Domain.Responses;

namespace SearchService.Core.Services.Interfaces;

public interface ICatalogService
{
    Task<IEnumerable<ProductSearchResponse>> SearchProduct(string like);
    Task<ProductResponse> GetProduct(int id);
    Task<IEnumerable<CategorySearchResponse>> SearchCategory(string like);
    Task<CategoryResponse> GetCategory(int id);
}
