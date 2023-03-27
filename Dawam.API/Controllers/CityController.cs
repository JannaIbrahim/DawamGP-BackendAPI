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
            var cities = await _cityRepo.GetAllWithSpecAsync(spec);

            return Ok(cities);
        }
    }
}
