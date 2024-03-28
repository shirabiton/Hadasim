using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ManufacturerRepository : IRepository<Manufacturer>
    {
        private readonly IContext _context;
        public ManufacturerRepository(IContext context)
        {
            this._context = context;
        }
        public Manufacturer Add(Manufacturer entity)
        {
            this._context.Manufacturers.Add(entity);
            this._context.Save();
            return entity;
        }

        public void Delete(int id)
        {
            var manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.Id == id);
            if (manufacturer != null)
            {
                this._context.Manufacturers.Remove(manufacturer);
                this._context.Save();
            }
        }

        public Manufacturer Get(int id)
        {
            return this._context.Manufacturers.FirstOrDefault(m => m.Id == id);
        }

        public List<Manufacturer> GetAll()
        {
            return this._context.Manufacturers.ToList();
        }

        public Manufacturer Update(int id, Manufacturer entity)
        {
            var prev = Get(id);
            if (prev != null)
            {
                prev.Name = entity.Name;
            }
            else
            {
                this._context.Manufacturers.Add(entity);
            }

            this._context.Save();
            return entity;
        }
    }
}
