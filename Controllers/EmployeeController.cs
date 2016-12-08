using HelloWebAPIClient1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HelloWebAPIClient1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View("EmployeeDashboard");
        }

        public async Task<ActionResult> GetAllEmployee()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/HelloWebAPIApp/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage e = await client.GetAsync("api/Employee/");
            if(e.IsSuccessStatusCode)
            {
               var responsedata =  e.Content.ReadAsStringAsync().Result;
                var JsonObject = Json(responsedata, JsonRequestBehavior.AllowGet).Data;
                //foreach (var item in JsonObject)
                //{

                //}
                return View(JsonObject);
            }
            return View();
        }
    }
}