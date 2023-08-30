using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.ViewModels
{
    public class DisplayPrescriptionViewModel
    {
        public Prescription Prescription { get; set; }

        public Doctor Doctor { get; set; }
    }
}
