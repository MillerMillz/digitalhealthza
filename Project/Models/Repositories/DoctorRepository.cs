using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DoctorRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            dbContext.Doctors.Add(doctor);
            dbContext.SaveChanges();
            return doctor;
        }

        public Doctor DeleteDoctor(Doctor doctor)
        {
            doctor.Deleted = 1;
            dbContext.Doctors.Update(doctor);
            dbContext.SaveChanges();
            return doctor;
        }

        public Doctor GetDoctor(int id)
        {
            Doctor doctor = dbContext.Doctors.Find(id);
            return doctor;
        }

        public Doctor GetDoctorByUserId(string id)
        {
            List<Doctor> doctors = dbContext.Doctors.Where(z => z.UserId == id).ToList();
            Doctor doctor = new Doctor();
            foreach (Doctor a in doctors)
            {
                if (a.UserId == id)
                {
                    doctor = a;
                    break;
                }
            }
            return doctor;
        }

        public List<Doctor> ListDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach (Doctor a in dbContext.Doctors)
            {
                if (a.Deleted == 0)
                { doctors.Add(a); }
            }
            return doctors;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            dbContext.Doctors.Update(doctor);
            dbContext.SaveChanges();
            return doctor;
        }
    }
}
