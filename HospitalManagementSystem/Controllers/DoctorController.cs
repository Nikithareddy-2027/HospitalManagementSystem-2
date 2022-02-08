using HMS.BAL.Services;
using HMS.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private DoctorServices _doctorServices;
        public DoctorController(DoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
        }
        [HttpGet("GetDoctors")]
        public IEnumerable<Doctor> GetDoctors()
        {
            return _doctorServices.GetDoctors();
        }
        [HttpPost("AddDoctor")]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            _doctorServices.AddDoctor(doctor);
            return Ok(" Doctor registered successfully!!");
        }
        [HttpDelete("DeleteDoctor")]
        public IActionResult DeleteDoctor(int DoctorId)
        {
            _doctorServices.DeleteDoctor(DoctorId);
            return Ok("Doctor deleted successfully!!");
        }
        [HttpPut("UpdateDoctor")]
        public IActionResult UpdateDoctor([FromBody] Doctor doctor)
        {
            _doctorServices.UpdateDoctor(doctor);
            return Ok(" Doctor successfully!!");
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Doctor doctor)
        {
            Doctor user = _doctorServices.Login(doctor);
            if (user != null)
                return Ok("Login success!!");
            else
                return NotFound();
        }
    }
}
