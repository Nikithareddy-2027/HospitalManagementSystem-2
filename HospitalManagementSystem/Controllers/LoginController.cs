using HMS.DAL.Data;
using HMS.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly HMSDbContext _context;

        public LoginController(IConfiguration config, HMSDbContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("DoctorLogin")]
        public async Task<IActionResult> DoctorLogin(Doctor _doctor)
        {

            if (_doctor != null && _doctor.Email != null && _doctor.Password != null)
            {
                var user = await GetDoctors(_doctor.Email, _doctor.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("DoctorId", user.DoctorId.ToString()),
                    new Claim("DoctorName", user.DoctorName),
                    new Claim("DoctorQualification", user.DoctorQualification),
                    new Claim("DoctorSpecialization", user.DoctorSpecialization),
                    new Claim("ConsultFee", user.ConsultFee.ToString()),
                    new Claim("Email", user.Email),
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Doctor> GetDoctors(string email, string password)
        {
            Doctor doctor = null;
            var result = _context.doctor.Where(u => u.Email == email && u.Password == password);
            foreach (var item in result)
            {
                doctor = new Doctor();
                doctor.DoctorId = item.DoctorId;
                doctor.DoctorName = item.DoctorName;
                doctor.DoctorQualification = item.DoctorQualification;
                doctor.DoctorSpecialization = item.DoctorSpecialization;
                doctor.ConsultFee = item.ConsultFee;
                doctor.Email = item.Email;
            }
            return doctor;

        }
    }
}
