using HMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.DAL.Repository
{
    public interface IDoctorRepository
    {
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int DoctorId);
        Doctor GetDoctorById(int DoctorId);
        IEnumerable<Doctor> GetDoctors();
        Doctor Login(Doctor doctor);
    }
}
