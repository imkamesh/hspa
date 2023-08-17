using Microsoft.EntityFrameworkCore;
using PropertyAPI.Interfaces;
using PropertyAPI.Models;

namespace PropertyAPI.Data.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dataContext;

        public CityRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddCity(City city)
        {
            dataContext.Cities.AddAsync(city);
        }

        public void DeleteCity(int cityId)
        {
            var city = dataContext.Cities.Find(cityId);
            dataContext.Cities.Remove(city);
        }

        public async Task<City> FindCity(int cityId)
        {
            return await dataContext.Cities.FindAsync(cityId);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await dataContext.Cities.ToListAsync();
        }
    }
}
