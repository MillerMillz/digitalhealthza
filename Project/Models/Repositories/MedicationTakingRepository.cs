using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class MedicationTakingRepository:IMedicationTakingRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MedicationTakingRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public MedicationTaking AddMedicationTaking(MedicationTaking medicationTaking)
        {
            dbContext.MedicationTakings.Add(medicationTaking);
            dbContext.SaveChanges();
            return medicationTaking;
        }

        public List<MedicationTaking> AddMedicationTakingInBulk(List<MedicationTaking> medicationTakings)
        {
            foreach (MedicationTaking item in medicationTakings)
            {
                dbContext.MedicationTakings.Add(item);
            }
            dbContext.SaveChanges();
            return medicationTakings;
        }

        public MedicationTaking DeleteMedicationTaking(MedicationTaking medicationTaking)
        {
            medicationTaking.Deleted = 1;
            dbContext.MedicationTakings.Update(medicationTaking);
            dbContext.SaveChanges();
            return medicationTaking;
        }

        public MedicationTaking GetMedicationTaking(int id)
        {
            MedicationTaking medicationTaking = dbContext.MedicationTakings.Find(id);
            return medicationTaking;
        }

        public List<MedicationTaking> ListMedicationTakings()
        {
            List<MedicationTaking> medicationTakings = new List<MedicationTaking>();
            foreach (MedicationTaking a in dbContext.MedicationTakings)
            {
                if (a.Deleted == 0)
                { medicationTakings.Add(a); }
            }
            return medicationTakings;
        }

        public MedicationTaking UpdateMedicationTaking(MedicationTaking medicationTaking)
        {
            dbContext.MedicationTakings.Update(medicationTaking);
            dbContext.SaveChanges();
            return medicationTaking;
        }
    }
}
