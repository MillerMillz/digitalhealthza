using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class SurburbRepository:ISurburbRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SurburbRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Surburb AddSurburb(Surburb surburb)
        {
            dbContext.Surburbs.Add(surburb);
            dbContext.SaveChanges();
            return surburb;
        }

        public Surburb DeleteSurburb(Surburb surburb)
        {
            surburb.Deleted = 1;
            dbContext.Surburbs.Update(surburb);
            dbContext.SaveChanges();
            return surburb;
        }

        public Surburb GetSurburb(int id)
        {
            Surburb surburb = dbContext.Surburbs.Find(id);
            return surburb;
        }

        public List<Surburb> ListSurburbs()
        {
            List<Surburb> surburbs = new List<Surburb>();
            foreach (Surburb a in dbContext.Surburbs)
            {
                if (a.Deleted == 0)
                { surburbs.Add(a); }
            }
            return surburbs;
        }

        public Surburb UpdateSurburb(Surburb surburb)
        {
            dbContext.Surburbs.Update(surburb);
            dbContext.SaveChanges();
            return surburb;
        }
    }
}
