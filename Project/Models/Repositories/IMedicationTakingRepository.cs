using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IMedicationTakingRepository
    {
        public MedicationTaking AddMedicationTaking(MedicationTaking medicationTaking);
        public List<MedicationTaking> AddMedicationTakingInBulk(List<MedicationTaking> medicationTakings);
        public MedicationTaking UpdateMedicationTaking(MedicationTaking medicationTaking);
        public MedicationTaking DeleteMedicationTaking(MedicationTaking medicationTaking);
        public MedicationTaking GetMedicationTaking(int id);
        public List<MedicationTaking> ListMedicationTakings();
    }
}
