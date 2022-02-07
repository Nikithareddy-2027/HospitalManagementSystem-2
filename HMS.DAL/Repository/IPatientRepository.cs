using HMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.DAL.Repository
{
    public interface IPatientRepository
    {
        void AddPatient(PatientReg patientReg);
        void UpdatePatient(PatientReg patientReg);
        void DeletePatient(int PatientId);
        PatientReg GetPatientById(int PatientId);
        IEnumerable<PatientReg> GetPatients();
    }
}
