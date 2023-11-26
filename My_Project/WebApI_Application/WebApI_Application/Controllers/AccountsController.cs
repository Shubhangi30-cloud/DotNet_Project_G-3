using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApI_Application.Models;

namespace WebApI_Application.Controllers
{
    public class AccountsController : ApiController
    {
        ETSDBEntities db = new ETSDBEntities();
        // POST api/account/login
        public IHttpActionResult Login(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.SingleOrDefault(a => a.admin_name == admin.admin_name && a.password == admin.password);
                return Ok("Login successful");
            }
            return BadRequest("Invalid username or password");
        }

        [HttpPost]
        public IHttpActionResult RegisterCustomer([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return Ok("Customer registered successfully.");
            }
            return BadRequest("Invalid data for customer registration.");
        }

        public IHttpActionResult Login(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.SingleOrDefault(a => a.customer_name == customer.customer_name && a.password == customer.password);
                return Ok("Login successful");
            }
            return BadRequest("Invalid username or password");
        }

        [HttpPost]
        public IHttpActionResult RegisterVendor([FromBody] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return Ok("Vendor registered successfully.");
            }
            return BadRequest("Invalid data for vendor registration.");
        }

        public IHttpActionResult Login(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.SingleOrDefault(a => a.vendor_name == vendor.vendor_name && a.vendor_password == vendor.vendor_password);
                return Ok("Login successful");
            }
            return BadRequest("Invalid username or password");
        }


    }
}
