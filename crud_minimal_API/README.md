# CRUD Minimal API Sample

This folder shows a simple in-memory CRUD API for blog posts using ASP.NET Core minimal APIs.

## Run the project

From the `crud_minimal_API` folder:

```bash
dotnet run
```

Use the local URL printed in the terminal as the base URL for testing.

## Endpoints

| Method | Route | Description |
|---|---|---|
| GET | `/` | Basic root endpoint |
| GET | `/blogs` | Returns all blog posts |
| GET | `/blogs/{id}` | Returns one blog post by index |
| POST | `/blogs` | Adds a new blog post |
| PUT | `/blogs/{id}` | Replaces an existing blog post |
| DELETE | `/blogs/{id}` | Deletes a blog post |

## Testing with request.http

The `requests.http` file includes sample requests for all CRUD operations.

### Install the VS Code extension

1. Open VS Code.
2. Open the Extensions view with `Ctrl+Shift+X`.
3. Search for `REST Client`.
4. Install the extension published by `Huachao Mao`.
5. Open `requests.http` in this folder.
6. Update the localhost port if your app uses a different port.
7. Click `Send Request` above each request to run it.

### Test flow

1. Start the app with `dotnet run`.
2. Send the `GET /blogs` request first to confirm the in-memory list.
3. Send the `POST /blogs` request to add a new blog post.
4. Send `GET /blogs/{id}`, `PUT /blogs/{id}`, and `DELETE /blogs/{id}` to verify the full CRUD flow.

## Notes

- Data is stored in memory only, so it resets when the app restarts.
- The blog index is used as the identifier in the current sample.
