using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Prescription
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
       
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; }
        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}
