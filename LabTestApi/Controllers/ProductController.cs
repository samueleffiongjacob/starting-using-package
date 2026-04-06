using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    // In-memory list to store products for demonstration purposes.
    private static List<Product> products = new List<Product>();

    // GET: api/products
    // Retrieve all products in the system.
    [HttpGet]
    public ActionResult<List<Product>> GetAll() => products;

    // GET: api/products/{id} : Retrieve a single product by its ID.
    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        // Find the product by ID in the in-memory list.
        var product = products.FirstOrDefault(p => p.Id == id);
        // block to check if product exists and return appropriate response.
        return product != null ? Ok(product) : NotFound(); // block 1 and 2
    }
 
    // POST: api/products: Create a new product with the provided details in the request body.
    [HttpPost]
    public ActionResult<Product> Create(Product newproduct)
    {
        // Auto-increment the product ID based on the current list of products.
        // newproduct.Id = products.Count + 1; // Simple auto-increment logic, not suitable for production but works for in-memory demo.
        newproduct.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1; // Auto-increment ID
        products.Add(newproduct);
        return CreatedAtAction(nameof(GetById), new { id = newproduct.Id }, newproduct);// block 3
    }

    // PUT: api/products/{id}
    // Update an existing product by its ID with the details provided in the request body.
    [HttpPut("{id}")]
    public ActionResult Update(int id, Product updatedProduct)
    {
        var Product = products.FirstOrDefault(p => p.Id == id);
        if (Product == null)
        {
            return NotFound();
        }
        // Update the product details with the values from the request body.
        Product.Name = updatedProduct.Name;
        Product.Description = updatedProduct.Description;
        Product.Price = updatedProduct.Price;
        return Ok(Product);// block 4 : test api seee response body with updated product details.
        //return NoContent(); // return NoContent() if you don't want to return the updated product in the response.
    }

    // DELETE: api/products/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        // Find the product by ID and remove it from the list if it exists.
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
       
       // Remove the product from the list and return an appropriate response.
        products.Remove(product);
        return Ok(product); // block 4 : test api seee response body with deleted product details.
        // return NoContent(); // block 5 : return NoContent() to indicate successful deletion without returning any content in the response body.
    }
}