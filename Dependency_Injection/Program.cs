var builder = WebApplication.CreateBuilder(args);
// Register MyService as a singleton in the DI container. This means the same instance will be used throughout the application's lifetime.
//builder.Services.AddSingleton<IMyService, Myservice>();

// Register MyService as transient. A new instance will be created each time it's requested.
//builder.Services.AddTransient<IMyService, Myservice>();

// Register MyService as scoped. A new instance will be created for each HTTP request and shared within that request.
builder.Services.AddScoped<IMyService, Myservice>();
var app = builder.Build();

// middleware and endpoints can now receive IMyService as a parameter and it will be injected by the DI container.

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Middleware executed.");
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Middleware executed with next.");
    await next.Invoke();
});
app.MapGet("/", (IMyService myService) => {
    myService.LogCreation("Root endpoint was hit.");
    return Results.Ok("check console for service log");
});

app.Run();

public interface IMyService
{
    void LogCreation(string message);
}

public class Myservice : IMyService
{
    private readonly int _serviceId;

    public Myservice()
    {
        _serviceId = new Random().Next(100000, 999999);
    }

    public void LogCreation(string message)
    {
        Console.WriteLine($"Service Id : {_serviceId}: {message}");
    }

}