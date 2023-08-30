using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ConditionDiagnosis
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName= "nvarchar(MAX)")]
        public string DiagnosisName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string ICD10Code { get; set; }

        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;

    }
}
