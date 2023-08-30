using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LineActiveIngre
    {

        [Key]
        public int ID { get; set; }
        public int LineID { get; set; }
        public int AISID { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;

    }
}
