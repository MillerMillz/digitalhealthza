using Project.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public class HighestQualRepository : IHighestQualRepository
    {
        private readonly ApplicationDbContext dbContext;

        public HighestQualRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public HighestQualification AddQualification(HighestQualification qualification)
        {
            dbContext.HighestQualifications.Add(qualification);
            dbContext.SaveChanges();
            return qualification;
        }

        public HighestQualification DeleteQualification(HighestQualification qualification)
        {
            qualification.Deleted = 1;
            dbContext.HighestQualifications.Update(qualification);
            dbContext.SaveChanges();
            return qualification;
        }

        public HighestQualification GetQualification(int id)
        {
            HighestQualification qualification = dbContext.HighestQualifications.Find(id);
            return qualification;
        }

        public List<HighestQualification> ListQualifications()
        {
            List<HighestQualification> qualifications = new List<HighestQualification>();
            foreach (HighestQualification a in dbContext.HighestQualifications)
            {
                if (a.Deleted == 0)
                { qualifications.Add(a); }
            }
            return qualifications;
        }

        public HighestQualification UpdateQualification(HighestQualification qualification)
        {
            dbContext.HighestQualifications.Update(qualification);
            dbContext.SaveChanges();
            return qualification;
        }
    }
}
