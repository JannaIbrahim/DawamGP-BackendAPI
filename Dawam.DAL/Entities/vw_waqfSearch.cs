﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dawam.DAL.Entities
{
    public class vw_waqfSearch : BaseEntity
    {
        public string WaqfName { get; set; }
        public string FounderName { get; set; }
        public int? DocumentNumber { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public DateTime? EstablishmentDateH { get; set; }
        public string WaqfDescription { get; set; }
        public string WaqfCountry { get; set; }
        public int? CountryId { get; set; }
        public string WaqfCity { get; set; }
        public int? CityId { get; set; }
        public string WaqfType { get; set; }
        public int? WaqfTypeId { get; set; }
        public string WaqfActivity { get; set; }
        public int? WaqfActivityId { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentUrl { get; set; }
        //public WaqfStatus WaqfStatus { get; set; }
        public int WaqfStatusId { get; set; }
        public string AdminNotes { get; set; }
        //public User InsUser { get; set; }
        public int InsUserId { get; set; }
        public DateTime InsDate { get; set; }
        //public User ConfirmUser { get; set; }
        public int? ConfirmUserId { get; set; }
        public DateTime? ConfirmDate { get; set; }
    }
}
