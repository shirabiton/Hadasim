using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CorornaVaccine>? CorornaVaccines { get; set; }

    }
}
