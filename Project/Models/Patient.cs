using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string PatientName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string PatientSurname { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(450)")]
        public string AddressLine1 { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ContactNo { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        public string AddressLine2 { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string IDNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(450)")]
        public string Gender { get; set; }
        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("Surburb")]
        public int SurburbID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(450)")]
        public string IsNew { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(450)")]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}
