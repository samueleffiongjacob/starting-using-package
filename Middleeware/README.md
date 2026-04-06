# Middleware Sample

This folder demonstrates middleware order in ASP.NET Core and shows how request logging wraps endpoint execution.

## Run the project

From the `Middleeware` folder:

```bash
dotnet run
```

Use the local URL printed in the terminal as the base URL for testing.

## Endpoints

| Method | Route | Description |
|---|---|---|
| GET | `/` | Basic hello endpoint |
| GET | `/test` | Simple test endpoint |

## What to watch for

- The custom middleware writes `Before` before the request reaches the endpoint.
- It writes `After` after the endpoint finishes.
- `UseHttpLogging()` shows how built-in middleware can be added to the pipeline.

## Testing with request.http

You can use a `request.http` file in VS Code to send requests to this app.

### Install the VS Code extension

1. Open VS Code.
2. Open the Extensions view with `Ctrl+Shift+X`.
3. Search for `REST Client`.
4. Install the extension published by `Huachao Mao`.
5. Create or open a `request.http` file.
6. Set the URL to your running localhost port.
7. Click `Send Request` to call the endpoint.

## Files

- `Program.cs`: Middleware and endpoint setup.
