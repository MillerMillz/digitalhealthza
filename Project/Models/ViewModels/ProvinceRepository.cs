using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class ProvinceRepository:IProvinceRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProvinceRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Province AddProvince(Province province)
        {
            dbContext.Provinces.Add(province);
            dbContext.SaveChanges();
            return province;
        }

        public Province DeleteProvince(Province province)
        {
            province.Deleted = 1;
            dbContext.Provinces.Update(province);
            dbContext.SaveChanges();
            return province;
        }

        public Province GetProvince(int id)
        {
            Province province = dbContext.Provinces.Find(id);
            return province;
        }

        public List<Province> ListProvinces()
        {
            List<Province> provinces = new List<Province>();
            foreach (Province a in dbContext.Provinces)
            {
                if (a.Deleted == 0)
                { provinces.Add(a); }
            }
            return provinces;
        }

        public Province UpdateProvince(Province province)
        {
            dbContext.Provinces.Update(province);
            dbContext.SaveChanges();
            return province;
        }
    }
}
