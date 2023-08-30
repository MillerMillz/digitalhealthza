using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class MedicationRepository:IMedicationRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MedicationRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Medication AddMedication(Medication medication)
        {
            dbContext.Medications.Add(medication);
            dbContext.SaveChanges();
            return medication;
        }

        public Medication DeleteMedication(Medication medication)
        {
            medication.Deleted = 1;
            dbContext.Medications.Update(medication);
            dbContext.SaveChanges();
            return medication;
        }

        public Medication GetMedication(int id)
        {
            Medication medication = dbContext.Medications.Find(id);
            return medication;
        }

        public List<Medication> ListMedications()
        {
            List<Medication> medications = new List<Medication>();
            foreach (Medication a in dbContext.Medications)
            {
                if (a.Deleted == 0)
                { medications.Add(a); }
            }
            return medications;
        }

        public Medication UpdateMedication(Medication medication)
        {
            dbContext.Medications.Update(medication);
            dbContext.SaveChanges();
            return medication;
        }
    }
}
