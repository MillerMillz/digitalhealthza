using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IMedicationRepository
    {
        public Medication AddMedication(Medication medication);
        public Medication UpdateMedication(Medication medication);
        public Medication DeleteMedication(Medication medication);
        public Medication GetMedication(int id);
        public List<Medication> ListMedications();
    }
}
