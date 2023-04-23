using AutoMapper;
using Dawam.API.DTOs;
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
        private readonly IMapper _mapper;

        public CityController(IGenericRepository<City> cityRepo, IMapper mapper)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<CityDTO>>> GetCitiesByCountryId(int id)
        {
            var spec = new BaseSpecification<City>(c => c.CountryId == id);
            spec.AddOrderBy(c => c.Name);
            var cities = await _cityRepo.GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList<City>, IReadOnlyList<CityDTO>>(cities);

            return Ok(data);
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
