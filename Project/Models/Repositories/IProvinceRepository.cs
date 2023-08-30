using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IProvinceRepository
    {
        public Province AddProvince(Province province);
        public Province UpdateProvince(Province province);
        public Province DeleteProvince(Province province);
        public Province GetProvince(int id);
        public List<Province> ListProvinces();
    }
}
