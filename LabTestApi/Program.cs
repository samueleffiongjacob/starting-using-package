var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register Controllers, for endpoint mapping and API behavior.
builder.Services.AddControllers();
// Add Swagger/OpenAPI services for API documentation and testing UI.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

// Map controller routes to enable your controller endpoints.
app.MapControllers();
app.Run();