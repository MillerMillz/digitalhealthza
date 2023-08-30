using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class PrescrLineAlert
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("Prescription")]
        public int PrescriptionID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Alert { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Reason { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;

    }
}
