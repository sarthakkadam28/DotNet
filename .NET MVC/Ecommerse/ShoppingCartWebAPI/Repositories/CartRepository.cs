using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using ShoppingCartWebAPI.Models;
namespace ShoppingCartWebAPI.Repositories;
public class CartRepositoy:ICartRepository
{

    private readonly string filePath = "Data/cart.json";

    public Cart GetCartById(int cartId)
    {
        var carts = JsonHelper.LoadJson<List<Cart>>(filePath);
        // return carts.FirstOrDefault(c => c.CartId == cartId);
        foreach (var cart in carts)
            {
                if (cart.CartId == cartId)
                {
                    return cart;
                }
            }
            return null;

    }

    public IEnumerable<Cart> GetAllCarts()
    {
        return JsonHelper.LoadJson<List<Cart>>(filePath);
    }

    public void AddCart(Cart cart)
    {
        var carts = JsonHelper.LoadJson<List<Cart>>(filePath);
        carts.Add(cart);
        JsonHelper.SaveJson(filePath, carts);
    }

    public void UpdateCart(Cart cart)
    {
        var carts = JsonHelper.LoadJson<List<Cart>>(filePath);
        // var index = carts.FindIndex(c => c.CartId == cart.CartId);
        // if (index != -1)
        // {
        //     carts[index] = cart;
        //     JsonHelper.SaveJson(filePath, carts);
        // }
        for (int i = 0; i < carts.Count; i++)
            {
                if (carts[i].CartId == cart.CartId)
                {
                    carts[i] = cart;
                    JsonHelper.SaveJson(filePath, carts);
                    break;
                }
            }


    }
    public void DeleteCart(int cartId)
    {
        var carts = JsonHelper.LoadJson<List<Cart>>(filePath);
        // var cartToRemove = carts.FirstOrDefault(c => c.CartId == cartId);
        // if (cartToRemove != null)
        // {
        //     carts.Remove(cartToRemove);
        //     JsonHelper.SaveJson(filePath, carts);
        // }
        Cart cartToRemove = null;

        foreach (var cart in carts)
            {
                if (cart.CartId == cartId)
                {
                    cartToRemove = cart;
                    break;
                }
            }

            if (cartToRemove != null)
            {
                carts.Remove(cartToRemove);
                JsonHelper.SaveJson(filePath, carts);
            }     

    } 
    public void AddItem(int cartId, CartItem item)
    {
        var carts = JsonHelper.LoadJson<List<Cart>>(filePath);
        // var cart = carts.FirstOrDefault(c=> c.CartId == cartId);
        // if(cart !=null)
        // {
        //     cart.Items.Add(item);
        //     JsonHelper.SaveJson(filePath, carts);
        // }
        foreach (var cart in carts)
            {
                if (cart.CartId == cartId)
                {
                    cart.Items.Add(item);
                    JsonHelper.SaveJson(filePath, carts);
                    break;
                }
            }

    } 
    public void RemoveItem(int cartId, int cartItemId)
    {
        var carts = JsonHelper.LoadJson<List<Cart>>(filePath);
        // var  cart = carts.FirstOrDefault( c => c.CartId == cartId);
        // if(cart != null)
        // {
        //     var itemToRemove = cart.Items.FirstOrDefault(i => i.CartItemId == cartItemId);
        //     if(itemToRemove != null)
        //     {
        //         cart.Items.Remove(itemToRemove);
        //         JsonHelper.SaveJson(filePath, carts);
        //     }
        // }
        foreach (var cart in carts)
            {
                if (cart.CartId == cartId)
                {
                    CartItem itemToRemove = null;
                    foreach (var item in cart.Items)
                    {
                        if (item.CartItemId == cartItemId)
                        {
                            itemToRemove = item;
                            break;
                        }
                    }

                    if (itemToRemove != null)
                    {
                        cart.Items.Remove(itemToRemove);
                        JsonHelper.SaveJson(filePath, carts);
                    }
                    break;
                }
            }

    }
    public void UpdateItem(int cartId, CartItem item)
    {
        var carts = JsonHelper.LoadJson<List<Cart>>(filePath);
        // var cart = carts.FirstOrDefault(c => c.CartId == cartId);
        // if(cart != null)
        // {
        //     var index = cart.Items.FindIndex(i => i.CartItemId == item.CartItemId);
        //     if(index != -1)
        //     {
        //         cart.Items[index] = item;
        //         JsonHelper.SaveJson(filePath, carts);
        //     }
        // }
        foreach (var cart in carts)
            {
                if (cart.CartId == cartId)
                {
                    for (int i = 0; i < cart.Items.Count; i++)
                    {
                        if (cart.Items[i].CartItemId == item.CartItemId)
                        {
                            cart.Items[i] = item;
                            JsonHelper.SaveJson(filePath, carts);
                            break;
                        }
                    }
                    break;
                }
            }


    }
}