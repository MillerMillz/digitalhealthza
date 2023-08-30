using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.DataAccess;

namespace Project.Models.Repositories
{
    public class CityRepository:ICityRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CityRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public City AddCity(City city)
        {
            dbContext.Cities.Add(city);
            dbContext.SaveChanges();
            return city;
        }

        public City DeleteCity(City city)
        {
            city.Deleted = 1;
            dbContext.Cities.Update(city);
            dbContext.SaveChanges();
            return city;
        }

        public City GetCity(int id)
        {
            City city = dbContext.Cities.Find(id);
            return city;
        }

        public List<City> ListCities()
        {
            List<City> cities = new List<City>();
            foreach (City a in dbContext.Cities)
            {
                if (a.Deleted == 0)
                { cities.Add(a); }
            }
            return cities;
        }

        public City UpdateCity(City city)
        {

            dbContext.Cities.Update(city);
            dbContext.SaveChanges();
            return city;
        }
    }
}
