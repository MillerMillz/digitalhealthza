using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class PrescriptionLine
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int MedID { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int PrescriptionID { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Instruction { get; set; }
        public int RepeatsLeft { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int Repeats { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}
