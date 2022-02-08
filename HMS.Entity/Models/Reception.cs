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
        public string PatientName { get; set; }
        public int PatientWeight { get; set; }
        public string DoctorName { get; set; }
    }
}
