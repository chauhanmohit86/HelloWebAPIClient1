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
using System.Net.Http.Formatting;

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
            Employee empl1 = new Employee();
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/Employee/");

            if (response.IsSuccessStatusCode)
            {
                string a = response.Content.ReadAsStringAsync().Result.Trim().Replace(@"\", "");
                a = a.Substring(1, a.Length - 2);
                JavaScriptSerializer j = new JavaScriptSerializer();
                empl1 = j.Deserialize<Employee>(a);
                //var empl1 = response.Content.ReadAsAsync<Employee>();
            }
            return View();
        }

        public async Task<ActionResult> GetEmployeeById(string empId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/HelloWebAPIApp/");
            Employee empl1 = new Employee();
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/Employee/" + empId);

            if (response.IsSuccessStatusCode)
            {
                //string a = response.Content.ReadAsStringAsync().Result.Trim().Replace(@"\", "");
                //a = a.Substring(1, a.Length - 2);
                //JavaScriptSerializer j = new JavaScriptSerializer();
                //empl1 = j.Deserialize<Employee>(a);
                empl1 = await response.Content.ReadAsAsync<Employee>();
            }
            return PartialView("_EmployeeById", empl1);
        }
    }
}