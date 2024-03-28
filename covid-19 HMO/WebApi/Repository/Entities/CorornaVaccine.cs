using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class CorornaVaccine
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }

        public int MemberId {  get; set; }
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
    }
}
