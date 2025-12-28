using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using ShoppingCartWebAPI.Models;
using ShoppingCartWebAPI.Services;
 
namespace ShoppingCartWebAPI.Repositories;

public class CartServices:ICartServices
{
    private readonly ICartRepository _cartrepository;
    public CartServices(ICartRepository cartRepository)
    {
        _cartrepository=cartRepository;
    }
    
    public Cart GetCartById(int cartId)
    {
       return _cartrepository.GetCartById(cartId); 
    }
    public IEnumerable<Cart> GetAllCarts()
    {
       return  _cartrepository.GetAllCarts();
    }
    public void AddCart(Cart cart)
    {
        
    }
    public void  UpdateCart(Cart cart)
    {
        
    }
    public void DeleteCart(int cartId)
    {
        
    }
    public void AddItem(int cartId, CartItem item)
    {
        
    }
    public void RemoveItem(int cartId, int cartItemId)
    {
        
    }
    public void  UpdateItem(int cartId, CartItem item)
    {
        
    }


}