namespace SearchService.Domain.Responses;

public record class CategoryResponse
{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
}
