using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dawam.DAL.Entities
{
    public class Waqf : BaseEntity
    {
        public string WaqfName { get; set; }
        public string FounderName { get; set; }
        public int DocumentNumber { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public DateTime? EstablishmentDateH { get; set; }
        public string WaqfDescription { get; set; }
        public Country WaqfCountry { get; set; }
        public int? CountryId { get; set; }
        public City WaqfCity { get; set; }
        public int? CityId { get; set; }
        public WaqfType WaqfType { get; set; }
        public int? WaqfTypeId { get; set; }
        public WaqfActivity WaqfActivity { get; set; }
        public int? WaqfActivityId { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentUrl { get; set; }
        public WaqfStatus WaqfStatus { get; set; }
        public int WaqfStatusId { get; set; }
        public User InsUser { get; set; }
        public int InsUserId { get; set; }
        public DateTime InsDate { get; set; }
        public User ConfirmUser { get; set; }
        public int? ConfirmUserId { get; set; }
        public DateTime? ConfirmDate { get; set; }


    }
}
