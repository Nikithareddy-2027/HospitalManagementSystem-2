using HMS.DAL.Data;
using HMS.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMS.DAL.Repository
{
    public class PatientRepository:IPatientRepository
    {
        HMSDbContext _hMSDbContext;
        public PatientRepository(HMSDbContext hMSDbContext)
        {
            _hMSDbContext = hMSDbContext;
        }
        public void AddPatient(PatientReg patientReg)
        {
            _hMSDbContext.patientReg.Add(patientReg);
            _hMSDbContext.SaveChanges();
        }

        public void DeletePatient(int PatientId)
        {
            var patientReg = _hMSDbContext.patientReg.Find(PatientId);
            _hMSDbContext.patientReg.Remove(patientReg);
            _hMSDbContext.SaveChanges();
        }

        public PatientReg GetPatientById(int PatientId)
        {
            return _hMSDbContext.patientReg.Find(PatientId);
        }

        public IEnumerable<PatientReg> GetPatients()
        {
            return _hMSDbContext.patientReg.ToList();
        }

        public void UpdatePatient(PatientReg patientReg)
        {
            _hMSDbContext.Entry(patientReg).State = EntityState.Modified;
            _hMSDbContext.SaveChanges();
        }
    }
}
