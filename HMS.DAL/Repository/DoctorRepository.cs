using HMS.DAL.Data;
using HMS.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMS.DAL.Repository
{
    public class DoctorRepository:IDoctorRepository
    {
        HMSDbContext _hMSDbContext;
        public DoctorRepository(HMSDbContext hMSDbContext)
        {
            _hMSDbContext = hMSDbContext;
        }
        public void AddDoctor(Doctor doctor)
        {
            _hMSDbContext.doctor.Add(doctor);
            _hMSDbContext.SaveChanges();
        }

        public void DeleteDoctor(int DoctorId)
        {
            var doctor = _hMSDbContext.doctor.Find(DoctorId);
            _hMSDbContext.doctor.Remove(doctor);
            _hMSDbContext.SaveChanges();

        }


        public Doctor GetDoctorById(int DoctorId)
        {
            return _hMSDbContext.doctor.Find(DoctorId);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _hMSDbContext.doctor.ToList();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _hMSDbContext.Entry(doctor).State = EntityState.Modified;
            _hMSDbContext.SaveChanges();
        }
    }
}
