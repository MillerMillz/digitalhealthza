using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IPharmacistRepository
    {
        public Pharmacist AddPharmacist(Pharmacist pharmacist);
        public Pharmacist UpdatePharmacist(Pharmacist pharmacist);
        public Pharmacist DeletePharmacist(Pharmacist pharmacist);
        public Pharmacist GetPharmacist(int id);
        public Pharmacist GetPharmacistByUserID(string id);
        public List<Pharmacist> ListPharmacists();
    }
}
