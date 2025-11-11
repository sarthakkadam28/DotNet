using Microsoft.AspNetCore.Mvc;
using TFLCatalog.Entities;
namespace TFLCatalog.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{


    //Action methods

    public ProductsController()
    {
        Console.WriteLine("Products controller instance initialized");

    }


    [HttpGet("list")]
    public IActionResult GetAllProducts()
    {
        Console.WriteLine("invoking products");
        return Ok("all products are available");

    }

    [HttpGet("gallery")]
    public IActionResult GetAllFromGarllery()
    {
        Console.WriteLine("invoking products from gallery");
        return Ok("all products are available from gallery");

    }

    [HttpPost]
    public IActionResult InsertIntoGarllery([FromBody] Product product)
    {

        Console.WriteLine(product.Title + " "+ product.Price);
        Console.WriteLine("inserting products to  gallery");
        return Ok(" product is inserted to gallery");
    }


    [HttpPut]
    public IActionResult UpdatetoGarllery()
    {
        Console.WriteLine("Update to Gallery products to  gallery");
        return Ok(" product is updated to gallery");
    }




}
