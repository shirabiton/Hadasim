using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;

namespace DataContext
{
    public class Db : DbContext, IContext
    {
        public DbSet<Member> Members {  get; set; }
        public DbSet<CorornaVaccine> CorornaVaccines { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<City> Cities { get; set; }

        public void Save()
        {
            SaveChanges(); // !הסבר
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-OP3HLHL; database=HMOCoronaDb; trusted_connection=true; TrustServerCertificate=True;");
        }
    }
}