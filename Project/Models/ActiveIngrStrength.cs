using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ActiveIngrStrength
    {
        [Key]
        public int ID { get; set; }
        public int ActiveIngrID { get; set; }
        public int StrengthID { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}
