using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using ShoppingCartWebAPI.Models;
namespace ShoppingCartWebAPI.Repositories;

public interface ICartRepository
{
    Cart GetCartById(int cartId);
    IEnumerable<Cart> GetAllCarts();
    void AddCart(Cart cart);
    void UpdateCart(Cart cart);
    void DeleteCart(int cartId);

    void AddItem(int cartId, CartItem item);
    void RemoveItem(int cartId, int cartItemId);
    void UpdateItem(int cartId, CartItem item);
}