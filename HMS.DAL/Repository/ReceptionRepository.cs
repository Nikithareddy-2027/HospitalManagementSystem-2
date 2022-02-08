using HMS.DAL.Data;
using HMS.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMS.DAL.Repository
{
    public class ReceptionRepository:IReceptionRepository
    {
        HMSDbContext _hMSDbContext;
        public ReceptionRepository(HMSDbContext hMSDbContext)
        {
            _hMSDbContext = hMSDbContext;
        }
        public void AddAppointment(Reception reception)
        {
            _hMSDbContext.reception.Add(reception);
            _hMSDbContext.SaveChanges();
        }

        public void DeleteAppointment(int PatientId)
        {
            var reception = _hMSDbContext.reception.Find(PatientId);
            _hMSDbContext.reception.Remove(reception);
            _hMSDbContext.SaveChanges();

        }

        public Reception GetAppointmentById(int PatientId)
        {
            return _hMSDbContext.reception.Find(PatientId);
        }

        public IEnumerable<Reception> GetAppointments()
        {
            return _hMSDbContext.reception.ToList();
        }

        public void UpdateAppointment(Reception reception)
        {
            _hMSDbContext.Entry(reception).State = EntityState.Modified;
            _hMSDbContext.SaveChanges();
        }
    }
}
