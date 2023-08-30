using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class MedPracticeRepository:IMedPracticeRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MedPracticeRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public MedPractice AddMedPractice(MedPractice medPractice)
        {
            dbContext.MedPractices.Add(medPractice);
            dbContext.SaveChanges();
            return medPractice;
        }

        public MedPractice DeleteMedPractice(MedPractice medPractice)
        {
            medPractice.Deleted = 1;
            dbContext.MedPractices.Update(medPractice);
            dbContext.SaveChanges();
            return medPractice;
        }

        public MedPractice GetMedPractice(int id)
        {
            MedPractice medPractice = dbContext.MedPractices.Find(id);
            return medPractice;
        }

        public List<MedPractice> ListMedPractices()
        {
            List<MedPractice> medPractices = new List<MedPractice>();
            foreach (MedPractice a in dbContext.MedPractices)
            {
                if (a.Deleted == 0)
                { medPractices.Add(a); }
            }
            return medPractices;
        }

        public MedPractice UpdateMedPractice(MedPractice medPractice)
        {
            dbContext.MedPractices.Update(medPractice);
            dbContext.SaveChanges();
            return medPractice;
        }
    }
}
