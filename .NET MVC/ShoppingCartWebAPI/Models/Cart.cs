using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace ShoppingCartWebAPI.Models;
public class Cart
{
    public int CartId { get; set;}
    public int UserId {get ; set; }

    public DateOnly CreatedAt { get ; set;}

    public DateOnly UpdatedAt { get ; set;}
    public List<CartItem> Items { get; set; } = new List<CartItem>();


}