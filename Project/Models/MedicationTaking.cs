using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class MedicationTaking
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int MedID { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int PatientID { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}
