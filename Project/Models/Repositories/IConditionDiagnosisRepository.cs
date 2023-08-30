using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IConditionDiagnosisRepository
    {
        public ConditionDiagnosis AddConditionDiagnosis(ConditionDiagnosis conditionDiagnosis);
        public ConditionDiagnosis EditCondition(ConditionDiagnosis conditionDiagnosis);
        public ConditionDiagnosis GetConditionDiagnosis(int id);
        public List<ConditionDiagnosis> ListConditionDiagnoses();
    }
}
