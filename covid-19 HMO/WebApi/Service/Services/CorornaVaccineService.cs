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
    public class CorornaVaccineService : IService<CorornaVaccineDto>
    {
        private readonly IRepository<CorornaVaccine> _repository;
        private readonly IMapper _mapper;
        public CorornaVaccineService(IRepository<CorornaVaccine> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public CorornaVaccineDto Add(CorornaVaccineDto entity)
        {
            if (CanAddCoronaVaccine(entity.MemberId))
            {
                return _mapper.Map<CorornaVaccineDto>(_repository.Add(_mapper.Map<CorornaVaccine>(entity)));
            }
            else
            {
                throw new InvalidOperationException("Cannot add corona vaccine. Member has reached the maximum limit of vaccines.");
            }
        }


        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<CorornaVaccineDto> GetAll()
        {
            return _mapper.Map<List<CorornaVaccineDto>>(_repository.GetAll());
        }

        public CorornaVaccineDto GetById(int id)
        {
            return _mapper.Map<CorornaVaccineDto>(_repository.Get(id));
        }

        public CorornaVaccineDto Update(int id, CorornaVaccineDto entity)
        {
            return _mapper.Map<CorornaVaccineDto>(_repository.Update(id, _mapper.Map<CorornaVaccine>(entity)));
        }

        public bool CanAddCoronaVaccine(int memberId)
        {
            var vaccinesPerMember = _repository.GetAll().Where(c => c.MemberId == memberId).ToList();
            return vaccinesPerMember.Count < 4;
        }

    }
}

