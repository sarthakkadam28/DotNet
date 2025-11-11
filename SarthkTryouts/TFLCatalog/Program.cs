var builder = WebApplication.CreateBuilder(args);


//1. service  configuration
builder.Services.AddControllers();
//service registration for all dependency services




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//2. Middleware configuration
//HTTP Pipeline


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();


//3. Set server listening on port number
app.Run();

//asp.net core  Web API

//minimal code api:   program.cs  app.get, app.put, app.post 

