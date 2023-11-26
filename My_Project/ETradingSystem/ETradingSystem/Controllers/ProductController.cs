using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ETradingSystem.Models;
using Newtonsoft.Json;

namespace ETradingSystem.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        //action method to consume the WebApi product Get()
        public ActionResult Display()
        {
            IEnumerable<ProductMVC> productlist = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44316/swagger/");
                var responsetask = webclient.GetAsync("Product");
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    productlist = JsonConvert.DeserializeObject<List<ProductMVC>>(resultdata);
                }
                else
                {
                    productlist = Enumerable.Empty<ProductMVC>();
                    ModelState.AddModelError(string.Empty, "Some Error Occured..Try Later");
                }
                return View(productlist);
            }
        }

        //create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductMVC mvcprod)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44316/swagger/");
                var posttask = webclient.PostAsJsonAsync<ProductMVC>("Product", mvcprod);
                posttask.Wait();
                var dataresult = posttask.Result;
                if (dataresult.IsSuccessStatusCode)
                {
                    return RedirectToAction("Display");
                }
                ModelState.AddModelError(string.Empty, "Creation failed.. Try Later");
                return View(mvcprod);
            }
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMVC product = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44316/swagger/");
                var responsetask = webclient.GetAsync("product/" + id).Result;
                if (responsetask.IsSuccessStatusCode)
                {
                    var resultdata = responsetask.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<ProductMVC>(resultdata);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server Error, try later");
                }
            }
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductID,ProductName,Price,QuantityAvailable")] ProductMVC p)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44316/swagger/");
                    var response = await client.PutAsJsonAsync("Product/Edit", p);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Display");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Please try Later.");
                    }
                }
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}