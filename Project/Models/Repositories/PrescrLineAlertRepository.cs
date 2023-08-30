using Project.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public class PrescrLineAlertRepository : IPrescrLineAlertRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PrescrLineAlertRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public PrescrLineAlert AddAlert(PrescrLineAlert alert)
        {
            dbContext.PrescrLineAlerts.Add(alert);
            dbContext.SaveChanges();
            return alert;
        }

        public PrescrLineAlert DeleteAlert(PrescrLineAlert alert)
        {
            alert.Deleted = 1;
            dbContext.PrescrLineAlerts.Update(alert);
            dbContext.SaveChanges();
            return alert;
        }

        public PrescrLineAlert GetAlert(int id)
        {
            PrescrLineAlert alert = dbContext.PrescrLineAlerts.Find(id);
            return alert;
        }

        public List<PrescrLineAlert> ListAlerts()
        {
            List<PrescrLineAlert> alerts = new List<PrescrLineAlert>();
            foreach (PrescrLineAlert a in dbContext.PrescrLineAlerts)
            {
                if (a.Deleted == 0)
                { alerts.Add(a); }
            }
            return alerts;
        }

        public PrescrLineAlert UpdateAlert(PrescrLineAlert alert)
        {
            dbContext.PrescrLineAlerts.Update(alert);
            dbContext.SaveChanges();
            return alert;
        }
    }
}
