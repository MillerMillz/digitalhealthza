using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class ContraIndicationRepository:IContraIndicationRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ContraIndicationRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public ContraIndication AddContraIndication(ContraIndication contraIndication)
        {
            dbContext.ContraIndications.Add(contraIndication);
            dbContext.SaveChanges();
            return contraIndication;
        }

        public ContraIndication DeleteContraIndication(ContraIndication contraIndication)
        {
            contraIndication.Deleted = 1;
            dbContext.ContraIndications.Update(contraIndication);
            dbContext.SaveChanges();
            return contraIndication;
        }

        public ContraIndication GetContraIndication(int id)
        {
            ContraIndication contraIndication = dbContext.ContraIndications.Find(id);
            return contraIndication;

        }

        public List<ContraIndication> ListContraIndication()
        {
            List<ContraIndication> contraIndications = new List<ContraIndication>();
            foreach(ContraIndication a in dbContext.ContraIndications)
            {
                if(a.Deleted==0)
                { contraIndications.Add(a); }
            }
            return contraIndications;
        }

        public ContraIndication UpdateContraIndication(ContraIndication contraIndication)
        {
            dbContext.ContraIndications.Update(contraIndication);
            dbContext.SaveChanges();
            return contraIndication;
        }
    }
}
