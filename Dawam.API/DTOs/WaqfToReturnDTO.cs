using System;

namespace Dawam.API.DTOs
{
    public class WaqfToReturnDTO
    {
        public int Id { get; set; }
        public string WaqfName { get; set; }
        public string FounderName { get; set; }
        public int? DocumentNumber { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public DateTime? EstablishmentDateH { get; set; }
        public string WaqfDescription { get; set; }
        public string WaqfCountry { get; set; }
        public string WaqfCity { get; set; }
        public string WaqfType { get; set; }
        public string WaqfActivity { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentUrl { get; set; }
        public string WaqfStatus { get; set; }
        public string AdminNotes { get; set; }
        public string InsUser { get; set; }
        public int InsUserId { get; set; }
        public DateTime InsDate { get; set; }
        public string ConfirmUser { get; set; }
        public int? ConfirmUserId { get; set; }
        public DateTime? ConfirmDate { get; set; }
    }
}
