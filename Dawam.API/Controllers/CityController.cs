using Dawam.BLL.Interfaces;
using Dawam.BLL.Specifications;
using Dawam.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dawam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseApiController
    {
        private readonly IGenericRepository<City> _cityRepo;

        public CityController(IGenericRepository<City> cityRepo)
        {
            _cityRepo = cityRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<City>>> GetCitiesByCountryId(int id)
        {
            var spec = new BaseSpecification<City>(c => c.CountryId == id);
            spec.AddOrderBy(c => c.Name);
            var cities = await _cityRepo.GetAllWithSpecAsync(spec);

            return Ok(cities);
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity(string name, int countryId)
        {
            var newCity = new City() { Name = name, CountryId = countryId };
            var changes = await _cityRepo.Add(newCity);
            if (changes > 0)
                return Ok();
            return BadRequest();

        }
    }
}
