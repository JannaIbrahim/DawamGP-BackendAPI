using Microsoft.AspNetCore.Http;
using System;

namespace Dawam.API.DTOs
{
    public class WaqfToAddDTO
    {
        public string WaqfName { get; set; }
        public string FounderName { get; set; }
        public int? DocumentNumber { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public DateTime? EstablishmentDateH { get; set; }
        public string WaqfDescription { get; set; }
        public int? WaqfCountryId { get; set; }
        public int? WaqfCityId { get; set; }
        public int? WaqfTypeId { get; set; }
        public int? WaqfActivityId { get; set; }
        public IFormFile WaqfImage { get; set; }
        public IFormFile WaqfDocument { get; set; }
        public string AdminNotes { get; set; }
        public int InsUserId { get; set; }
    }
}
