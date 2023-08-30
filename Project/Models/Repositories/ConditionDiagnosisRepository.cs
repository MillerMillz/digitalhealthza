using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class ConditionDiagnosisRepository:IConditionDiagnosisRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ConditionDiagnosisRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public ConditionDiagnosis AddConditionDiagnosis(ConditionDiagnosis conditionDiagnosis)
        {
            dbContext.ConditionDiagnoses.Add(conditionDiagnosis);
            dbContext.SaveChanges();
            return conditionDiagnosis;
        }

        public ConditionDiagnosis DeleteConditionDiagnosis(ConditionDiagnosis conditionDiagnosis)
        {
            conditionDiagnosis.Deleted = 1;
            dbContext.ConditionDiagnoses.Update(conditionDiagnosis);
            dbContext.SaveChanges();
            return conditionDiagnosis;
        }

        public ConditionDiagnosis GetConditionDiagnosis(int id)
        {

            ConditionDiagnosis cd = dbContext.ConditionDiagnoses.Find(id);
            
            return cd;
        }

            public List<ConditionDiagnosis> ListConditionDiagnoses()
        {
            List<ConditionDiagnosis> conditionDiagnoses = new List<ConditionDiagnosis>();
            foreach (ConditionDiagnosis a in dbContext.ConditionDiagnoses)
            {
                if (a.Deleted == 0)
                { conditionDiagnoses.Add(a); }
            }
            return conditionDiagnoses;
        }

        public ConditionDiagnosis EditCondition(ConditionDiagnosis conditionDiagnosis)
        {
            dbContext.ConditionDiagnoses.Update(conditionDiagnosis);
            dbContext.SaveChanges();
            return conditionDiagnosis;
        }
    }
}
