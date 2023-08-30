using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IContraIndicationRepository
    {
        public ContraIndication AddContraIndication(ContraIndication contraIndication);
        public ContraIndication UpdateContraIndication(ContraIndication contraIndication);
        public ContraIndication DeleteContraIndication(ContraIndication contraIndication);
        public ContraIndication GetContraIndication(int id);
        public List<ContraIndication> ListContraIndication();
    }
}
