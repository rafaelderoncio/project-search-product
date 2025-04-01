namespace SearchService.Domain.Responses;

public record class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public CategoryResponse Category { get; set; }
}
