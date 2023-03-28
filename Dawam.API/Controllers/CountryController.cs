using Dawam.BLL.Interfaces;
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
            var countries = await _countryRepo.GetAllAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryById(int id)
        {
            var country = await _countryRepo.GetByIdAsync(id);
            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity(string country)
        {
            var newCountry = new Country() { Name = country};
            
            var changes = await _countryRepo.Add(newCountry);
            if (changes > 0)
                return Ok();
            return BadRequest();

        }
    }
}
