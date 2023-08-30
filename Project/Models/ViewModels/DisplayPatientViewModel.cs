using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.ViewModels
{
    public class DisplayPatientViewModel
    {
        public string Email { get; set; }
        public Patient Patient { get; set; }
        public City city { get; set; }
        public Surburb Surburb { get; set; }
        public Province Province { get; set; }
    }
}
