using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string DoctorName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string DoctorSurname { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("ApplicationUser")]
        public int HighestQualificationID { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("MedPractice")]
        public int MedPracticeID { get; set; } //practice number

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string HCRegNo { get; set; }

       

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Gender { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}
