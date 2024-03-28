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
    public class ManufacturerService : IService<ManufacturerDto>
    {
        private readonly IRepository<Manufacturer> _repository;
        private readonly IMapper _mapper;
        public ManufacturerService(IRepository<Manufacturer> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public ManufacturerDto Add(ManufacturerDto entity)
        {
            return _mapper.Map<ManufacturerDto>(_repository.Add(_mapper.Map<Manufacturer>(entity)));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<ManufacturerDto> GetAll()
        {
            return _mapper.Map<List<ManufacturerDto>>(_repository.GetAll());
        }

        public ManufacturerDto GetById(int id)
        {
            return _mapper.Map<ManufacturerDto>(_repository.Get(id));
        }

        public ManufacturerDto Update(int id, ManufacturerDto entity)
        {
            return _mapper.Map<ManufacturerDto>(_repository.Update(id, _mapper.Map<Manufacturer>(entity)));
        }
    }
}

