using Project.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public class PharmacyRepository:IPharmacyRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PharmacyRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Pharmacy AddPharmacy(Pharmacy pharmacy)
        {
            dbContext.Pharmacies.Add(pharmacy);
            dbContext.SaveChanges();
            return pharmacy;
        }

        public Pharmacy DeletePharmacy(Pharmacy pharmacy)
        {
            pharmacy.Deleted = 1;
            dbContext.Pharmacies.Update(pharmacy);
            dbContext.SaveChanges();
            return pharmacy;
        }

        public Pharmacy GetPharmacy(int id)
        {
            Pharmacy pharmacy = dbContext.Pharmacies.Find(id);
            return pharmacy;
        }

        public List<Pharmacy> ListPharmacies()
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            foreach (Pharmacy a in dbContext.Pharmacies)
            {
                if (a.Deleted == 0)
                { pharmacies.Add(a); }
            }
            return pharmacies;
        }

        public Pharmacy UpdatePharmacy(Pharmacy pharmacy)
        {
            dbContext.Pharmacies.Update(pharmacy);
            dbContext.SaveChanges();
            return pharmacy;
        }
    }
}
