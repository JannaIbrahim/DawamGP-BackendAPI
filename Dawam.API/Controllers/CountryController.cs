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
    public class CountryController : BaseApiController
    {
        private readonly IGenericRepository<Country> _countryRepo;

        public CountryController(IGenericRepository<Country> countryRepo)
        {
            _countryRepo = countryRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Country>>> GetCountries()
        {
            var spec = new BaseSpecification<Country>();
            spec.AddOrderBy(c => c.Name);
            var countries = await _countryRepo.GetAllWithSpecAsync(spec);
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryById(int id)
        {
            var country = await _countryRepo.GetByIdAsync(id);
            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(string country)
        {
            var newCountry = new Country() { Name = country};
            
            var changes = await _countryRepo.Add(newCountry);
            if (changes > 0)
                return Ok();
            return BadRequest();

        }

        [HttpDelete]
        public async Task<IActionResult>DeleteCountry(int countryId)
        {
            var country = await _countryRepo.GetByIdAsync(countryId);

            var changes = await _countryRepo.Delete(country);

            if (changes > 0)
                return Ok();

            return BadRequest();

        }
    }
}
