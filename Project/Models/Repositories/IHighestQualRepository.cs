using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    interface IHighestQualRepository
    {
        public HighestQualification AddQualification(HighestQualification qualification);
        public HighestQualification UpdateQualification(HighestQualification qualification);
        public HighestQualification DeleteQualification(HighestQualification qualification);
        public HighestQualification GetQualification(int id);
        public List<HighestQualification> ListQualifications();
    }
}
