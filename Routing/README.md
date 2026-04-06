# Routing Sample

This folder shows how ASP.NET Core minimal APIs handle route parameters, constraints, optional values, catch-all segments, and query strings.

## Run the project

From the `Routing` folder:

```bash
dotnet run
```

Use the local URL printed in the terminal as the base URL for testing.

## Endpoints

| Method | Route | What it demonstrates |
|---|---|---|
| GET | `/` | Basic hello endpoint |
| GET | `/users/{userId}/posts/{slug}` | Multiple route parameters |
| GET | `/products/{id:int:min(0)}` | Route constraints |
| GET | `/reports/{year?}` | Optional route parameter |
| GET | `/source/{year?}` | Optional route parameter with default value |
| GET | `/files/{*filepath}` | Catch-all route |
| GET | `/search?q=value&page=2` | Query string parameters |
| GET | `/store/{category}/{productId:int?}/{*extrapath}` | Route parameters plus query string |

## Testing with request.http

The `request.http` file contains ready-made requests for this sample.

### Install the VS Code extension

1. Open VS Code.
2. Open the Extensions view with `Ctrl+Shift+X`.
3. Search for `REST Client`.
4. Install the extension published by `Huachao Mao`.
5. Open `request.http` in this folder.
6. Update the port in the file if your app is running on a different localhost port.
7. Click `Send Request` above any request line to execute it.

### Tips

- Make sure the app is running before you send requests.
- If a route has a path parameter, replace the sample value in `request.http` with the value you want to test.
- If you need to test a query string, edit the URL directly in the request file.

## Files

- `Program.cs`: Endpoint definitions.
- `request.http`: Example requests for manual testing.
