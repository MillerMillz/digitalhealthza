using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IPharmacyRepository
    {
        public Pharmacy AddPharmacy(Pharmacy pharmacy);
        public Pharmacy UpdatePharmacy(Pharmacy pharmacy);
        public Pharmacy DeletePharmacy(Pharmacy pharmacy);
        public Pharmacy GetPharmacy(int id);
        public List<Pharmacy> ListPharmacies();
    }
}
