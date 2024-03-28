using AutoMapper;
using Common.Dto;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MapperProfile:Profile
    { // Profile מ AutoMapper
        public MapperProfile()
        {
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<CorornaVaccine, CorornaVaccineDto>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
