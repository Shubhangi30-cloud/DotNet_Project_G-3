using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        ETradingSystemDBEntities1 db = new ETradingSystemDBEntities1();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Vendor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [Authorize(Roles = "Customer")]
        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_id,Customer_name,Gender,DOB,Address,Phone_no")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        [Authorize(Roles = "Customers")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                id = GetLoggedInCustomerId();
            }
            var loggedInCustomerId = GetLoggedInCustomerId();

            if (id != loggedInCustomerId)
            {
                // Unauthorized access to edit other vendor profiles
                return RedirectToAction("AccessDenied", "Error");
            }

            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        private int GetLoggedInCustomerId()
        {
            //Implement a method to get the CustomerId of the logged-in user
            return 1;
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Customer_name,Gender,DOB,Address,Phone_no")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

    }
}