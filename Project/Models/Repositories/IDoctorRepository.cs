using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IDoctorRepository
    {
        public Doctor AddDoctor(Doctor doctor);
        public Doctor UpdateDoctor(Doctor doctor);
        public Doctor DeleteDoctor(Doctor doctor);
        public Doctor GetDoctorByUserId(string id);
        public Doctor GetDoctor(int id);
        public List<Doctor> ListDoctors();
    }
}
