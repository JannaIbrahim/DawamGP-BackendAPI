using AutoMapper;
using Dawam.API.DTOs;
using Dawam.BLL.Interfaces;
using Dawam.BLL.Specifications;
using Dawam.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        #region Waqf
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
            spec.AddOrderBy(W => W.WaqfName);
            var waqfs = await _waqfRepo.GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Waqf>, IReadOnlyList<WaqfToReturnDTO>>(waqfs);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<WaqfToReturnDTO>> GetWaqfById(int id)
        {
            var spec = new WaqfWithCountryCityTypeActivitySpecification(w=> w.Id == id);
            var waqf = await _waqfRepo.GetByIdWithSpecAsync(spec);
            var data = _mapper.Map<Waqf,WaqfToReturnDTO>(waqf);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> AddWaqf([FromForm] WaqfToAddDTO waqf)
        {
            var newWaqf = _mapper.Map<WaqfToAddDTO, Waqf>(waqf);

            newWaqf.WaqfStatusId = 1;
            newWaqf.InsDate = DateTime.Now;
            if(waqf.WaqfImage != null && waqf.WaqfImage.Length > 0)
            {
                var imageFileName = newWaqf.Id + Path.GetFileName(waqf.WaqfImage.FileName);
                var imageFilePath = Path.Combine("wwwroot/waqfImages", imageFileName);

                using (var stream = new FileStream(imageFilePath, FileMode.Create))
                    await waqf.WaqfImage.CopyToAsync(stream);
                newWaqf.ImageUrl = $"/waqfImages/{imageFileName}";

            }
           
            if(waqf.WaqfDocument != null && waqf.WaqfDocument.Length > 0)
            {
                var documentFileName = newWaqf.Id + Path.GetFileName(waqf.WaqfDocument.FileName);
                var documentFilePath = Path.Combine("wwwroot/waqfDocuments", documentFileName);

                using (var stream = new FileStream(documentFilePath, FileMode.Create))
                    await waqf.WaqfDocument.CopyToAsync(stream);
                newWaqf.DocumentUrl = $"/waqfDocuments/{documentFileName}";
            }

            var changes = await _waqfRepo.Add(newWaqf);

            if (changes! > 0)
                return Ok();

            return BadRequest();



        }

        [HttpPut]
        public async Task<ActionResult> EditWaqf(int waqfId ,[FromForm]WaqfToAddDTO update)
        {
            var spec = new WaqfWithCountryCityTypeActivitySpecification(w => w.Id == waqfId);
            var waqf = await _waqfRepo.GetByIdWithSpecAsync(spec);
            
            var newWaqf = _mapper.Map<WaqfToAddDTO, Waqf>(update);
            newWaqf.WaqfStatus = waqf.WaqfStatus;
            newWaqf.InsUserId = waqf.InsUserId;
            newWaqf.InsDate = waqf.InsDate;
            newWaqf.Id = waqf.Id;

            newWaqf.WaqfStatusId = 1;
            if (update.WaqfImage != null && update.WaqfImage.Length > 0)
            {
                var imageFileName = newWaqf.Id + Path.GetFileName(update.WaqfImage.FileName);
                var imageFilePath = Path.Combine("wwwroot/waqfImages", imageFileName);

                using (var stream = new FileStream(imageFilePath, FileMode.Create))
                    await update.WaqfImage.CopyToAsync(stream);
                newWaqf.ImageUrl = $"/waqfImages/{imageFileName}";

            }

            if (update.WaqfDocument != null && update.WaqfDocument.Length > 0)
            {
                var documentFileName = newWaqf.Id + Path.GetFileName(update.WaqfDocument.FileName);
                var documentFilePath = Path.Combine("wwwroot/waqfDocuments", documentFileName);

                using (var stream = new FileStream(documentFilePath, FileMode.Create))
                    await update.WaqfDocument.CopyToAsync(stream);
                newWaqf.DocumentUrl = $"/waqfDocuments/{documentFileName}";
            }
            waqf = newWaqf;
            
            var changes = await _waqfRepo.Update(waqf);

            if (changes > 0)
                return Ok();

            return BadRequest();


        }

        #region status control
        [HttpPut("Status")]
        public async Task<ActionResult> UpdateWaqfStatus(int waqfId, int statusId)
        {
            var waqf = await _waqfRepo.GetByIdAsync(waqfId);
            waqf.WaqfStatusId = statusId;
            var changes = await _waqfRepo.Update(waqf);

            if (changes > 0)
                return Ok();

            return BadRequest();


        }
        [HttpPut("Confirm")]
        public async Task<ActionResult> ConfirmWaqf(int waqfId, int ConfirmUserId)
        {
            var waqf = await _waqfRepo.GetByIdAsync(waqfId);
            waqf.WaqfStatusId = 2;
            waqf.ConfirmUserId = ConfirmUserId;
            waqf.ConfirmDate = DateTime.Now;
            var changes = await _waqfRepo.Update(waqf);

            if (changes > 0)
                return Ok();

            return BadRequest();


        }
        [HttpPut("Decline")]
        public async Task<ActionResult> DeclineWaqf(int waqfId, int ConfirmUserId)
        {
            var waqf = await _waqfRepo.GetByIdAsync(waqfId);
            waqf.WaqfStatusId = 3;
            waqf.ConfirmUserId = ConfirmUserId;
            waqf.ConfirmDate = DateTime.Now;
            var changes = await _waqfRepo.Update(waqf);

            if (changes > 0)
                return Ok();

            return BadRequest();


        }
        #endregion

        #region Notes control
        [HttpPut("Notes")]
        public async Task<ActionResult> UpdateWaqfAdminNotes(int waqfId, string notes)
        {
            var waqf = await _waqfRepo.GetByIdAsync(waqfId);
            waqf.AdminNotes = notes;
            var changes = await _waqfRepo.Update(waqf);

            if (changes > 0)
                return Ok();

            return BadRequest();


        }

        #endregion

        #endregion
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

        [HttpPost("Activity")]
        public async Task<IActionResult> AddActivity(string activity)
        {
            var newActivity = new WaqfActivity() { Name = activity };
            var changes = await _activityRepo.Add(newActivity);
            if(changes> 0)
                return Ok();
            return BadRequest();

        }

        #endregion

    }
}
