using System;
using System.Collections.Generic;
using System.Linq;
using Project.Models.DataAccess;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public class MedInteractionRepository:IMedInteractionRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MedInteractionRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public MedInteraction AddMedInteraction(MedInteraction medInteraction)
        {
            dbContext.MedInteractions.Add(medInteraction);
            dbContext.SaveChanges();
            return medInteraction;
        }

        public MedInteraction DeleteMedInteraction(MedInteraction medInteraction)
        {
            medInteraction.Deleted = 1;
            dbContext.MedInteractions.Update(medInteraction);
            dbContext.SaveChanges();
            return medInteraction;
        }

        public MedInteraction GetMedInteraction(int id)
        {
            MedInteraction medInteraction = dbContext.MedInteractions.Find(id);
            return medInteraction;
        }

        public List<MedInteraction> ListMedInteractions()
        {
            List<MedInteraction> medInteractions = new List<MedInteraction>();
            foreach (MedInteraction a in dbContext.MedInteractions)
            {
                if (a.Deleted == 0)
                { medInteractions.Add(a); }
            }
            return medInteractions;
        }

        public MedInteraction UpdateMedInteraction(MedInteraction medInteraction)
        {
            dbContext.MedInteractions.Update(medInteraction);
            dbContext.SaveChanges();
            return medInteraction;
        }
    }
}
