using Serilog;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
namespace SecureProductApi;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        Log.Information("User {User} accessed {Path}",
            context.User.Identity?.Name ?? "Anonymous",
            context.Request.Path);

        await _next(context);
    }
}
