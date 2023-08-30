﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Medication
    { 
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string MedicationName { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int FormID { get; set; }
       
        [Required]
        [Column(TypeName = "int")]
        public int ScheduleID { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}
