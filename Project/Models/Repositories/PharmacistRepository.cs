using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class PharmacistRepository:IPharmacistRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PharmacistRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Pharmacist AddPharmacist(Pharmacist pharmacist)
        {
            dbContext.Pharmacists.Add(pharmacist);
            dbContext.SaveChanges();
            return pharmacist;
        }

        public Pharmacist DeletePharmacist(Pharmacist pharmacist)
        {
            pharmacist.Deleted = 1;
            dbContext.Pharmacists.Update(pharmacist);
            dbContext.SaveChanges();
            return pharmacist;
        }

        public Pharmacist GetPharmacist(int id)
        {
            Pharmacist pharmacist = dbContext.Pharmacists.Find(id);
            return pharmacist;
        }

        public Pharmacist GetPharmacistByUserID(string id)
        {
            List<Pharmacist> pharmacists = dbContext.Pharmacists.Where(z => z.UserId == id).ToList();
            Pharmacist pharmacist = new Pharmacist();
            foreach (Pharmacist a in pharmacists)
            {
                if (a.UserId == id)
                {
                    pharmacist = a;
                    break;
                }
            }
            return pharmacist;
        }

        public List<Pharmacist> ListPharmacists()
        {
            List<Pharmacist> pharmacists = new List<Pharmacist>();
            foreach (Pharmacist a in dbContext.Pharmacists)
            {
                if (a.Deleted == 0)
                { pharmacists.Add(a); }
            }
            return pharmacists;
        }

        public Pharmacist UpdatePharmacist(Pharmacist pharmacist)
        {
            dbContext.Pharmacists.Update(pharmacist);
            dbContext.SaveChanges();
            return pharmacist;
        }
    }
}
