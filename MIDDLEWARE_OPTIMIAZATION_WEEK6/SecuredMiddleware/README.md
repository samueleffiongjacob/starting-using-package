# SecuredMiddleware

This is a small ASP.NET Core app for testing layered middleware, controller routes, and minimal routes in a development-friendly setup.

## What it includes

- Middleware in the `Middleware/` folder
- Controllers in the `Controllers/` folder
- Route extensions in the `Routes/` folder
- Swagger enabled only in Development

## Run

From this folder:

```bash
dotnet run
```

The app listens on:

- <http://localhost:5203>

## Swagger

When running in Development, open:

- <http://localhost:5203/swagger>

## Test endpoints

Controller endpoints:

- `GET /api/demo/ping`
- `GET /api/demo/echo?secure=true&token=valid-token&input=Test123`
- `GET /api/demo/users/1?secure=true&token=valid-token&input=Test123`

Route endpoints:

- `GET /api/routes/ping?secure=true&token=valid-token&input=Test123`
- `GET /api/routes/inspect?secure=true&token=valid-token&input=Test123`

## Middleware rules

These requests are allowed only when the query values are present:

- `secure=true`
- `token=valid-token`
- `input` must be alphanumeric and up to 100 characters

Blocked paths:

- `/api/blocked`
- `/api/forbidden`
- `/api/badrequest`
- `/api/invalidinput`

## Folder layout

- `Controllers/` contains controller-based API tests
- `Routes/` contains minimal route definitions
- `Middleware/` contains the custom middleware classes
