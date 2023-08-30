using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IPatientConditionRepository
    {
        public PatientCondition AddPatientCondition(PatientCondition patientCondition);
        public List<PatientCondition> AddPatientConditionInBulk(List<PatientCondition> patientConditions);
        public PatientCondition UpdatePatientCondition(PatientCondition patientCondition);
        public PatientCondition DeletePatientCondition(PatientCondition patientCondition);
        public PatientCondition GetPatientCondition(int id);
        public List<PatientCondition> ListPatientConditions();
    }
}
