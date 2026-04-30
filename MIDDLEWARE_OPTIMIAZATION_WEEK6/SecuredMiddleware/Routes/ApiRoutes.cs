namespace SecuredMiddleware.Routes;

public static class ApiRoutes
{
    public static IEndpointRouteBuilder MapApiRoutes(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/routes");

        // Simple route for middleware testing.
        group.MapGet("/ping", () => Results.Ok(new
        {
            Message = "pong",
            Source = "MinimalRoute"
        }));

        // Returns request data so you can test query-based middleware.
        group.MapGet("/inspect", (HttpContext context) => Results.Ok(new
        {
            Path = context.Request.Path.Value,
            Token = context.Request.Query["token"].ToString(),
            Input = context.Request.Query["input"].ToString(),
            Secure = context.Request.Query["secure"].ToString()
        }));

        return app;
    }
}
