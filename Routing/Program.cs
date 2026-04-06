var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Basic route parameter example.
app.MapGet("/", () => "Hello World!");
app.MapGet("/users/{userId}/posts/{slug}", (int userId, string slug) => {
    return $"User ID: {userId}, Slug: {slug}";
});

// Route constraint ensures the id is an integer greater than or equal to 0.
app.MapGet("/products/{id:int:min(0)}", (int id) => {
    return $"Product ID: {id}";
});

// Optional route parameter example.
app.MapGet("/reports/{year?}/", (int? year) => {
    if (year.HasValue)
    {
        return $"Report for year: {year.Value}";
    }
    else
    {
        return "Report for all years";
    }
}); 

// Optional route parameter with a default value.
app.MapGet("/source/{year?}/", (int? year=2023) => {
    if (year.HasValue)
    {
        return $"Report for year: {year.Value}";
    }
    else
    {
        return "Report for all years";
    }
}); 

// Catch-all route example for file-style paths.
app.MapGet("/files/{*filepath}", (string filepath) => {
    return $"Requested file path: {filepath}";
});

// Query string parameters.
app.MapGet("/search", (string?q, int page =1) => {
    return $"Search query: {q} on page: {page}";    
});


// Mix route parameters, catch-all segments, and query string values.
app.MapGet("/store/{category}/{productId:int?}/{*extrapath}", (string category, string? extrapath, int? productId, bool instock = true)  => {
    return $"Product: {productId} in category: {category}, path: {extrapath}, in stock: {instock}";
});
app.Run();
