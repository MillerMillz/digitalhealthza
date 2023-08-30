using Project.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public class PatientConditionRepository:IPatientConditionRepository
    {

        private readonly ApplicationDbContext dbContext;

        public PatientConditionRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public PatientCondition AddPatientCondition(PatientCondition patientCondition)
        {
            dbContext.PatientConditions.Add(patientCondition);
            dbContext.SaveChanges();
            return patientCondition;
        }

        public List<PatientCondition> AddPatientConditionInBulk(List<PatientCondition> patientConditions)
        {
            foreach(PatientCondition item in patientConditions)
            {
                dbContext.PatientConditions.Add(item);
            }
            dbContext.SaveChanges();
            return patientConditions;
        }

        public PatientCondition DeletePatientCondition(PatientCondition patientCondition)
        {
            patientCondition.Deleted = 1;
            dbContext.PatientConditions.Update(patientCondition);
            dbContext.SaveChanges();
            return patientCondition;
        }

        public PatientCondition GetPatientCondition(int id)
        {
            PatientCondition patientCondition = dbContext.PatientConditions.Find(id);
            return patientCondition;

        }

        public List<PatientCondition> ListPatientConditions()
        {
            List<PatientCondition> patientConditions = new List<PatientCondition>();
            foreach (PatientCondition a in dbContext.PatientConditions)
            {
                if (a.Deleted == 0)
                { patientConditions.Add(a); }
            }
            return patientConditions;
        }

        public PatientCondition UpdatePatientCondition(PatientCondition patientCondition)
        {
            dbContext.PatientConditions.Update(patientCondition);
            dbContext.SaveChanges();
            return patientCondition;
        }
    }
}
