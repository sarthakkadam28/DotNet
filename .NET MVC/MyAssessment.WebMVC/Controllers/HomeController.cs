using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyAssessment.WebMVC.Models;
using Microsoft.EntityFrameworkCore;
using MyAssessment.WebMVC.Data;
using System.Threading.Tasks;

namespace MyAssessment.WebMVC.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context; 
    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public async Task<IActionResult> Profile()
    {
        return View(await _context.Products.ToListAsync());
    }
    public async Task<IActionResult> Products()
    {
        var products = await _context.Products.ToListAsync();
        return View(products);
        //return View();
    }

    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
