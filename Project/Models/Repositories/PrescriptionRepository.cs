using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class PrescriptionRepository:IPrescriptionRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PrescriptionRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Prescription AddPrescription(Prescription prescription)
        {
            dbContext.Prescriptions.Add(prescription);
            dbContext.SaveChanges();
            return prescription;
        }

        public Prescription DeletePrescription(Prescription prescription)
        {
            prescription.Deleted = 1;
            dbContext.Prescriptions.Update(prescription);
            dbContext.SaveChanges();
            return prescription;
        }

        public Prescription GetPrescription(int id)
        {
            Prescription prescription = dbContext.Prescriptions.Find(id);
            return prescription;
        }

        public List<Prescription> ListPrescriptions()
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach (Prescription a in dbContext.Prescriptions)
            {
                if (a.Deleted == 0)
                { prescriptions.Add(a); }
            }
            return prescriptions;
        }

        public Prescription UpdatePrescription(Prescription prescription)
        {
            dbContext.Prescriptions.Update(prescription);
            dbContext.SaveChanges();
            return prescription;
        }
    }
}
