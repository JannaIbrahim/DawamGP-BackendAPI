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
using System.Net;
using System.Net.Http;
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
        private readonly IWaqfReopsitory _waqfReopsitory;
        private readonly IMapper _mapper;
        private readonly IIpfsService _ipfsService;
        private readonly string Baseurl = "http://afdinc-001-site5.itempurl.com";

        #region Waqf
        public WaqfController(IGenericRepository<Waqf> waqfRepo, IGenericRepository<WaqfType> typeRepo, IGenericRepository<WaqfActivity> activityRepo,IWaqfReopsitory waqfReopsitory, IMapper mapper, IIpfsService ipfsService)
        {
            _waqfRepo = waqfRepo;
            _typeRepo = typeRepo;
            _activityRepo = activityRepo;
            _waqfReopsitory = waqfReopsitory;
            _mapper = mapper;
            _ipfsService = ipfsService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<WaqfToReturnDTO>>> GetWaqfs()
        {
            var spec = new WaqfWithCountryCityTypeActivitySpecification();
            spec.AddOrderBy(W => W.InsDate);
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


        //Advanced searsh for waqf by string (name,founder,date,country,city,discription,...)

        [HttpGet("Search")]
        public async Task<ActionResult<WaqfToReturnDTO>> WaqfSearch(string searchText) {
            //var search = WebUtility.UrlDecode(searchEn);


            //var spec = new WaqfWithCountryCityTypeActivitySpecification();
            var waqf = await _waqfReopsitory.SearshWaqfs(searchText);
            var data = _mapper.Map<IReadOnlyList<vw_waqfSearch>,IReadOnlyList<WaqfToReturnDTO>>(waqf);
            if (data == null)
                return NotFound();
             
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
                var imageFileName = Path.GetFileName(waqf.WaqfImage.FileName);
                imageFileName = imageFileName.Replace(" ", string.Empty);
                var imageFilePath = Path.Combine("wwwroot/waqfImages", imageFileName);

                using (var stream = new FileStream(imageFilePath, FileMode.Create))
                    await waqf.WaqfImage.CopyToAsync(stream);
                newWaqf.ImageUrl = $"/waqfImages/{imageFileName}";

            }else if(waqf.WaqfImage == null)
            {
                newWaqf.ImageUrl = "/waqfImages/none.png";
            }
           
            if(waqf.WaqfDocument != null && waqf.WaqfDocument.Length > 0)
            {
                var documentFileName = newWaqf.Id + Path.GetFileName(waqf.WaqfDocument.FileName);
                documentFileName = documentFileName.Replace(" ", string.Empty);
                var documentFilePath = Path.Combine("wwwroot/waqfDocuments", documentFileName);

                using (var stream = new FileStream(documentFilePath, FileMode.Create))
                    await waqf.WaqfDocument.CopyToAsync(stream);
                newWaqf.DocumentUrl = $"/waqfDocuments/{documentFileName}";
            }else if(waqf.WaqfDocument == null)
            {
                newWaqf.DocumentUrl = "";
            }

            var changes = await _waqfRepo.Add(newWaqf);

            if (changes! > 0)
                return Ok();

            return BadRequest("couldn't add waqf");



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
            else
            {
                newWaqf.ImageUrl = "/waqfImages/none.png";
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


        #region Delete Waqf
        [HttpDelete]
        public async Task<ActionResult> DeleteWaqf(int waqfId)
        {
            var waqf = await _waqfRepo.GetByIdAsync(waqfId);
            //if(waqf.WaqfStatus == )
            var changes = await _waqfRepo.Delete(waqf);

            if (changes > 0)
                return Ok();

            return BadRequest();
        }


        #endregion



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
            waqf.AdminNotes += "\n -- ملاحظات المشرف -- \n"+notes;
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

        #region IPFS management
        [HttpPost("upload-pdf")]
        public async Task<ActionResult<string>> UploadPdf(int waqfId)
        {
            var spec = new WaqfWithCountryCityTypeActivitySpecification(w => w.Id == waqfId);
            var waqf = await _waqfRepo.GetByIdWithSpecAsync(spec);

            if (string.IsNullOrEmpty(waqf.DocumentUrl))
                return BadRequest("Their is no waqf document!");

            var fileUrl = Baseurl + waqf.DocumentUrl;
            using var client = new HttpClient();
            var documentFile = await _ipfsService.ReadPdfFileAsync(client, fileUrl);

            using (var pdfStream = new MemoryStream(documentFile) )
            {
                var ipfsHash = await _ipfsService.UploadToIpfs(pdfStream);
                return Ok(ipfsHash);
            }


        }

        #endregion

    }
}
