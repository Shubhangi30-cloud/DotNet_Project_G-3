using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project.Models;
//user table is wrong
namespace Project.Controllers
{
    public class AuthenticationController : Controller
    {
        ETradingSystemDBEntities1 db = new ETradingSystemDBEntities1();
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                //Add user to the database
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel user)
        {
            if (ModelState.IsValid)
            {
                // Login logic, authenticate user
                var authenticatedUser = AuthenticateUser(user.Username, user.Password);

                if (authenticatedUser != null)
                {
                    // Perform login actions (e.g., set authentication cookie)
                    FormsAuthentication.SetAuthCookie(authenticatedUser.UserName, false);

                    // Redirect to the user's dashboard based on their role
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                }
            }

            return View(user);
        }

        private User AuthenticateUser(string username, string password)
        {          
            // Check the username and password against the database

            return db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        //private string GetUserDashboardController(string role)
        //{
        //    switch (role)
        //    {
        //        case "Admin":
        //            return "Admin";
        //        case "Customer":
        //            return "Customer";
        //        case "Vendor":
        //            return "Vendor";
        //        default:
        //            return "Home";
        //    }
        //}
    }
}