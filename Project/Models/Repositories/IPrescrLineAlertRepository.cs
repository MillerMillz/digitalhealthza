using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IPrescrLineAlertRepository
    {
        public PrescrLineAlert AddAlert(PrescrLineAlert alert);
        public PrescrLineAlert UpdateAlert(PrescrLineAlert alert);
        public PrescrLineAlert DeleteAlert(PrescrLineAlert alert);
        public PrescrLineAlert GetAlert(int id);
        public List<PrescrLineAlert> ListAlerts();
    }
}
