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
    public class EmployeeController : ControllerBase
    {
        private EmployeeServices _employeeServices;
        public EmployeeController(EmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }
        [HttpGet("GetEmployees")]
        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeServices.GetEmployees();
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            _employeeServices.AddEmployee(employee);
            return Ok(" Employee registered successfully!!");
        }
        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int EmployeeId)
        {
            _employeeServices.DeleteEmployee(EmployeeId);
            return Ok("Employee deleted successfully!!");
        }
        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            _employeeServices.UpdateEmployee(employee);
            return Ok(" Employee successfully!!");
        }
    }
}
