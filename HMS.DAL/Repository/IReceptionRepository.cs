using HMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.DAL.Repository
{
    public interface IReceptionRepository
    {
        void AddAppointment(Reception reception);
        void UpdateAppointment(Reception reception);
        void DeleteAppointment(int PatientId);
        Reception GetAppointmentById(int PatientId);
        IEnumerable<Reception> GetAppointments();
    }
}
