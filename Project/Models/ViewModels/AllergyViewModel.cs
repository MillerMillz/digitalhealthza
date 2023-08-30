using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class AllergyViewModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ActiveIngredient> states { get; set; }
        public List<int> Selection { get; set; }
    }
}
