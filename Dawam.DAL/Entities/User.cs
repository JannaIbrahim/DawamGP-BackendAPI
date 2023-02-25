using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dawam.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public Country country { get; set; }
        public int CountryId { get; set; }
        public City city { get; set; }
        public int CityId { get; set; }
        public DateTime StartDate { get; set; }
        public string Role { get; set; }
        public Byte Editor { get; set; } // 1 for editors 0 for supervisors
    }
}
