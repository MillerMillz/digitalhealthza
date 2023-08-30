using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IActiveIngrStrengthRepository
    {
        public ActiveIngrStrength GetAIStrength(int id);
        public ActiveIngrStrength GetAIStrengthByParams(int activeIngrID,int strengthID);
        public List<ActiveIngrStrength> ListAIStrengths();
    }
}
