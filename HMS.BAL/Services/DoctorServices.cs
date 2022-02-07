using HMS.DAL.Repository;
using HMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.BAL.Services
{
    public class DoctorServices
    {
        IDoctorRepository _doctorRepository;
        public DoctorServices(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public void AddDoctor(Doctor doctor)
        {
            _doctorRepository.AddDoctor(doctor);
        }
        public void DeleteDoctor(int DoctorId)
        {
            _doctorRepository.DeleteDoctor(DoctorId);
        }
        public void GetDoctorById(int DoctorId)
        {
            _doctorRepository.GetDoctorById(DoctorId);
        }
        public void UpdateDoctor(Doctor doctor)
        {
            _doctorRepository.UpdateDoctor(doctor);
        }
        public IEnumerable<Doctor> GetDoctors()
        {
            return _doctorRepository.GetDoctors();


        }
    }
}
