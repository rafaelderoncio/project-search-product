using SearchService.Core.Configuration.DTO;

namespace SearchService.Core.Models;

public record class CategoryModel : CategoryDTO
{
    public ICollection<ProductModel> Products { get; set; }
}
