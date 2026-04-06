// Models/Product.cs
/*
 * This file defines the Product model class, which represents a product in the system.
 * It includes properties for Id, Name, Description, and Price.
 * This model can be used in API endpoints for creating, retrieving, updating, and deleting products objects.
 */
public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
}