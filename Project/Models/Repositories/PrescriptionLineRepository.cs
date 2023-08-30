using Project.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public class PrescriptionLineRepository:IPrescriptionLineRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PrescriptionLineRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public PrescriptionLine AddPrescriptionLine(PrescriptionLine prescriptionLine)
        {
            dbContext.PrescriptionLines.Add(prescriptionLine);
            dbContext.SaveChanges();
            return prescriptionLine;
        }

        public PrescriptionLine DeletePrescriptionLine(PrescriptionLine prescriptionLine)
        {
            prescriptionLine.Deleted = 1;
            dbContext.PrescriptionLines.Update(prescriptionLine);
            dbContext.SaveChanges();
            return prescriptionLine;
        }

        public List<PrescriptionLine> DeletePrescriptionLineInBulk(List<PrescriptionLine> prescriptionLines)
        {
            foreach(PrescriptionLine item in prescriptionLines)
            {
                item.Deleted = 1;
                dbContext.PrescriptionLines.Update(item);
            }
            dbContext.SaveChanges();
            return prescriptionLines;
        }

        public PrescriptionLine GetPrescriptionLine(int id)
        {
            PrescriptionLine prescriptionLine = dbContext.PrescriptionLines.Find(id);
            return prescriptionLine;
        }

        public List<PrescriptionLine> ListPrescriptionLines()
        {
            List<PrescriptionLine> prescriptionLines = new List<PrescriptionLine>();
            foreach (PrescriptionLine a in dbContext.PrescriptionLines)
            {
                if (a.Deleted == 0)
                { prescriptionLines.Add(a); }
            }
            return prescriptionLines;
        }

        public PrescriptionLine UpdatePrescriptioLinen(PrescriptionLine prescriptionLine)
        {
            dbContext.PrescriptionLines.Update(prescriptionLine);
            dbContext.SaveChanges();
            return prescriptionLine;
        }

        public List<PrescriptionLine> UpdatePrescriptionLineInBulk(List<PrescriptionLine> prescriptionLines)
        {
            foreach (PrescriptionLine item in prescriptionLines)
            {
            
                dbContext.PrescriptionLines.Update(item);
            }
            dbContext.SaveChanges();
            return prescriptionLines;
        }
    }
}
