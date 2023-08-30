using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IPrescriptionLineRepository
    {
        public PrescriptionLine AddPrescriptionLine(PrescriptionLine prescriptionLine);
        public PrescriptionLine UpdatePrescriptioLinen(PrescriptionLine prescriptionLine);
        public PrescriptionLine DeletePrescriptionLine(PrescriptionLine prescriptionLine);
        public List<PrescriptionLine> DeletePrescriptionLineInBulk(List<PrescriptionLine> prescriptionLines);
        public List<PrescriptionLine> UpdatePrescriptionLineInBulk(List<PrescriptionLine> prescriptionLines);
        public PrescriptionLine GetPrescriptionLine(int id);
        public List<PrescriptionLine> ListPrescriptionLines();
    }
}
