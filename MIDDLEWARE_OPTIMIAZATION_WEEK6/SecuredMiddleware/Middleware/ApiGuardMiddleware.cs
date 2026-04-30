namespace SecuredMiddleware.Middleware;

public class ApiGuardMiddleware
{
    private static readonly HashSet<string> BlockedPaths = new(StringComparer.OrdinalIgnoreCase)
    {
        "/api/blocked",
        "/api/forbidden",
        "/api/badrequest",
        "/api/invalidinput"
    };

    private readonly RequestDelegate _next;

    public ApiGuardMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Path.StartsWithSegments("/api"))
        {
            await _next(context);
            return;
        }

        if (BlockedPaths.Contains(context.Request.Path))
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync("Blocked test path.");
            return;
        }

        if (context.Request.Query["secure"].ToString() != "true")
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Missing secure=true.");
            return;
        }

        if (context.Request.Query["token"].ToString() != "valid-token")
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Invalid token.");
            return;
        }

        var input = context.Request.Query["input"].ToString();
        if (!IsValidInput(input))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Invalid input.");
            return;
        }

        context.Response.Headers["X-Request-Guard"] = "Enabled";
        await _next(context);
    }

    private static bool IsValidInput(string input)
    {
        // Keep validation simple and predictable for testing.
        return !string.IsNullOrWhiteSpace(input)
            && input.Length <= 100
            && input.All(char.IsLetterOrDigit)
            && !input.Contains("<script>", StringComparison.OrdinalIgnoreCase);
    }
}
