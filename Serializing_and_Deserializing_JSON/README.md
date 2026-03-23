# JSON Serialization and Deserialization Program

## Overview

This C# program demonstrates **JSON serialization and deserialization** using the **Newtonsoft.Json** (Json.NET) library. It shows how to convert between JSON strings and C# objects.

## What This Program Does

### 1. Deserialization (JSON → C# Object)

- Takes a JSON string containing product information (name, price, and tags)
- Converts it into a `Product` C# object using `JsonConvert.DeserializeObject<T>()`
- Displays the deserialized object's properties

**Example:**

```
Input JSON: {"Name": "Laptop", "Price": 999.99, "Tags": ["Electronics", "Computers"]}
Output: Product object with accessible properties (Name, Price, Tags)
```

### 2. Serialization (C# Object → JSON)

- Creates a `Samuel` object (inheriting from `Product`) with product data
- Converts it to a formatted JSON string using `JsonConvert.SerializeObject()`
- Displays the resulting JSON

**Example:**

```
Input: Samuel object with Name="Smartphone", Price=499.99, Tags=["Electronics", "Mobile"]
Output JSON (formatted):
{
  "name": "Smartphone",
  "price": 499.99,
  "tags": ["Electronics", "Mobile"]
}
```

## Key Concepts

| Concept | Purpose |
|---------|---------|
| **Deserialization** | Converts JSON text into C# objects so data can be accessed as properties |
| **Serialization** | Converts C# objects into JSON strings for APIs, file storage, or network transfer |
| **JsonConvert** | Newtonsoft.Json utility class that handles JSON conversion |
| **Formatting.Indented** | Makes JSON output readable with proper indentation |

## Classes Used

- **Product**: Base class with properties Name, Price, and Tags
- **Samuel**: Inherits from Product (can be extended with additional properties)
- **Program**: Contains the Main method demonstrating serialization and deserialization

## How to Run

1. Ensure Newtonsoft.Json NuGet package is installed
2. Build the project: `dotnet build`
3. Run the program: `dotnet run`

## Output

The program will display:

- Deserialized product details from the JSON string
- Serialized JSON representation of the Samuel object in formatted (indented) form

## Dependencies

- **Newtonsoft.Json** - For JSON serialization/deserialization functionality
