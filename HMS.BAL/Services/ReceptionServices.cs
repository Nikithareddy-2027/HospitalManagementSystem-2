using HMS.DAL.Repository;
using HMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.BAL.Services
{
    public class ReceptionServices
    {
        IReceptionRepository _receptionRepository;
        public ReceptionServices(IReceptionRepository receptionRepository)
        {
            _receptionRepository = receptionRepository;
        }
        public void AddAppointment(Reception reception)
        {
            _receptionRepository.AddAppointment(reception);
        }
        public void DeleteAppointment(int PatientId)
        {
            _receptionRepository.DeleteAppointment(PatientId);
        }
        public void GetAppointmentById(int PatientId)
        {
            _receptionRepository.GetAppointmentById(PatientId);
        }
        public void UpdateAppointment(Reception reception)
        {
            _receptionRepository.UpdateAppointment(reception);
        }
        public IEnumerable<Reception> GetAppointments()
        {
            return _receptionRepository.GetAppointments();
        }
    }
}
