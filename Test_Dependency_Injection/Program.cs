var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMyService, MyService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

// app.UseHttpsRedirection();
// middleware and endpoints can now receive IMyService as a parameter and it will be injected by the DI container.

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Middleware executed.");
    await next();
});

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Middleware executed with next.");
    await next();
});
// Define an endpoint that also receives IMyService as a parameter.
app.MapGet("/", (IMyService myService) => {
    myService.LogCreation("Root endpoint was hit.");
    return Results.Ok("check console for service log");
});

app.Run();

