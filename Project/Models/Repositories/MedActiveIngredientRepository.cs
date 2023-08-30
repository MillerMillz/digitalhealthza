using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class MedActiveIngredientRepository:IMedActiveIngredientRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MedActiveIngredientRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public MedActiveIngredient AddMedActiveIngredient(MedActiveIngredient medActiveIngredient)
        {
            dbContext.MedActiveIngredients.Add(medActiveIngredient);
            dbContext.SaveChanges();
            return medActiveIngredient;
        }

        public List<MedActiveIngredient> AddMedActiveIngredientInBulk(List<MedActiveIngredient> medActiveIngredients)
        {
            foreach (MedActiveIngredient item in medActiveIngredients)
            {
                dbContext.MedActiveIngredients.Add(item);
            }
            dbContext.SaveChanges();
            return medActiveIngredients;
        }

        public MedActiveIngredient DeleteMedActiveIngredient(MedActiveIngredient medActiveIngredient)
        {
            medActiveIngredient.Deleted = 1;
            dbContext.MedActiveIngredients.Update(medActiveIngredient);
            dbContext.SaveChanges();
            return medActiveIngredient;
        }

        public MedActiveIngredient GetMedActiveIngredient(int id)
        {
            MedActiveIngredient medActiveIngredient = dbContext.MedActiveIngredients.Find(id);
            return medActiveIngredient;
        }

        public List<MedActiveIngredient> ListMedActiveIngredients()
        {
            List<MedActiveIngredient> medActiveIngredients = new List<MedActiveIngredient>();
            foreach (MedActiveIngredient a in dbContext.MedActiveIngredients)
            {
                if (a.Deleted == 0)
                { medActiveIngredients.Add(a); }
            }
            return medActiveIngredients;
        }

        public MedActiveIngredient UpdateMedActiveIngredient(MedActiveIngredient medActiveIngredient)
        {
            dbContext.MedActiveIngredients.Update(medActiveIngredient);
            dbContext.SaveChanges();
            return medActiveIngredient;
        }
    }
}
