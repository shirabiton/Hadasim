using AutoMapper;
using Common.Dto;
using Repository.Entities;
using Repository.Interfaces;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CityService : IService<CityDto>
    {
        private readonly IRepository<City> _repository;
        private readonly IMapper _mapper;
        public CityService(IRepository<City> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public CityDto Add(CityDto entity)
        {
            return _mapper.Map<CityDto>(_repository.Add(_mapper.Map<City>(entity)));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<CityDto> GetAll()
        {
            return _mapper.Map<List<CityDto>>(_repository.GetAll());
        }

        public CityDto GetById(int id)
        {
            return _mapper.Map<CityDto>(_repository.Get(id));
        }

        public CityDto Update(int id, CityDto entity)
        {
            return _mapper.Map<CityDto>(_repository.Update(id, _mapper.Map<City>(entity)));
        }
    }
}

