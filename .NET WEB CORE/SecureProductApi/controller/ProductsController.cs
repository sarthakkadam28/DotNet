using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SecureProductApi;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok("Secure product list");
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(ProductDto dto)
    {
        return Ok("Product created");
    }
}