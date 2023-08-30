using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IMedActiveIngredientRepository
    {
        public MedActiveIngredient AddMedActiveIngredient(MedActiveIngredient medActiveIngredient);
        public List<MedActiveIngredient> AddMedActiveIngredientInBulk (List<MedActiveIngredient> medActiveIngredients);
        public MedActiveIngredient UpdateMedActiveIngredient(MedActiveIngredient medActiveIngredient);
        public MedActiveIngredient DeleteMedActiveIngredient(MedActiveIngredient medActiveIngredient);
        public MedActiveIngredient GetMedActiveIngredient(int id);
        public List<MedActiveIngredient> ListMedActiveIngredients();
    }
}
