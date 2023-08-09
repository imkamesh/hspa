using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyAPI.Data;
using PropertyAPI.Models;

namespace PropertyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext dataContext;

        public CityController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        //GET api/city
        [HttpGet]
        public async Task<IActionResult> GetCities() 
        {
            var cities = await dataContext.Cities.ToListAsync();
            return Ok(cities);
        }
        //POST api/city/add?cityname=Pune
        [HttpPost("add")]
        public async Task<IActionResult> AddCity(string cityName)
        {
            City city = new City();
            city.Name = cityName;
            await dataContext.AddAsync(city);
            await dataContext.SaveChangesAsync();
            return Ok(city);
        }
    }
}
