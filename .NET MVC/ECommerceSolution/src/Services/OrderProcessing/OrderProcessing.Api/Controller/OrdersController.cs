
using Microsoft.AspNetCore.Mvc;

namespace Orders.Api.Controllers;
[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    [HttpPost]
    public IActionResult PlaceOrder(object order)
    {
        return Ok("Order placed successfully");
    }
}