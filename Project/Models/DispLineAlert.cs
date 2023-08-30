
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class DispLineAlert
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("DispenseLine")]
        public int LineID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Alert { get; set; }
       
        [Column(TypeName = "nvarchar(50)")]
        public string Reason { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;

    }
}
