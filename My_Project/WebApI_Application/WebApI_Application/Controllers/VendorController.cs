using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApI_Application.Models;

namespace WebApI_Application.Controllers
{
    public class VendorController : ApiController
    {
        ETSDBEntities db = new ETSDBEntities();

        //Get
        public IEnumerable<Vendor> Get()
        {
            return db.Vendors.ToList();
        }

        //Get By Id
        public Vendor Get(int Id)
        {
            return db.Vendors.FirstOrDefault(x => x.vendor_id == Id);
        }

        //Post
        public IHttpActionResult PostNewProduct([FromBody] Vendor v)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validations Failed");
            }
            db.Vendors.Add(new Vendor()
            {
                vendor_id = v.vendor_id,
                vendor_name = v.vendor_name,
                phone_no = v.phone_no,
                vendor_verification_card_id = v.vendor_verification_card_id
            });
            db.SaveChanges();
            return Ok("Success");
        }

        //put or edit
        public IHttpActionResult Put([FromBody] Vendor v)
        {
            if (ModelState.IsValid)
            {
                db.Entry(v).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok("Record Updated");
        }
        //delete
        public IHttpActionResult Delete(int id)
        {
            Vendor vendor = db.Vendors.Find(id);

            if (vendor == null)
            {
                return NotFound();
            }

            db.Vendors.Remove(vendor);
            db.SaveChanges();
            return Ok("Deleted");
        }
    }
}
