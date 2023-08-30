using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IActiveIngredientRepository
    {
        public ActiveIngredient AddActiveIngredient(ActiveIngredient activeIngredient);
        public ActiveIngredient EditActiveIngredient(ActiveIngredient activeIngredient);
        public ActiveIngredient DeleteActiveIngredient(ActiveIngredient activeIngredient);
        public ActiveIngredient GetActiveIngredient(int id);
        public List<ActiveIngredient> ListActiveIngredients();

    }
}
