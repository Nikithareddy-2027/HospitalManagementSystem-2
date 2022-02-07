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
    public class PatientController : ControllerBase
    {
        private PatientServices _patientServices;
        public PatientController(PatientServices patientServices)
        {
            _patientServices = patientServices;
        }
        [HttpGet("GetPatients")]
        public IEnumerable<PatientReg> GetPatients()
        {
            return _patientServices.GetPatients();
        }
        [HttpPost("AddPatient")]
        public IActionResult AddPatient([FromBody] PatientReg patientReg)
        {
            _patientServices.AddPatient(patientReg);
            return Ok(" Patient registered successfully!!");
        }
        [HttpDelete("DeletePatient")]
        public IActionResult DeletePatient(int PatientId)
        {
            _patientServices.DeletePatient(PatientId);
            return Ok("Patient deleted successfully!!");
        }
        [HttpPut("UpdatePatient")]
        public IActionResult UpdatePatient([FromBody] PatientReg patientReg)
        {
            _patientServices.UpdatePatient(patientReg);
            return Ok("Patient updated successfully!!");
        }
    }
}
