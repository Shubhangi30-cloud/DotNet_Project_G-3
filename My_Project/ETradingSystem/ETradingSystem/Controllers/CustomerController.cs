using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ETradingSystem.Models;
using Newtonsoft.Json;

namespace ETradingSystem.Controllers
{
    public class CustomerController : Controller
    {
        //action method to consume the WebApi product Get()
        public ActionResult Display()
        {
            IEnumerable<CustomerMVC> customerlist = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44316/swagger/");
                var responsetask = webclient.GetAsync("customer");
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    customerlist = JsonConvert.DeserializeObject<List<CustomerMVC>>(resultdata);
                }
                else
                {
                    customerlist = Enumerable.Empty<CustomerMVC>();
                    ModelState.AddModelError(string.Empty, "Some Error Occured..Try Later");
                }
                return View(customerlist);
            }
        }

    }
}
