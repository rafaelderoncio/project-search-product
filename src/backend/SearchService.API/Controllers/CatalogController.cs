using Microsoft.AspNetCore.Mvc;
using SearchService.Core.Services.Interfaces;
using SearchService.Domain.Responses;

namespace SearchService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogController(ICatalogService _service) : ControllerBase
{
    [HttpGet("product/search")]
    [ProducesResponseType(typeof(ProductSearchResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchProduct([FromQuery] string like) => Ok(await _service.SearchProduct(like));

    [HttpGet("category/search")]
    [ProducesResponseType(typeof(CategorySearchResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchCategory([FromQuery] string like) => Ok(await _service.SearchCategory(like));

    [HttpGet("product/{id:int}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProduct([FromRoute] int id) => Ok(await _service.GetProduct(id));

    [HttpGet("category/{id:int}")]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategory([FromRoute] int id) => Ok(await _service.GetCategory(id));
}