using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface ICityRepository
    {
        public City AddCity(City city);
        public City UpdateCity(City city);
        public City DeleteCity(City city);
        public City GetCity(int id);
        public List<City> ListCities();
    }
}
