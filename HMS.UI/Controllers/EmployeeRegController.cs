using HMS.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HMS.UI.Controllers
{
    public class EmployeeRegController : Controller
    {
        private IConfiguration _configuration;
        public EmployeeRegController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> EmployeeIndex()
        {
            IEnumerable<Employee> employeeresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Employee/GetEmployees";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        employeeresult = JsonConvert.DeserializeObject<IEnumerable<Employee>>(result);
                    }
                }
            }
            return View(employeeresult);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Employee/AddEmployee";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "  Employee details saved successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
    }
}
