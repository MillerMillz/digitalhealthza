using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IstrengthRepository
    {
        public Strength GetStrength(int id);
        public List<Strength> ListStrengths();
    }
}
