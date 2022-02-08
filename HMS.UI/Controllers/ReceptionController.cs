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
    public class ReceptionController : Controller
    {
        private IConfiguration _configuration;
        public ReceptionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> ReceptionIndex()
        {
            IEnumerable<Reception> receptionresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Reception/GetAppointments";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        receptionresult = JsonConvert.DeserializeObject<IEnumerable<Reception>>(result);
                    }
                }
            }
            return View(receptionresult);
        }
        public IActionResult AddAppointment()
        {
            return View();
        }
        [HttpPost("AddAppointment")]
        public async Task<IActionResult> AddAppointment(Reception reception)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(reception), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Reception/AddAppointment";
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
        [HttpPost("EditReception")]
        public async Task<IActionResult> EditReception(Reception reception)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(reception), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Reception/EditDoctor";
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
