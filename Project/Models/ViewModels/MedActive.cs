using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.ViewModels
{
    public class MedActive
    {
        public int ID { get; set; }
        public string FormName { get; set; }
        public Medication Medication { get; set; }
        public List<ActiveIngredient> ActiveIngredients { get; set; }
    }
}
