using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApI_Application.Models;


namespace WebApI_Application.Controllers
{
    public class ProductController : ApiController
    {
        ETSDBEntities db = new ETSDBEntities();
        //Get
        public IEnumerable<Product> Get()
        {
            return db.Products.ToList();
        }

        //Get By Id
        public Product Get(int Id)
        {
            return db.Products.FirstOrDefault(x => x.product_id == Id);
        }

        //Post
        public IHttpActionResult PostNewProduct([FromBody] Product p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validations Failed");
            }
            db.Products.Add(new Product()
            {
               product_id= p.product_id,
                brand_name= p.brand_name,
                brand_id = p.brand_id,
                brand_price = p.brand_price,
                availability = p.availability
            });
            db.SaveChanges();
            return Ok("Success");
        }

        //put or edit
        public IHttpActionResult Put([FromBody] Product p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok("Record Updated");
        }
        //delete
        public IHttpActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);

            if (product == null)
            {
                return NotFound();

            }

            db.Products.Remove(product);
            db.SaveChanges();
            return Ok("Deleted");
        }
    }
}
