using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private readonly IContext _context;
        public CityRepository(IContext context)
        {
            this._context = context;
        }
        public City Add(City entity)
        {
            this._context.Cities.Add(entity);
            this._context.Save();
            return entity;
        }

        public void Delete(int id)
        {
            var city = this._context.Cities.FirstOrDefault(c => c.Id == id);
            if (city != null)
            {
                this._context.Cities.Remove(city);
                this._context.Save();
            }
        }

        public City Get(int id)
        {
            return this._context.Cities.FirstOrDefault(c => c.Id == id);
        }

        public List<City> GetAll()
        {
            return this._context.Cities.ToList();
        }

        public City Update(int id, City entity)
        {
            var prev = Get(id);
            if (prev != null)
            {
                prev.Name = entity.Name;
            }
            else
            {
                this._context.Cities.Add(entity);
            }

            this._context.Save();
            return entity;
        }
    }
}


