var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
var app = builder.Build();


app.MapGet("/products", () =>
{
    Console.WriteLine("Hello World");
});

app.Run();
 