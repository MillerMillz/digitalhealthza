using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IPrescriptionRepository
    {
        public Prescription AddPrescription(Prescription prescription);
        public Prescription UpdatePrescription(Prescription prescription);
        public Prescription DeletePrescription(Prescription prescription);
        public Prescription GetPrescription(int id);
        public List<Prescription> ListPrescriptions();
    }
}
