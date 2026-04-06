var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// In-memory data store used to demonstrate CRUD operations without a database.
var blogs = new List<Blog>
{
    new Blog { Title = "My FIRST POst", Body = "This is my first post" },
    new Blog { Title = "My SECOND POst", Body = "This is my second post" }
};

// Simple root endpoint.
app.MapGet("/", () => "I am samuel in the server root!");

// Return all blog posts.
app.MapGet("/blogs", () => {
    return blogs;
});

// Return a single blog post by index.
app.MapGet("/blogs/{id}", (int id) => {
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }  else
    {
        return Results.Ok(blogs[id]);
    } 
    
});

// Create a new blog post.
app.MapPost("/blogs", (Blog blog) => {
    blogs.Add(blog);
    return Results.Created($"/blogs/{blogs.Count - 1}", blog);
});


// Delete a blog post by index.
app.MapDelete("/blogs/{id}", (int id) => {
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }  else
    {
        var deletedBlog = blogs[id];
        blogs.RemoveAt(id);
        return Results.Ok(deletedBlog);
    } 
    
});

// Replace an existing blog post by index.
app.MapPut("/blogs/{id}", (int id, Blog updatedBlog) => {
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }  else
    {
        blogs[id] = updatedBlog;
        return Results.Ok(blogs[id]);
    } 
    
});

app.Run();  


// Simple model used by the CRUD endpoints.
public class Blog
{
    public string Title { get; set; }
    public string Body { get; set; }
}