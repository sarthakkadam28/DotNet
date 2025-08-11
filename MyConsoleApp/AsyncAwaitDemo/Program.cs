// See https://aka.ms/new-console-template for more information
using System.Threading.Tasks;
using AsyncAwaitDemo.Helpers;
// Console.WriteLine("welcome to transflower..");
// Task.Delay(10000);
// console.WriteLine("hello world");
// Console.WriteLine("press any key to exit");


decimal incomeTax = await TaxDeductionManager.CalculateIncomeTax(750000);
console.WriteLine($"Income Tax : {incomeTax}");

List<Product> products = await TaxDeductionManager.GetAllAvailableProducts();
console.WriteLine("Available Products");
foreach (var product in products)
{
    console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
}
