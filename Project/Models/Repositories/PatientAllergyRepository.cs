using Project.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public class PatientAllergyRepository:IPatientAllergyRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PatientAllergyRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public PatientAllergy AddPatientAllergy(PatientAllergy patientAllergy)
        {
            dbContext.PatientAllergies.Add(patientAllergy);
            dbContext.SaveChanges();
            return patientAllergy;
        }

        public PatientAllergy FindPatientAllergy(int id)
        {
            PatientAllergy patientAllergy = dbContext.PatientAllergies.Find(id);
            return patientAllergy;
        }

        public PatientAllergy DeletePatientAllergy(PatientAllergy patientAllergy)
        {
            patientAllergy.Deleted = 1;
            dbContext.PatientAllergies.Update(patientAllergy);
            dbContext.SaveChanges();
            return patientAllergy;
        }

        public List<PatientAllergy> ListePatientAllergies()
        {
            List<PatientAllergy> patientAllergies = new List<PatientAllergy>();
            foreach (PatientAllergy a in dbContext.PatientAllergies)
            {
                if (a.Deleted == 0)
                { patientAllergies.Add(a); }
            }
            return patientAllergies;
        }

        public PatientAllergy UpdatePatientAllergy(PatientAllergy patientAllergy)
        {
            dbContext.PatientAllergies.Update(patientAllergy);
            dbContext.SaveChanges();
            return patientAllergy;
        }

        public List<PatientAllergy> AddPatientAllergyInBulk(List<PatientAllergy> patientAllergies)
        {
            foreach (PatientAllergy item in patientAllergies)
            {
                dbContext.PatientAllergies.Add(item);
            }
            dbContext.SaveChanges();
            return patientAllergies;

        }
    }
}
