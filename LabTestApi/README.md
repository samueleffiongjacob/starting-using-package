# LabTestApi

This project is a small ASP.NET Core Web API that demonstrates controller-based routing, in-memory CRUD behavior, Swagger documentation, and REST Client testing from VS Code.

## What the app does

The API exposes a single products controller at `api/products`.

Products are stored in memory for demo purposes, so the data resets when the application restarts.

## Run the project

From the `LabTestApi` folder:

```bash
dotnet run
```

In development, the app enables Swagger and Swagger UI automatically.

The default HTTP URL in `launchSettings.json` is `http://localhost:5290`.

## API endpoints

| Method | Route | Description |
|---|---|---|
| GET | `/api/products` | Returns all products |
| GET | `/api/products/{id}` | Returns one product by numeric ID |
| POST | `/api/products` | Creates a new product |
| PUT | `/api/products/{id}` | Updates an existing product |
| DELETE | `/api/products/{id}` | Deletes a product |

## Product model

Each product has these fields:

- `Id`
- `Name`
- `Description`
- `Price`

## Testing with LabTestApi.http

The `LabTestApi.http` file is ready for use with the VS Code REST Client extension.

### Install the VS Code extension

1. Open VS Code.
2. Open the Extensions view with `Ctrl+Shift+X`.
3. Search for `REST Client`.
4. Install the extension published by `Huachao Mao`.
5. Open `LabTestApi.http` in this folder.
6. Make sure the base URL matches the port your app is running on.
7. Click `Send Request` above a request line to run it.

### Suggested test flow

1. Start the API with `dotnet run`.
2. Send `GET /api/products` to confirm the API is working.
3. Send `POST /api/products` to create a product.
4. Send `GET /api/products/{id}` to fetch the new item.
5. Send `PUT /api/products/{id}` to update it.
6. Send `DELETE /api/products/{id}` to remove it.

## Swagger

Swagger is the auto-generated API documentation for this project. It reads your controller routes and model definitions, then provides:

- A browser UI to view and test endpoints.
- A machine-readable OpenAPI JSON document.

In this project, Swagger is enabled only when the app runs in Development mode.

### How Swagger is wired in this app

- `AddEndpointsApiExplorer()` and `AddSwaggerGen()` register Swagger services.
- `UseSwagger()` serves the OpenAPI JSON.
- `UseSwaggerUI()` serves the interactive Swagger page.

### How to access Swagger

1. Start the API:

```bash
dotnet run
```

2. Look at terminal output for `Now listening on:` to confirm the active URL.
3. Open one of the following URLs in your browser (based on your running port):

- `http://localhost:5290/swagger`
- `https://localhost:7195/swagger`

4. To view raw OpenAPI JSON:

- `http://localhost:5290/swagger/v1/swagger.json`
- `https://localhost:7195/swagger/v1/swagger.json`

### If Swagger does not open

1. Confirm the app is still running.
2. Confirm you are using the same port shown in terminal output.
3. Confirm environment is Development (`ASPNETCORE_ENVIRONMENT=Development`).
4. Rebuild and run again:

```bash
dotnet build
dotnet run
```

## Files

- `Program.cs`: App startup, controller registration, and Swagger configuration.
- `Controllers/ProductController.cs`: CRUD endpoints.
- `Models/Product.cs`: Product data model.
- `LabTestApi.http`: REST Client examples for testing the API.
