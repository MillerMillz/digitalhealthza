using Project.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public class LineActiveIngreRepository : ILineActiveIngreRepository
    {
        private readonly ApplicationDbContext dbContext;

        public LineActiveIngreRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<LineActiveIngre> AddMultipleLine(List<LineActiveIngre> lines)
        {
            foreach (LineActiveIngre item in lines)
            {
                dbContext.LineActiveIngres.Add(item);
            }
            dbContext.SaveChanges();
            return lines;
        }

        public LineActiveIngre GetLineActiveIngre(int id)
        {
            LineActiveIngre lineActiveIngre = dbContext.LineActiveIngres.Find(id);
            return lineActiveIngre;
        }

        public List<LineActiveIngre> ListLineActiveIngres()
        {
            List<LineActiveIngre> lineActiveIngres = new List<LineActiveIngre>();
            foreach (LineActiveIngre a in dbContext.LineActiveIngres)
            {
                if (a.Deleted == 0)
                { lineActiveIngres.Add(a); }
            }
            return lineActiveIngres;
        }
    }
}
