using AutoMapper;
using Common.Dto;
using Microsoft.EntityFrameworkCore;
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
    public class MemberService : IService<MemberDto>
    {
        private readonly IRepository<Member> _repository;
        private readonly IRepository<CorornaVaccine> _corornaVaccineRepository;
        private readonly IMapper _mapper;
        public MemberService(IRepository<Member> repository, IRepository<CorornaVaccine> crepository, IMapper mapper)
        {
            this._repository = repository;
            this._corornaVaccineRepository = crepository;
            this._mapper = mapper;
        }
        public MemberDto Add(MemberDto entity)
        {
            if (_repository.GetAll().Any(m => m.IdNumber == entity.IdNumber))
            {
                throw new InvalidOperationException("Member numberId must be unique.");
            }
            else
            {
                // המרה מ MemberDto ל Member ע"י Mapper
                return _mapper.Map<MemberDto>(_repository.Add(_mapper.Map<Member>(entity)));
            }
        }
        
        public void Delete(int id)
        {
            var vaccines = _corornaVaccineRepository.GetAll().Where(c => c.MemberId == id)?.ToList();
            if (vaccines == null)
                return;
            foreach (var vaccine in vaccines)
            {
                _corornaVaccineRepository.Delete(vaccine.Id);
            }
            _repository.Delete(id);
        }

        public List<MemberDto> GetAll()
        {
            return _mapper.Map<List<MemberDto>>(_repository.GetAll());
        }

        public MemberDto GetById(int id)
        {
            return _mapper.Map<MemberDto>(_repository.Get(id));
        }

        public MemberDto Update(int id, MemberDto entity)
        {
            // המרה מ Member ל MemberDto עבור השליחה ל repository
            return _mapper.Map<MemberDto>(_repository.Update(id, _mapper.Map<Member>(entity)));
        }
    }
}
