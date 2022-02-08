using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HMS.Entity.Models
{//tis all small fix..  checking datatypes and all.. 
    public class Pharmacy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineId { get; set; }

        public virtual PatientReg patientRegs { get; set; }
        [ForeignKey("patientRegs")]
        public int PatientId { get; set; }

        public virtual Doctor doctor { get; set; }
        [ForeignKey("doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctors { get; set; }
        
        public string MedicineName { get; set; }
        public string MedicineIssue { get; set; }
        public string MedicineTime { get; set; }
        public bool pharmacyStock { get; set; }
    }
}
