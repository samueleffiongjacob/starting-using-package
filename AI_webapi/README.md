# AI_webapi

A starter ASP.NET Core Minimal API project targeting .NET 10.

This project currently exposes one endpoint (`/weatherforecast`) and uses built-in OpenAPI support for API metadata in Development mode.

## Tech stack

- ASP.NET Core Minimal API
- .NET 10 (`net10.0`)
- `Microsoft.AspNetCore.OpenApi`

## Project structure

- `Program.cs`: App startup, middleware, and endpoint mapping.
- `full_weeb_API.csproj`: Project target framework and package references.
- `full_weeb_API.http`: Ready-to-run HTTP request samples for VS Code REST Client.
- `appsettings.json` and `appsettings.Development.json`: Logging and environment configuration.
- `Properties/launchSettings.json`: Local development URLs and environment variables.

## How the API works

The app configures OpenAPI services with:

- `builder.Services.AddOpenApi();`

In Development mode, it exposes OpenAPI metadata with:

- `app.MapOpenApi();`

It also enables HTTPS redirection:

- `app.UseHttpsRedirection();`

Finally, it maps the weather endpoint:

- `GET /weatherforecast`

## Run the project

From the `AI_webapi` folder:

```bash
dotnet run
```

Default local URLs from launch settings:

- HTTP: `http://localhost:5199`
- HTTPS: `https://localhost:7171`

## Endpoint reference

| Method | Route | Description |
| --- | --- | --- |
| GET | `/weatherforecast` | Returns 5 generated forecast items with date, Celsius temperature, summary, and computed Fahrenheit value. |

### Example response

```json
[
  {
    "date": "2026-04-07",
    "temperatureC": 23,
    "summary": "Warm",
    "temperatureF": 73
  }
]
```

## OpenAPI (Swagger JSON)

This project uses OpenAPI document generation (not Swagger UI middleware).

When running in Development, access the OpenAPI document at:

- `http://localhost:5199/openapi/v1.json`
- or `https://localhost:7171/openapi/v1.json`

If you want a browser UI, you can add Swagger UI middleware later (`Swashbuckle.AspNetCore`).

## Test with full_weeb_API.http

The repository includes `full_weeb_API.http` for direct endpoint testing.

### Install REST Client extension in VS Code

1. Open VS Code.
2. Open Extensions (`Ctrl+Shift+X`).
3. Search for `REST Client`.
4. Install the extension by `Huachao Mao`.
5. Open `full_weeb_API.http`.
6. Ensure `@full_weeb_API_HostAddress` matches your running URL.
7. Click `Send Request` above the request.

## Quick curl test

```bash
curl http://localhost:5199/weatherforecast
```

## Notes

- Forecast data is generated in memory on each request and is not persisted.
- OpenAPI endpoint is only mapped in Development environment.
