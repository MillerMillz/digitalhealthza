using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int PatientID { get; set; }
        public int LoginID { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        [Column(TypeName = "int")]
        public int Deleted { get; set; } = 0;
    }
}

