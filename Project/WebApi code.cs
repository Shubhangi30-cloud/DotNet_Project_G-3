using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
public class ProductsController : ApiController
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    private static List<Product> products = new List<Product>
    {
        new Product { id = 1, Name = "Product 1", Price = 10 },
        new Product { id = 2, Name = "Product 2", Price = 20 }
    };
    private object _products;
    // GET 
    public IHttpActionResult Get(int id)
    {
        var product = products.FirstOrDefault(p => p.id == id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    // POST
    public IHttpActionResult Post([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest("Invalid product data");
        }

        product.id = products.Count + 1;
        products.Add(product);

        return CreatedAtRoute("DefaultApi", new { id = product.id }, product);
    }
    // PUT 
    public IHttpActionResult Put(int id, [FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest("Invalid product data");
        }

        var existingProduct = products.FirstOrDefault(p => p.id == id);
        if (existingProduct == null)
        {
            return NotFound();
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;

        return Ok(existingProduct);
    }
    // DELETE 
    public IHttpActionResult Delete(int id)
    {
        var product = products.FirstOrDefault(p => p.id == id);
        if (product == null)
        {
            return NotFound();
        }
        products.Remove(product);
        return Ok(product);
    }
}
