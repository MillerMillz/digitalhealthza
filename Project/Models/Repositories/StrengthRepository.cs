using Project.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public class StrengthRepository : IstrengthRepository
    {
        private readonly ApplicationDbContext dbContext;

        public StrengthRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Strength GetStrength(int id)
        {
            Strength strength = dbContext.Strengths.Find(id);
            return strength;
        }

        public List<Strength> ListStrengths()
        {
            List<Strength> strengths = new List<Strength>();
            foreach (Strength a in dbContext.Strengths)
            {
                if (a.Deleted == 0)
                { strengths.Add(a); }
            }
            return strengths;
        }
    }
}
