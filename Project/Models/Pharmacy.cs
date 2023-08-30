using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Pharmacy
    {
        [Key]
        public int PharmacyID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string PharmacyName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string ContactNo { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LicenseNo { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string AddressLine1 { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string AddressLine2 { get; set; }
        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("Surburb")]
        public int SurburbID { get; set; }
       
        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("Pharmacist")]
        public int PharmacistID { get; set; }

       

        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("City")]
        public int CityID { get; set; }
       

        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}
