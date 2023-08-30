using Project.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public class DispLineAlertRepository : IDispLineAlertRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DispLineAlertRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public DispLineAlert AddAlert(DispLineAlert alert)
        {
            dbContext.DispLineAlerts.Add(alert);
            dbContext.SaveChanges();
            return alert;
        }

        public DispLineAlert DeleteAlert(DispLineAlert alert)
        {
            alert.Deleted = 1;
            dbContext.DispLineAlerts.Update(alert);
            dbContext.SaveChanges();
            return alert;
        }

        public DispLineAlert GetAlert(int id)
        {
            DispLineAlert alert = dbContext.DispLineAlerts.Find(id);
            return alert;
        }

        public List<DispLineAlert> ListAlerts()
        {
            List<DispLineAlert> alerts = new List<DispLineAlert>();
            foreach (DispLineAlert a in dbContext.DispLineAlerts)
            {
                if (a.Deleted == 0)
                { alerts.Add(a); }
            }
            return alerts;
        }

        public DispLineAlert UpdateAlert(DispLineAlert alert)
        {
            dbContext.DispLineAlerts.Update(alert);
            dbContext.SaveChanges();
            return alert;
        }
    }
}
