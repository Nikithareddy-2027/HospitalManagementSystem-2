using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HMS.Entity.Models
{
    public class Reception
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }
        public DateTime AppointmentTime{get;set;}
        public Doctor doctor { get; set; }
        [ForeignKey("DoctorId")]
        public string DoctorId { get; set; }
        //public Employee employee { get; set; }
        //[ForeignKey("EmployeeId")]
        //public string EmployeeId { get; set; }
        public PatientReg patientReg { get; set; }
        [ForeignKey("PatientId")]
        public string PatientId { get; set; }
    }
}
