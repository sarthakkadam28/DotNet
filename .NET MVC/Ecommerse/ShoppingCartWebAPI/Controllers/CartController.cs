using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using ShoppingCartWebAPI.Models;
using ShoppingCartWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartServices _cartService;

    public CartController(ICartServices cartService)
    {
        _cartService = cartService;
    }

    // GET: api/Cart/{Cartid}
    [HttpGet("{id}")]
    public IActionResult GetCartById(int CartId)
    {
        var cart = _cartService.GetCartById(CartId);
        if (cart == null)
        {
           return NotFound(); 
        }
        return Ok(cart);
    }

    // GET: api/Cart
    [HttpGet]
    public IActionResult GetAllCarts()
    {
        var carts = _cartService.GetAllCarts();
        return Ok(carts);
    }

    // POST: api/Cart
    [HttpPost]
    public IActionResult AddCart([FromBody] Cart cart)
    {
        _cartService.AddCart(cart);
        return CreatedAtAction(nameof(GetCartById), new { id = cart.CartId }, cart);
    }
    // PUT: api/Cart/{CartItemid}
    [HttpPut("{id}")]
    public IActionResult UpdateCart(int id, [FromBody] Cart cart)
    {
        if (cart.CartId != id) return BadRequest("Cart ID mismatch");
        _cartService.UpdateCart(cart);
        return NoContent();
    }
    // DELETE: api/Cart/{Cartid}
    [HttpDelete("{id}")]
    public IActionResult DeleteCart(int id,[FromBody] Cart cart)
    {
        if (cart.CartId != id) return BadRequest("Cart ID mismatch");
        _cartService.DeleteCart(id);
        return NoContent();
    }

    // POST: api/Cart/{id}/items
    [HttpPost("{CartId}/items")]
    public IActionResult AddItem(int id, [FromBody] CartItem item)
    {
        _cartService.AddItem(id, item);
        return Ok();
    }

    // PUT: api/Cart/{id}/items/{itemId}
    [HttpPut("{CartId}/items/{itemId}")]
    public IActionResult UpdateItem(int id, int itemId, [FromBody] CartItem item)
    {
        if (item.CartItemId != itemId) return BadRequest("Item ID mismatch");
        _cartService.UpdateItem(id, item);
        return Ok();
    }

    // DELETE: api/Cart/{id}/items/{itemId}
    [HttpDelete("{CartId}/items/{itemId}")]
    public IActionResult RemoveItem(int id, int itemId)
    {
        _cartService.RemoveItem(id, itemId);
        return NoContent();
    }
}