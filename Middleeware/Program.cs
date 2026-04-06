var builder = WebApplication.CreateBuilder(args);
// Enable request/response logging middleware.
builder.Services.AddHttpLogging((o) => {});
var app = builder.Build();

// Middleware order matters: place cross-cutting concerns before endpoints.
// app.UseRouting();
// app.UseAuthentication();
// app.UseAuthorization();
// app.UseExceptionHandler();
app.Use(async (context, next) =>
{
    Console.WriteLine("Before");
    await next.Invoke();
    Console.WriteLine("After");
});
// app.UseEndpoints();

// HttpLogging should run early so it can capture the request and response pipeline.
app.UseHttpLogging();

// Minimal endpoints used to show middleware execution around requests.
app.MapGet("/", () => "Hello World!");
app.MapGet("/test", () => "Test");

app.Run();
