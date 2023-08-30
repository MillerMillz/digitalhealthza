﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Strength
    {
        [Key]
        public int ID { get; set; }
        public string TheStrength { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}
