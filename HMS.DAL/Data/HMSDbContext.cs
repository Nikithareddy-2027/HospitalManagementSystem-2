using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using HMS.Entity.Models;

namespace HMS.DAL.Data
{
    public class HMSDbContext:DbContext
    {
        public HMSDbContext(DbContextOptions<HMSDbContext> options) : base(options)
        {

        }
        public DbSet<PatientReg> patientReg { get; set; }
        public DbSet<Doctor> doctor { get; set; }
        public DbSet<Employee> employee { get; set; }
        public DbSet<Reception> reception { get; set; }
        public DbSet<Pharmacy> pharmacy { get; set; }
    }
}
