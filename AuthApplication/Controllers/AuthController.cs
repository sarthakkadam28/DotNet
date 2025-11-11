using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AuthApplication.Models;

namespace AuthApplication.Controllers;

public class AuthController : Controller
{
    public AuthController()
    {

    }
    [HttpGet]
    public IActionResult Login()
    {

        //send empty form
        return View();

    }


    [HttpPost]
   // public IActionResult Login(string email, string password)
   //public IActionResult Login(FormCollection data)
    public IActionResult Login(LoginViewModel model)
    {
        Console.WriteLine("post login is called");
        if (model.Email == "ravi.tambade@transflower.in" && model.Password == "seed")
        {
            Console.WriteLine("success");

             return RedirectToAction("Welcome", "Home");
        }
        return View();
    }



    public IActionResult Register()
    {

        RegisterViewModel model = new RegisterViewModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {

            Console.WriteLine(model.FirstName);
            // ✅ Save user to database or process registration here
            // Example: redirect to login or dashboard
            return RedirectToAction("Welcome", "Home");
        }
        return View();
    }
}
