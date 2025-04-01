using SearchService.Core.Configuration.DTO;

namespace SearchService.Core.Models;

public record class ProductModel : ProductDTO
{
    public int CategoryId { get; set; }
    public CategoryModel Category { get; set; }
}
