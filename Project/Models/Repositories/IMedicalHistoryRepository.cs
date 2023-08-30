using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IMedicalHistoryRepository
    {
        public MedicalHistory AddMedicalHistory(MedicalHistory medicalHistory);
        public List<MedicalHistory> AddMedicalHistoryInBulk(List<MedicalHistory> medicalHistories);
        public MedicalHistory UpdateMedicalHistory(MedicalHistory medicalHistory);
        public MedicalHistory DeleteMedicalHistory(MedicalHistory medicalHistory);
        public MedicalHistory GetMedicalHistory(int id);
        public List<MedicalHistory> ListMedicalHistories();
    }
}
