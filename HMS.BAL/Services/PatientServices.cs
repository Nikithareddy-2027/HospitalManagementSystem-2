using HMS.DAL.Repository;
using HMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.BAL.Services
{
    public class PatientServices
    {
        IPatientRepository _patientRepository;
        public PatientServices(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public void AddPatient(PatientReg patientReg)
        {
            _patientRepository.AddPatient(patientReg);
        }
        public void DeletePatient(int PatientId)
        {
            _patientRepository.DeletePatient(PatientId);
        }
        public void GetPatientById(int PatientId)
        {
            _patientRepository.GetPatientById(PatientId);
        }
        public void UpdatePatient(PatientReg patientReg)
        {
            _patientRepository.UpdatePatient(patientReg);
        }
        public IEnumerable<PatientReg> GetPatients()
        {
            return _patientRepository.GetPatients();
        }
    }
}
