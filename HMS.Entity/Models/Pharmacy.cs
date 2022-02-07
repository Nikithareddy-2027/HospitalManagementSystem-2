using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HMS.Entity.Models
{
    public class Pharmacy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineId { get; set; }

        [ForeignKey("PatientReg")]
        public string PatientId { get; set; }
        public virtual PatientReg PatientRegs { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public virtual Doctor Doctors { get; set; }
        
        public string MedicineName { get; set; }
        public string MedicineIssue { get; set; }
        public string MedicineTime { get; set; }
        public bool pharmacyStock { get; set; }
    }
}
