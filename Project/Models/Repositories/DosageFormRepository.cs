using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;
namespace Project.Models.Repositories
{
    public class DosageFormRepository:IDosageFormRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DosageFormRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public DosageForm AddDosageForm(DosageForm dosageForm)
        {
            dbContext.DosageForms.Add(dosageForm);
            dbContext.SaveChanges();
            return dosageForm;
        }

        public DosageForm DeleteDosageForm(DosageForm dosageForm)
        {
            dosageForm.Deleted = 1;
            dbContext.DosageForms.Update(dosageForm);
            dbContext.SaveChanges();
            return dosageForm;

        }
        public DosageForm GetDosageForm(int id)
        {
            DosageForm dosageForm = dbContext.DosageForms.Find(id);
            return dosageForm;
        }

        public List<DosageForm> ListDosageForms()
        {
            List<DosageForm> dosageForms = new List<DosageForm>();
            foreach (DosageForm a in dbContext.DosageForms)
            {
                if (a.Deleted == 0)
                { dosageForms.Add(a); }
            }
            return dosageForms;
        }

        public DosageForm UpdateDosageForm(DosageForm dosageForm)
        {
            dbContext.DosageForms.Update(dosageForm);
            dbContext.SaveChanges();
            return dosageForm;
        }
    }
}
