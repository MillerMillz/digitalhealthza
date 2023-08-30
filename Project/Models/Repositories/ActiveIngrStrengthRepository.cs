using Project.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public class ActiveIngrStrengthRepository : IActiveIngrStrengthRepository
    {

        private readonly ApplicationDbContext dbContext;

        public ActiveIngrStrengthRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public ActiveIngrStrength GetAIStrength(int id)
        {
            ActiveIngrStrength activeIngrStrength = dbContext.ActiveIngrStrengths.Find(id);
            return activeIngrStrength;
        }

        public ActiveIngrStrength GetAIStrengthByParams(int activeIngrID, int strengthID)
        {
            ActiveIngrStrength ret = new ActiveIngrStrength();
            List<ActiveIngrStrength> activeIngrStrengths = dbContext.ActiveIngrStrengths.Where(z=> z.ActiveIngrID==activeIngrID && z.StrengthID==strengthID).ToList();
            foreach (ActiveIngrStrength a in activeIngrStrengths)
            {
                if (a.ActiveIngrID == activeIngrID && a.StrengthID==strengthID)
                { 
                    ret=a;
                    break;
                }
            }
            return ret;
        }

        public List<ActiveIngrStrength> ListAIStrengths()
        {
            List<ActiveIngrStrength> activeIngrStrengths = new List<ActiveIngrStrength>();
            foreach (ActiveIngrStrength a in dbContext.ActiveIngrStrengths)
            {
                if (a.Deleted == 0)
                { activeIngrStrengths.Add(a); }
            }
            return activeIngrStrengths;
        }
    }
}
