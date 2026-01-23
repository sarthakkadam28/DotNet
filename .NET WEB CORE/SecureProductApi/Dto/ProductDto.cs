using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System;
namespace SecureProductApi;
public class ProductDto
{
    [Required]
    [StringLength(100)]
    public string Names{get;set;}
    [Range(1,100000)]
    public decimal Price{get;set;}
    
}