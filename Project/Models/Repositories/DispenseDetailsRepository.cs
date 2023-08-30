using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class DispenseDetailsRepository:IDispenseDetailsRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DispenseDetailsRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public DispenseDetails AddDispenseDetails(DispenseDetails dispenseDetails)
        {
            dbContext.DispenseDetails.Add(dispenseDetails);
            dbContext.SaveChanges();
            return dispenseDetails;
        }

        public List<DispenseDetails> AddDispenseDetailsInBulk(List<DispenseDetails> dispenseDetails)
        {
            foreach (var item in dispenseDetails)
            {
                dbContext.DispenseDetails.Add(item);
            }
            dbContext.SaveChanges();
            return dispenseDetails;
        }

        public DispenseDetails DeleteDispenseDetails(DispenseDetails dispenseDetails)
        {
            dispenseDetails.Deleted = 1;
            dbContext.DispenseDetails.Update(dispenseDetails);
            dbContext.SaveChanges();
            return dispenseDetails;
        }

        public DispenseDetails GetDispenseDetails(int id)
        {
            DispenseDetails dispenseDetails = dbContext.DispenseDetails.Find(id);
            return dispenseDetails;
        }

        public List<DispenseDetails> ListDispenseDetails()
        {
            List<DispenseDetails> dispenseDetails = new List<DispenseDetails>();
            foreach (DispenseDetails a in dbContext.DispenseDetails)
            {
                if (a.Deleted == 0)
                { dispenseDetails.Add(a); }
            }
            return dispenseDetails;
        }

        public DispenseDetails UpdateDispenseDetails(DispenseDetails dispenseDetails)
        {
            dbContext.DispenseDetails.Update(dispenseDetails);
            dbContext.SaveChanges();
            return dispenseDetails;
        }
    }
}
