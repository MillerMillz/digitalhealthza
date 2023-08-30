using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IDispLineAlertRepository
    {
        public DispLineAlert AddAlert(DispLineAlert alert);
        public DispLineAlert UpdateAlert(DispLineAlert alert);
        public DispLineAlert DeleteAlert(DispLineAlert alert);
        public DispLineAlert GetAlert(int id);
        public List<DispLineAlert> ListAlerts();

        //line
      
    }
}
