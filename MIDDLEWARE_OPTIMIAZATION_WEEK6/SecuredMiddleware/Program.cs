using SecuredMiddleware.Middleware;
using SecuredMiddleware.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5203);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ApiGuardMiddleware>();

if (app.Environment.IsDevelopment())
{
    // Swagger stays available in development for fast endpoint testing.
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapApiRoutes();

app.Run();
