using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class MedicalHistoryRepository:IMedicalHistoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MedicalHistoryRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public MedicalHistory AddMedicalHistory(MedicalHistory medicalHistory)
        {
            dbContext.MedicalHistories.Add(medicalHistory);
            dbContext.SaveChanges();
            return medicalHistory;
        }

        public List<MedicalHistory> AddMedicalHistoryInBulk(List<MedicalHistory> medicalHistories)
        {
            foreach (MedicalHistory item in medicalHistories)
            {
                dbContext.MedicalHistories.Add(item);
            }
            dbContext.SaveChanges();
            return medicalHistories;
        }

        public MedicalHistory DeleteMedicalHistory(MedicalHistory medicalHistory)
        {
            medicalHistory.Deleted = 1;
            dbContext.MedicalHistories.Update(medicalHistory);
            dbContext.SaveChanges();
            return medicalHistory;
        }

        public MedicalHistory GetMedicalHistory(int id)
        {
            MedicalHistory medicalHistory = dbContext.MedicalHistories.Find(id);
            return medicalHistory;
        }

        public List<MedicalHistory> ListMedicalHistories()
        {
            List<MedicalHistory> medicalHistories = new List<MedicalHistory>();
            foreach (MedicalHistory a in dbContext.MedicalHistories)
            {
                if (a.Deleted == 0)
                { medicalHistories.Add(a); }
            }
            return medicalHistories;
        }

        public MedicalHistory UpdateMedicalHistory(MedicalHistory medicalHistory)
        {
            dbContext.MedicalHistories.Update(medicalHistory);
            dbContext.SaveChanges();
            return medicalHistory;
        }
    }
}
