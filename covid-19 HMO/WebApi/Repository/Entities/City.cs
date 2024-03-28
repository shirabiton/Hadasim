using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class City
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Member>? Members { get; set; }
    }
}
