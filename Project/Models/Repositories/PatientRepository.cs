using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class PatientRepository:IPatientRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PatientRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Patient AddPatient(Patient patient)
        {
            dbContext.Patients.Add(patient);
            dbContext.SaveChanges();
            return patient;
        }

        public Patient DeletePatient(Patient patient)
        {
            patient.Deleted = 1;
            dbContext.Patients.Update(patient);
            dbContext.SaveChanges();
            return patient;
        }

        public Patient GetPatient(int id)
        {
            Patient patient = dbContext.Patients.Find(id);
            return patient;
          
        }

        public Patient GetPatientByUserID(string id)
        {
            List<Patient> patients = dbContext.Patients.Where(z => z.UserId == id).ToList();
            Patient patient = new Patient();
            foreach(Patient a in patients)
            {
                if(a.UserId==id)
                {
                    patient = a;
                    break;
                }
            }
            return patient;
        }

        public List<Patient> ListPatients()
        {
            List<Patient> patients = new List<Patient>();
            foreach (Patient a in dbContext.Patients)
            {
                if (a.Deleted == 0)
                { patients.Add(a); }
            }
            return patients;
        }

        public Patient UpdatePatient(Patient patient)
        {
            dbContext.Patients.Update(patient);
            dbContext.SaveChanges();
            return patient;
        }
    }
}
