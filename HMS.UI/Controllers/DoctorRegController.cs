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
    public class DoctorRegController : Controller
    {
        
        private IConfiguration _configuration;
        public DoctorRegController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> DoctorIndex()
        {
            IEnumerable<Doctor> doctorresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Doctor/GetDoctors";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        doctorresult = JsonConvert.DeserializeObject<IEnumerable<Doctor>>(result);
                    }
                }
            }
            return View(doctorresult);
        }
        public IActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost("AddDoctor")]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(doctor), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Doctor/AddDoctor";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "  Doctor details saved successfully!";
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
        [HttpPost("EditDoctor")]
        public async Task<IActionResult> EditDoctor(Doctor doctor)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(doctor), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Doctor/EditDoctor";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "  Doctor details edited successfully!";
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
