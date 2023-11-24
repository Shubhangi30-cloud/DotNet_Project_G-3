using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApI_Application.Models;

namespace WebApI_Application.Controllers
{
    public class CustomerController : ApiController
    {
        ETSDBEntities db = new ETSDBEntities();
        //Get
        public IEnumerable<Customer> Get()
        {
            return db.Customers.ToList();
        }

        //Get By Id
        public Customer Get(int Id)
        {
            return db.Customers.FirstOrDefault(x => x.customer_id == Id);
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

            /// delete
        public IHttpActionResult Delete(int id)
            {
                Customer customer = db.Customers.Find(id);

                if (customer == null)
                {
                    return NotFound();

                }

                db.Customers.Remove(customer);
                db.SaveChanges();
                return Ok("Deleted");
            }
        
    }
}
