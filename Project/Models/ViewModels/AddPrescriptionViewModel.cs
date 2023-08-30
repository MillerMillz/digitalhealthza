using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.ViewModels
{
    public class AddPrescriptionViewModel
    {
        public string alert { get; set; }
        public string reason { get; set; }
        public string Drreason { get; set; }
        public List<MedicationViewModel> Medications { get; set; }
        public MedicationViewModel Current { get; set; }
    }
}
