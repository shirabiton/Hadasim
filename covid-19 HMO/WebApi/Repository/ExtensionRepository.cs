using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    // מחלקה סטטית 1
    public static class ExtensionRepository
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            // הזרקת תלויות
            services.AddScoped<IRepository<Member>, MemberRepository>();
            services.AddScoped<IRepository<CorornaVaccine>, CorornaVaccineRepository>();
            services.AddScoped<IRepository<City>, CityRepository>();
            services.AddScoped<IRepository<Manufacturer>, ManufacturerRepository>();

            return services;
        }
    }
}
