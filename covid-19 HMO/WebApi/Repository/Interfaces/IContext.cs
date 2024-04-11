using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository.Interfaces

    // תיאור מקור הנתונים
    // הזרקת תלויות. במקום להיות תלוי ב DB ניתן להיות תלוי ב ICONTEXT
    // הפשטת הנתונים
{
    public interface IContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<CorornaVaccine> CorornaVaccines { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<City> Cities { get; set; }

        public void Save();
    }
}
