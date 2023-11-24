using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETradingSystem.Models;


namespace ETradingSystem.Controllers
{
    public class VendorController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            IEnumerable<VendorMVC> vendorlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Vendor").Result;
            vendorlist = response.Content.ReadAsAsync<IEnumerable<VendorMVC>>().Result;
            return View(vendorlist);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new VendorMVC());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Vendor/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<VendorMVC>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(VendorMVC vendor)
        {
            if (vendor.vendor_id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Vendor", vendor).Result;
                return RedirectToAction("Index");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Vendor/" + vendor.vendor_id, vendor).Result;
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Department/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}