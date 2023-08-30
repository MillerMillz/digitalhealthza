using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.ViewModels
{
    public class MedicationViewModel
    {
        public string MedicationName { get; set; }
        public string Instruction { get; set; }
        public int MedicationID { get; set; }
        public int repeats { get; set; }
        public int LineID { get; set; }
        public int Qty { get; set; }
        public int repeatsLeft { get; set; }
        public bool Dispense { get; set; }
        public List<UnitMedicationViewModel> ActiveIngredients { get; set; }
    }
}
