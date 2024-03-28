using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CorornaVaccineRepository : IRepository<CorornaVaccine>
    {

        private readonly IContext _context;
        public CorornaVaccineRepository(IContext context)
        {
            this._context = context;
        }
        public CorornaVaccine Add(CorornaVaccine entity)
        {
            this._context.CorornaVaccines.Add(entity);
            this._context.Save();
            return entity;
        }

        public void Delete(int id)
        {
            var corornaVaccine = this._context.CorornaVaccines.FirstOrDefault(c => c.Id == id);
            if (corornaVaccine != null)
            {
                this._context.CorornaVaccines.Remove(corornaVaccine);
                this._context.Save();
            }
        }

        public CorornaVaccine Get(int id)
        {
            return this._context.CorornaVaccines.FirstOrDefault(c => c.Id == id);
        }

        public List<CorornaVaccine> GetAll()
        {
            return this._context.CorornaVaccines.ToList();
        }

        public CorornaVaccine Update(int id, CorornaVaccine entity)
        {
            var prev = Get(id);
            if (prev != null)
            {
                prev.Date = entity.Date;
                prev.Manufacturer = entity.Manufacturer;
                prev.Member = entity.Member;
            }
            else
            {
                this._context.CorornaVaccines.Add(entity);
            }

            this._context.Save();
            return entity;
        }
    }
}





