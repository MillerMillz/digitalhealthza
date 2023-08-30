using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    interface IMedPracticeRepository
    {
        public MedPractice AddMedPractice(MedPractice medPractice);
        public MedPractice UpdateMedPractice(MedPractice medPractice);
        public MedPractice DeleteMedPractice(MedPractice medPractice);
        public MedPractice GetMedPractice(int id);
        public List<MedPractice> ListMedPractices();
    }
}
