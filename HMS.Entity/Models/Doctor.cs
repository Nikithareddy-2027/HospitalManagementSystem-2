using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HMS.Entity.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }
        public virtual string DoctorName { get; set; }
        public string DoctorQualification { get; set; }
        public string DoctorSpecialization { get; set; }
        public int ConsultFee { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ReEnterPassword { get; set; }
    }
}
