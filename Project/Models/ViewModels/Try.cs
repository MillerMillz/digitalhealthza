using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Try
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Medication> states { get; set; }
        public List<DateTime> Dates { get; set; }
        public List<int> IDs { get; set; }
    }
}
