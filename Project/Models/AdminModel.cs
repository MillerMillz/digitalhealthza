using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class AdminModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int AdminID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string AdminName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string AdminSurname { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string AddressLine1 { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string AddressLine2 { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string IDNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string ContactNo { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("Surburb")]
        public int SurburbID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Gender { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DOB { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}
