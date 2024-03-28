using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; } // תעודת זהות
        
        public int CityId {  get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? DateOfSickness {  get; set; }
        public DateTime? DateOfRecovery {  get; set; }
        //public ICollection<CorornaVaccine>? CorornaVaccines { get; set; }

    }
}
