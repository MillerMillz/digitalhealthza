using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class DispenseDetails
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int LineID { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int PharmacyID { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int PharmacistID { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}
