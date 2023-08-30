using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IDosageFormRepository
    {
        public DosageForm AddDosageForm(DosageForm dosageForm);
        public DosageForm UpdateDosageForm(DosageForm dosageForm);
        public DosageForm DeleteDosageForm(DosageForm dosageForm);
        public DosageForm GetDosageForm(int id);
        public List<DosageForm> ListDosageForms();
    }
}
