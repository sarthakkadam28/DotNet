using ProjectMangement.Repository;
using ProjectMangement.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddOpenApi();

builder.Services.AddScoped<IProjectServices, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

var app = builder.Build();
app.UseRouting();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();

