using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;

namespace DataContext
{
    // מספקת גישה למסד הנתונים ומגשרת בין המחלקות לטבלאות
    public class Db : DbContext, IContext
    {
        public DbSet<Member> Members {  get; set; }
        public DbSet<CorornaVaccine> CorornaVaccines { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<City> Cities { get; set; }

        public void Save()
        {
            // שיטה של המחלקה db context ושומרת את השינויים במסד הנתונים
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-OP3HLHL; database=HMOCoronaDb; trusted_connection=true; TrustServerCertificate=True;");
        }
    }
}