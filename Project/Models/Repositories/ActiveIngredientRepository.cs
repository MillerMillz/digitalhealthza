using Project.Models.DataAccess;
using System;
using System.Collections.Generic;

namespace Project.Models.Repositories
{
    public class ActiveIngredientRepository : IActiveIngredientRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ActiveIngredientRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public ActiveIngredient AddActiveIngredient(ActiveIngredient activeIngredient)
        {
            dbContext.ActiveIngredients.Add(activeIngredient);
            dbContext.SaveChanges();
            return activeIngredient;
        }

        public ActiveIngredient DeleteActiveIngredient(ActiveIngredient activeIngredient)
        {
            activeIngredient.Deleted = 1;
            dbContext.ActiveIngredients.Update(activeIngredient);
            dbContext.SaveChanges();
            return activeIngredient;
        }

        public ActiveIngredient GetActiveIngredient(int id)
        {
            ActiveIngredient ingredient = dbContext.ActiveIngredients.Find(id);
            return ingredient;
        }

        public List<ActiveIngredient> ListActiveIngredients()
        {
            List<ActiveIngredient> ingredients = new List<ActiveIngredient>();
            foreach (ActiveIngredient a in dbContext.ActiveIngredients)
            {
                if (a.Deleted == 0)
                { ingredients.Add(a); }
            }
            return ingredients;
        }

        public ActiveIngredient EditActiveIngredient(ActiveIngredient activeIngredient)
        {
            dbContext.ActiveIngredients.Update(activeIngredient);
            dbContext.SaveChanges();
            return activeIngredient;
        }
    }
}
