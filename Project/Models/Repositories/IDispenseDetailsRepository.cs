using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IDispenseDetailsRepository
    {
        public DispenseDetails AddDispenseDetails(DispenseDetails dispenseDetails);
        public List<DispenseDetails> AddDispenseDetailsInBulk(List<DispenseDetails> dispenseDetails);
        public DispenseDetails UpdateDispenseDetails(DispenseDetails dispenseDetails);
        public DispenseDetails DeleteDispenseDetails(DispenseDetails dispenseDetails);
        public DispenseDetails GetDispenseDetails(int id);
        public List<DispenseDetails> ListDispenseDetails();
    }
}
