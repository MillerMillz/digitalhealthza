using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IPatientRepository
    {
        public Patient AddPatient(Patient patient);
        public Patient UpdatePatient(Patient patient);
        public Patient DeletePatient(Patient patient);
        public Patient GetPatient(int id);
        public Patient GetPatientByUserID(string id);
        public List<Patient> ListPatients();
    }
}
