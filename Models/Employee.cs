using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWebAPIClient1.Models
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmailID { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Salary { get; set; }
        public string City { get; set; }
    }
}