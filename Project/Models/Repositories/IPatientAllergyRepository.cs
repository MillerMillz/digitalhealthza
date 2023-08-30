using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IPatientAllergyRepository
    {
        public PatientAllergy AddPatientAllergy(PatientAllergy patientAllergy);
        public List<PatientAllergy> AddPatientAllergyInBulk(List<PatientAllergy> patientAllergies);
        public PatientAllergy UpdatePatientAllergy(PatientAllergy patientAllergy);
        public PatientAllergy DeletePatientAllergy(PatientAllergy patientAllergy);
        public PatientAllergy FindPatientAllergy(int id);
        public List<PatientAllergy> ListePatientAllergies();
    }
}
