# Dependency_Injection

This project is a minimal ASP.NET Core API that demonstrates how Dependency Injection (DI) works using a custom service and different service lifetimes.

## Purpose

The app shows how the same service interface can be registered with:

- Singleton lifetime
- Transient lifetime
- Scoped lifetime

It currently runs with **Scoped** registration in `Program.cs`.

## Tech stack

- ASP.NET Core Minimal API
- .NET 10 (`net10.0`)

## How DI is configured

In `Program.cs`, only one lifetime is active at a time.

Current active line:

```csharp
builder.Services.AddScoped<IMyService, Myservice>();
```

Other options are already included as comments:

- `AddSingleton<IMyService, Myservice>()`
- `AddTransient<IMyService, Myservice>()`

## Service and flow

### `IMyService`

Defines a single method:

- `LogCreation(string message)`

### `Myservice`

- Creates a random `_serviceId` in the constructor.
- Logs the service ID with a message to the console.
- The ID helps you see whether the same or new instance is used.

### Request pipeline usage

The service is resolved in:

1. First middleware
2. Second middleware
3. Root endpoint (`GET /`)

This makes it easy to compare whether those three locations share the same instance per request.

## Endpoint

| Method | Route | Description |
| --- | --- | --- |
| GET | `/` | Resolves `IMyService`, logs usage, and returns a simple confirmation message. |

Response:

```json
"check console for service log"
```

## Run the project

From the `Dependency_Injection` folder:

```bash
dotnet run
```

or watch mode:

```bash
dotnet watch run
```

Default URLs from launch settings:

- HTTP: `http://localhost:5208`
- HTTPS: `https://localhost:7277`

## Test the API with Dependency_Injection.http

The project includes `Dependency_Injection.http`.

### Install REST Client extension in VS Code

1. Open VS Code.
2. Open Extensions (`Ctrl+Shift+X`).
3. Search for `REST Client`.
4. Install the extension by `Huachao Mao`.
5. Open `Dependency_Injection.http`.
6. Ensure `@Dependency_Injection_HostAddress` matches your running app URL.
7. Click `Send Request`.

## How to observe DI lifetime behavior

1. Run the app.
2. Send one request to `GET /`.
3. In terminal logs, compare service IDs printed by:
   - middleware 1
   - middleware 2
   - endpoint

With **Scoped** lifetime, all three should show the same ID for a single request.

### Compare lifetimes

Switch registration in `Program.cs` and run again:

- **Singleton**: same ID across all requests for app lifetime.
- **Scoped**: same ID inside one request, new ID for next request.
- **Transient**: new ID every time the service is resolved (can differ even within one request).

## Files

- `Program.cs`: DI registration, middleware pipeline, endpoint, and service implementation.
- `Dependency_Injection.http`: request file for quick testing.
- `Properties/launchSettings.json`: local ports and environment.
