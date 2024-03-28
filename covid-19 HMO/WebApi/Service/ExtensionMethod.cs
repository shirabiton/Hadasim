using Common.Dto;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Service.Interface;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    // מחלקה סטטית 1
    public static class ExtensionMethod
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddRepository();
            services.AddScoped<IService<MemberDto>, MemberService>();
            services.AddScoped<IService<CorornaVaccineDto>, CorornaVaccineService>();
            services.AddScoped<IService<CityDto>, CityService>();
            services.AddScoped<IService<ManufacturerDto>, ManufacturerService>();

            services.AddAutoMapper(typeof(MapperProfile));
            return services;
        }
    }
}
