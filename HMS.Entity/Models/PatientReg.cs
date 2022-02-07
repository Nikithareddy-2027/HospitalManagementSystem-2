using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HMS.Entity.Models
{
    public class PatientReg
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        
        public virtual string PatientName { get; set; }
        public string AdmissionDate { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string BloodGroup { get; set; }
        public string PatientIssue { get; set; }
        public string PatientType { get; set; }
        public string DoctorName { get; set; }
        public string DoctorType { get; set; }
        public int WardNumber { get; set; }
        public int BedNumber { get; set; }
    }
}

