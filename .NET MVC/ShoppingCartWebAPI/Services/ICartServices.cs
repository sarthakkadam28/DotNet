using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using ShoppingCartWebAPI.Models;
namespace ShoppingCartWebAPI.Services;
public interface ICartServices
{
   public Cart GetCartById(int cartId);
   public  IEnumerable<Cart> GetAllCarts();
     public void AddCart(Cart cart);
     public void UpdateCart(Cart cart);
   public  void DeleteCart(int cartId);

     public void AddItem(int cartId, CartItem item);
     public void RemoveItem(int cartId, int cartItemId);
     public void UpdateItem(int cartId, CartItem item);



}