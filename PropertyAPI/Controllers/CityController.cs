using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PropertyAPI.Dtos;
using PropertyAPI.Interfaces;
using PropertyAPI.Models;

namespace PropertyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        //GET api/city
        [HttpGet]
        public async Task<IActionResult> GetCities() 
        {
            var cities = await unitOfWork.CityRepository.GetCitiesAsync();
            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);
            /*var citiesDto = from c in cities
                            select new CityDto()
                            {
                                Id = c.Id,
                                Name = c.Name,
                            };*/
            return Ok(citiesDto);
        }
        //POST api/city/add?cityname=Pune
        //POST api/city/add/Pune
        //[HttpPost("add")]
        /*[HttpPost("add/{cityName}")]
        public async Task<IActionResult> AddCity(string cityName)
        {
            City city = new City();
            city.Name = cityName;
            await dataContext.AddAsync(city);
            await dataContext.SaveChangesAsync();
            return Ok(city);
        }*/

        //POST api/city/add
        //body {"name" : "Chennai"}
        [HttpPost("add")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            /*var city = new City
            {
                Name = cityDto.Name,
                LastUpdatedBy = 1,
                LastUpdatedOn = DateTime.Now
            };*/
            var city = mapper.Map<City>(cityDto);
            city.LastUpdatedBy = 1;
            city.LastUpdatedOn = DateTime.Now;
            unitOfWork.CityRepository.AddCity(city);
            await unitOfWork.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        {
            var cityFromDb = await unitOfWork.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDto, cityFromDb);
            await unitOfWork.SaveAsync();
            return StatusCode(200);
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        {
            var cityFromDb = await unitOfWork.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            cityToPatch.ApplyTo(cityFromDb, ModelState);
            await unitOfWork.SaveAsync();
            return StatusCode(200);
        }

        //DELETE api/city/delete/1        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            unitOfWork.CityRepository.DeleteCity(id);
            await unitOfWork.SaveAsync();
            return Ok(id);
        }
    }
}
