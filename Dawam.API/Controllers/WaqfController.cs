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
    public class WaqfController : BaseApiController
    {
        private readonly IGenericRepository<Waqf> _waqfRepo;
        private readonly IGenericRepository<WaqfType> _typeRepo;
        private readonly IGenericRepository<WaqfActivity> _activityRepo;
        private readonly IMapper _mapper;

        public WaqfController(IGenericRepository<Waqf> waqfRepo, IGenericRepository<WaqfType> typeRepo, IGenericRepository<WaqfActivity> activityRepo, IMapper mapper)
        {
            _waqfRepo = waqfRepo;
            _typeRepo = typeRepo;
            _activityRepo = activityRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<WaqfToReturnDTO>>> GetWaqfs()
        {
            var spec = new WaqfWithCountryCityTypeActivitySpecification();
            var waqfs = await _waqfRepo.GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Waqf>, IReadOnlyList<WaqfToReturnDTO>>(waqfs);
            return Ok(data);
        }


        #region Types
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<WaqfType>>> GetTypes()
        {
            var types = await _typeRepo.GetAllAsync();
            return Ok(types);
        }

        #endregion

        #region Activities

        [HttpGet("Activities")]
        public async Task<ActionResult<IReadOnlyList<WaqfType>>> GetActivities()
        {
            var activities = await _activityRepo.GetAllAsync();
            return Ok(activities);
        }

        #endregion

    }
}
