using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Pharmacist
    {
        [Key]
        public int PharmacistID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string PharmacistName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string PharmacistSurname { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ContactNo { get; set; }
        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("Pharmacy")]
        public int PharmacyID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]

        public string RegNo { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Gender { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}
